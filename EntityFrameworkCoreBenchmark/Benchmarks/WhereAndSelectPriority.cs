using Microsoft.EntityFrameworkCore;

namespace Benchmarks;

[BenchmarkDotNet.Attributes.MemoryDiagnoser]
[BenchmarkDotNet.Attributes.GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
public class WhereAndSelectPriority
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
    public void WhereThenSelect()
    {
        using var dbContext = new Model.DatabaseContext();

        var list = dbContext.Children.Where(c => c.Name.Contains("ham")).Select(c => c);
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void SelectThenWhere()
    {
        using var dbContext = new Model.DatabaseContext();

        var list = dbContext.Children.Select(c => c).Where(c => c.Name.Contains("ham"));
    }
}
