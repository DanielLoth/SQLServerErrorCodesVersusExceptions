using BenchmarkDotNet.Attributes;

namespace Benchmarks;

//[SimpleJob(RunStrategy.Monitoring, launchCount: 0, warmupCount: 0, targetCount: 1)]
[MinColumn, Q1Column, Q3Column, MeanColumn, MedianColumn, MaxColumn]
public class Benchmark : BenchmarkBase
{
    [Params(0, 50, 100)]
    public int FailureRatePercent { get; set; }

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

    //[Benchmark(OperationsPerInvoke = OpsPerInvoke)]
    //public void Insert_TryCatchThrow_100Percent()
    //    => ExecuteProcedure("dbo.Insert_TryCatchThrow_100Percent", OpsPerInvoke);

    //[Benchmark(OperationsPerInvoke = OpsPerInvoke)]
    //public void Insert_TryCatchReturn_100Percent()
    //    => ExecuteProcedure("dbo.Insert_TryCatchReturn_100Percent", OpsPerInvoke);

    //[Benchmark(OperationsPerInvoke = OpsPerInvoke)]
    //public void Insert_CheckReturn_100Percent()
    //    => ExecuteProcedure("dbo.Insert_CheckReturn_100Percent", OpsPerInvoke);

    //[Benchmark(OperationsPerInvoke = OpsPerInvoke)]
    //public void Insert_TryCheckReturn_100Percent()
    //    => ExecuteProcedure("dbo.Insert_TryCheckReturn_100Percent", OpsPerInvoke);

    [Benchmark(OperationsPerInvoke = 10000)]
    public void TryCatchThrow() => ExecuteProcedure("dbo.TryCatchThrow", FailureRatePercent);

    [Benchmark(OperationsPerInvoke = 10000)]
    public void TryCatchReturn() => ExecuteProcedure("dbo.TryCatchReturn", FailureRatePercent);

    [Benchmark(OperationsPerInvoke = 10000)]
    public void TryCheckReturn() => ExecuteProcedure("dbo.TryCheckReturn", FailureRatePercent);

    [Benchmark(OperationsPerInvoke = 10000)]
    public void CheckReturn() => ExecuteProcedure("dbo.CheckReturn", FailureRatePercent);
}
