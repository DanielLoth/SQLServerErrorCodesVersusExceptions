//using BenchmarkDotNet.Attributes;

//namespace Benchmarks;

//public class InsertBenchmarks : BenchmarkBase
//{
//    public const int OpsPerInvoke = 100;

//    [Benchmark(OperationsPerInvoke = OpsPerInvoke)]
//    public void Insert_TryCatchThrow_50Percent()
//        => ExecuteProcedure("dbo.Insert_TryCatchThrow_50Percent", OpsPerInvoke);

//    [Benchmark(OperationsPerInvoke = OpsPerInvoke)]
//    public void Insert_TryCatchReturn_50Percent()
//        => ExecuteProcedure("dbo.Insert_TryCatchReturn_50Percent", OpsPerInvoke);

//    [Benchmark(OperationsPerInvoke = OpsPerInvoke)]
//    public void Insert_CheckReturn_50Percent()
//        => ExecuteProcedure("dbo.Insert_CheckReturn_50Percent", OpsPerInvoke);
//}
