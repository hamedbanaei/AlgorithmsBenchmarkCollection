using Microsoft.EntityFrameworkCore;

namespace Benchmarks.Linq;

[BenchmarkDotNet.Attributes.MemoryDiagnoser]
[BenchmarkDotNet.Attributes.GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
[BenchmarkDotNet.Attributes.Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class ImprovePerformanceWithProjection
{
    [BenchmarkDotNet.Attributes.Params
        (1_000, 2_000, 5_000, 10_000, 20_000, 50_000, 100_000, 200_000, 500_000, 1_000_000)]
    public int Rows { get; set; }

    [BenchmarkDotNet.Attributes.GlobalSetup]
    public void GlobalSetup()
    {
        Benchmarks.GlobalAndIterationSetup.FillDatabaseWithFakeTestData
            (testFatherCount: 2_000_000, ignoreCheckIfDatabaseHasData: false);
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void FetchCompleteEntity()
    {
        using var dbContext = new Model.DatabaseContext();
        List<Model.Father> results = 
            dbContext.Fathers
            .Take(Rows)
            .AsNoTracking()
            .ToList();
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void FetchWithProjection()
    {
        using var dbContext = new Model.DatabaseContext();
        List<Model.FatherViewModel> results = 
            dbContext.Fathers
            .Take(Rows)
            .AsNoTracking()
            .Select(f =>
                new Model.FatherViewModel
                {
                    Nikename = f.NickName,
                    ChildrenCount = f.Children.Count
                })
            .ToList();
    }
}