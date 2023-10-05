namespace Benchmarks.Linq;

[BenchmarkDotNet.Attributes.MemoryDiagnoser]
[BenchmarkDotNet.Attributes.GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
public class SkipTakeVsTakeRange
{
    [BenchmarkDotNet.Attributes.Params
        (1_000, 2_000, 5_000, 10_000, 20_000, 50_000, 100_000, 200_000, 500_000, 1_000_000)]
    public int Rows { get; set; }

    public System.Collections.Generic.List<Model.Child> Children { get; set; }

    [BenchmarkDotNet.Attributes.GlobalSetup]
    public void GlobalSetup()
    {
        Benchmarks.GlobalAndIterationSetup.FillDatabaseWithFakeTestData
            (testFatherCount: 2_000_000, ignoreCheckIfDatabaseHasData: false);

        using var dbContext = new Model.DatabaseContext();
        Children = dbContext.Children.Take(2_100_000).ToList();
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void SkipTake()
    {
        var result = Children.Skip(Rows).Take(Rows).ToList();
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void TakeRange()
    {
        var result = Children.Take(Rows..(Rows + Rows)).ToList();
    }
}
