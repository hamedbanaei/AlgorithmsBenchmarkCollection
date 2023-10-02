using Microsoft.EntityFrameworkCore;

namespace Benchmarks;

[BenchmarkDotNet.Attributes.MemoryDiagnoser]
[BenchmarkDotNet.Attributes.GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
public class TraditionalUpdateVsExecuteUpdate
{
    [BenchmarkDotNet.Attributes.Params
        (1_000, 2_000, 5_000, 10_000, 20_000, 50_000, 100_000, 200_000, 500_000, 1_000_000)]
    public int Rows { get; set; }

    [BenchmarkDotNet.Attributes.GlobalSetup]
    public void GlobalSetup()
    {
        Benchmarks.GlobalTestSetup.FillDatabaseWithFakeTestData
            (testFatherCount: 2_000_000, ignoreCheckIfDatabaseHasData: false);
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void TraditionalUpdate()
    {
        using var dbContext = new Model.DatabaseContext();

        var recordsToUpdate = dbContext.Fathers.Take(Rows).ToList();

        foreach (var record in recordsToUpdate)
        {
            record.Name = "new name1";
        }

        dbContext.SaveChanges();

    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void ExecuteUpdate()
    {
        using var dbContext = new Model.DatabaseContext();

        dbContext.Fathers.Take(Rows).ExecuteUpdate(upates => upates.SetProperty(y => y.Name, "NEW NAME!"));
    }
}
