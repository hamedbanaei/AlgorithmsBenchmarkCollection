using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Benchmarks.Linq;

[MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
[BenchmarkDotNet.Attributes.MemoryDiagnoser]
[BenchmarkDotNet.Attributes.GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
public class ReturnNullVsEmptyCollection
{
    [BenchmarkDotNet.Attributes.GlobalSetup]
    public void GlobalSetup()
    {
        Benchmarks.GlobalAndIterationSetup.FillDatabaseWithFakeTestData
            (testFatherCount: 2_000_000, ignoreCheckIfDatabaseHasData: false);
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void ReturnNull()
    {
        IEnumerable<Model.Father>? fathers = ReturnNullRealJob();
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void ReturnEmptyEnumerable()
    {
        IEnumerable<Model.Father> fathers = ReturnEmptyEnumerableRealJob();
    }

    public static IEnumerable<Model.Father> ReturnNullRealJob()
    {
        IEnumerable<Model.Father> result;

        using var DbContext = new Model.DatabaseContext();
        result = DbContext.Fathers.Where(a => a.Name == "Hamed Banaei" && a.NickName == "MrTechLead");

        return (result);
    }

    public static IEnumerable<Model.Father> ReturnEmptyEnumerableRealJob()
    {
        IEnumerable<Model.Father> result;

        using var DbContext = new Model.DatabaseContext();
        result = DbContext.Fathers.Where(a => a.Name == "Hamed Banaei" && a.NickName == "MrTechLead");

        if (result == null)
        {
            result = Enumerable.Empty<Model.Father>();
        }
        return (result);
    }
}
