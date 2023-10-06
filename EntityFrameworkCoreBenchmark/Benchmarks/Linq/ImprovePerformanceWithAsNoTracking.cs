using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Benchmarks.Linq;

[BenchmarkDotNet.Attributes.MemoryDiagnoser]
[BenchmarkDotNet.Attributes.GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
public class ImprovePerformanceWithAsNoTracking
{
    [BenchmarkDotNet.Attributes.Params
        (1_000, 2_000, 5_000, 10_000)]
    public int Rows { get; set; }

    [BenchmarkDotNet.Attributes.GlobalSetup]
    public void GlobalSetup()
    {
        Benchmarks.GlobalAndIterationSetup.FillDatabaseWithFakeTestData
            (testFatherCount: 10_000, ignoreCheckIfDatabaseHasData: false);
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
        return dbContext.Children.AsNoTracking().Take(Rows).ToList();
    }

    //public static IEnumerable<Model.Father> ReturnNullRealJob()
    //{
    //    IEnumerable<Model.Father> result;

    //    using var DbContext = new Model.DatabaseContext();
    //    result = DbContext.Fathers.Where(a => a.Name == "Hamed Banaei" && a.NickName == "MrTechLead");

    //    return (result);
    //}

    //public static IEnumerable<Model.Father> ReturnEmptyEnumerableRealJob()
    //{
    //    IEnumerable<Model.Father> result;

    //    using var DbContext = new Model.DatabaseContext();
    //    result = DbContext.Fathers.Where(a => a.Name == "Hamed Banaei" && a.NickName == "MrTechLead");

    //    if (result == null)
    //    {
    //        result = Enumerable.Empty<Model.Father>();
    //    }
    //    return (result);
    //}
}
