using BenchmarkDotNet.Attributes;

namespace Benchmarks;

public class NoDataAccessBenchmarks : BenchmarkBase
{
    public const int OpsPerInvoke = 1000;

    //[Benchmark(OperationsPerInvoke = OpsPerInvoke)]
    //public void NoDataAccess_TryCatchThrow_50Percent()
    //    => ExecuteProcedure("dbo.NoDataAccess_TryCatchThrow_50Percent", OpsPerInvoke);

    //[Benchmark(OperationsPerInvoke = OpsPerInvoke)]
    //public void NoDataAccess_TryCatchReturnError_50Percent()
    //    => ExecuteProcedure("dbo.NoDataAccess_TryCatchReturnError_50Percent", OpsPerInvoke);

    //[Benchmark(OperationsPerInvoke = OpsPerInvoke)]
    //public void NoDataAccess_CheckReturnError_50Percent()
    //    => ExecuteProcedure("dbo.NoDataAccess_CheckReturnError_50Percent", OpsPerInvoke);

    //[Benchmark(OperationsPerInvoke = OpsPerInvoke)]
    //public void Insert_TryCatchThrow_50Percent()
    //    => ExecuteProcedure("dbo.Insert_TryCatchThrow_50Percent", OpsPerInvoke);

    //[Benchmark(OperationsPerInvoke = OpsPerInvoke)]
    //public void Insert_TryCatchReturn_50Percent()
    //    => ExecuteProcedure("dbo.Insert_TryCatchReturn_50Percent", OpsPerInvoke);

    //[Benchmark(OperationsPerInvoke = OpsPerInvoke)]
    //public void Insert_CheckReturn_50Percent()
    //    => ExecuteProcedure("dbo.Insert_CheckReturn_50Percent", OpsPerInvoke);

    [Benchmark(OperationsPerInvoke = OpsPerInvoke)]
    public void Insert_TryCatchThrow_100Percent()
        => ExecuteProcedure("dbo.Insert_TryCatchThrow_100Percent", OpsPerInvoke);

    [Benchmark(OperationsPerInvoke = OpsPerInvoke)]
    public void Insert_TryCatchReturn_100Percent()
        => ExecuteProcedure("dbo.Insert_TryCatchReturn_100Percent", OpsPerInvoke);

    [Benchmark(OperationsPerInvoke = OpsPerInvoke)]
    public void Insert_CheckReturn_100Percent()
        => ExecuteProcedure("dbo.Insert_CheckReturn_100Percent", OpsPerInvoke);

    [Benchmark(OperationsPerInvoke = OpsPerInvoke)]
    public void Insert_TryCheckReturn_100Percent()
        => ExecuteProcedure("dbo.Insert_TryCheckReturn_100Percent", OpsPerInvoke);
}
