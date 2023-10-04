using Microsoft.EntityFrameworkCore;

namespace Benchmarks;

[BenchmarkDotNet.Attributes.MemoryDiagnoser]
[BenchmarkDotNet.Attributes.GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
public class TraditionalDeleteVsExecuteDelete
{
    [BenchmarkDotNet.Attributes.Params
        (1_000, 2_000, 5_000, 10_000, 20_000, 50_000, 100_000, 200_000, 500_000, 1_000_000)]
    public int Rows { get; set; }

    [BenchmarkDotNet.Attributes.IterationSetup]
    public void IterationSetup()
    {
        Benchmarks.GlobalAndIterationSetup.FillDatabaseWithFakeTestData
            (testFatherCount: 2_000_000, ignoreCheckIfDatabaseHasData: false);
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void TraditionalDelete()
    {
        using var dbContext = new Model.DatabaseContext();

        var recordsToUpdate = dbContext.Fathers.Take(Rows).ToList();

        foreach (var record in recordsToUpdate)
        {
            dbContext.Fathers.Remove(record);
        }

        dbContext.SaveChanges();
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void ExecuteDelete()
    {
        using var dbContext = new Model.DatabaseContext();

        dbContext.Fathers.Take(Rows).ExecuteDelete();
    }
}
