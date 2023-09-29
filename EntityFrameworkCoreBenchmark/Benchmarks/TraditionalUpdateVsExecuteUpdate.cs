using Microsoft.EntityFrameworkCore;

namespace Benchmarks;

[BenchmarkDotNet.Attributes.MemoryDiagnoser]
[BenchmarkDotNet.Attributes.GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
public class TraditionalUpdateVsExecuteUpdate
{
    [BenchmarkDotNet.Attributes.Params
        (1_000, 2_000, 5_000, 10_000)]
    public int Rows { get; set; }

    [BenchmarkDotNet.Attributes.GlobalSetup]
    public void GlobalSetup()
    {
        Benchmarks.GlobalTestSetup.FillDatabaseWithFakeTestData(fatherCount: 1_000);
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void TraditionalUpdate()
    {
        using (var dbContext = new Model.DatabaseContext())
        {
            var recordsToUpdate = dbContext.Children.Take(Rows).ToList();

            foreach (var record in recordsToUpdate)
            {
                record.Name = record.Name.ToLower();
            }

            dbContext.SaveChanges();
        }
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void ExecuteUpdate()
    {
        using (var dbContext = new Model.DatabaseContext())
        {
            dbContext.Children.Take(Rows).ExecuteUpdate(x => x.SetProperty(y => y.Name, y => y.Name.ToUpper()));
        }
    }
}
