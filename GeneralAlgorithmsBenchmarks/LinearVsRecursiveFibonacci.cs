namespace GeneralAlgorithmsBenchmarks;

[BenchmarkDotNet.Attributes.MemoryDiagnoser]
[BenchmarkDotNet.Attributes.GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
public class LinearVsRecursiveFibonacci
{
    [BenchmarkDotNet.Attributes.Params
        (1, 2, 5, 10, 20, 50)]
    public ulong Sequence { get; set; }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void LinearFibonacci()
    {
        ulong result = LinearApproch(Sequence);
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public void RecursiveFibonacci()
    {
        ulong result = RecursiveApproch(Sequence);
    }

    public static ulong LinearApproch(ulong SequenceNumber)
    {
        if (SequenceNumber == 1) return 0;
        if (SequenceNumber == 2) return 1;

        ulong previous = 0;
        ulong current = 1;

        for (ulong i = 0; i < SequenceNumber - 2; i++)
        {
            ulong next = previous + current;
            previous = current;
            current = next;
        }

        return (current);
    }

    public static ulong RecursiveApproch(ulong SequenceNumber)
    {
        if (SequenceNumber == 1) return 0;
        if (SequenceNumber == 2) return 1;

        return (RecursiveApproch(SequenceNumber - 1) + RecursiveApproch(SequenceNumber - 2));
    }
}
