using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LinqBenchmark;

[BenchmarkDotNet.Attributes.MemoryDiagnoser]
[BenchmarkDotNet.Attributes.GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
public class SkipTakeVsTakeRange
{
    [BenchmarkDotNet.Attributes.Params
        (1_000, 2_000, 5_000, 10_000, 20_000, 50_000, 100_000, 200_000, 500_000, 1_000_000)]
    public int Rows { get; set; }

    public System.Collections.Generic.List<Model.Father> Fathers { get; set; }

    [BenchmarkDotNet.Attributes.GlobalSetup]
    public void GlobalSetup()
    {
        Benchmarks.GlobalTestSetup.FillDatabaseWithFakeTestData
            (testFatherCount: 2_000_000, ignoreCheckIfDatabaseHasData: false);

    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void SkipTake()
    {
        using var dbContext = new Model.DatabaseContext();

        var recordsToUpdate = dbContext.Children.Skip(Rows).Take(Rows).ToList();

        dbContext.SaveChanges();
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void TakeRange()
    {
        using var dbContext = new Model.DatabaseContext();

        dbContext.Fathers.Take(Rows..Rows).ToList();
    }
}
