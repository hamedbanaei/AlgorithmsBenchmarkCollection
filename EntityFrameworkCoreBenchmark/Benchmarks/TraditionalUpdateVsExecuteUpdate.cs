namespace Benchmarks;

[BenchmarkDotNet.Attributes.MemoryDiagnoser]
[BenchmarkDotNet.Attributes.GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
public class TraditionalUpdateVsExecuteUpdate
{
    [BenchmarkDotNet.Attributes.Params
        (1_000, 2_000, 5_000, 10_000, 20_000, 50_000, 100_000)]
    public int Rows { get; set; }

    [BenchmarkDotNet.Attributes.GlobalSetup]
    public void GlobalSetup()
    {
        
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void UsingForeachLoop()
    {
        
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void UsingLinqForeach()
    {
        
    }
}
