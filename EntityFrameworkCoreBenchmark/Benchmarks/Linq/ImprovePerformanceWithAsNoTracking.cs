using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Benchmarks.Linq;

[BenchmarkDotNet.Attributes.MemoryDiagnoser]
[BenchmarkDotNet.Attributes.GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
public class ImprovePerformanceWithAsNoTracking
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
    public List<Model.Child> FetchDataInNormalWay()
    {
        using var dbContext = new Model.DatabaseContext();
        return dbContext.Children.Take(Rows).ToList();
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public List<Model.Child> FetchDataWithAsNoTracking()
    {
        using var dbContext = new Model.DatabaseContext();
        return dbContext.Children.Take(Rows).AsNoTracking().ToList();
    }
}
