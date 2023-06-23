using Microsoft.Data.SqlClient;
using System.Data;

namespace Benchmarks;

public abstract class BenchmarkBase
{
    protected const string ConnectionString =
        "Data Source=localhost;" +
        "Integrated Security=True;" +
        "Initial Catalog=SQLServerErrorCodesVersusExceptions;" +
        "Persist Security Info=False;" +
        "Pooling=False;" +
        "MultipleActiveResultSets=False;" +
        "Connect Timeout=60;" +
        "Encrypt=True;" +
        "TrustServerCertificate=True";

    protected static void ExecuteProcedure(string procedureName, int failureRatePercent)
    {
        using var con = new SqlConnection(ConnectionString);

        try
        {
            con.Open();

            for (var i = 0; i < 10000; i++)
            {
                using var cmd = con.CreateCommand();

                var p = cmd.CreateParameter();
                p.ParameterName = "ShouldFail";
                p.Value = i < failureRatePercent * 100;
                cmd.Parameters.Add(p);

                cmd.CommandText = procedureName;
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    using var reader = cmd.ExecuteReader();

                    while (reader.Read()) { /* Discard */ }

                    while (reader.NextResult())
                    {
                        while (reader.Read()) { /* Discard */ }
                    }
                }
                catch { }
            }
        }
        finally
        {
            if (con.State != ConnectionState.Closed) con.Close();
        }
    }
}
