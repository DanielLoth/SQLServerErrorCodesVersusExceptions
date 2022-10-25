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

    protected static void ExecuteProcedure(string procedureName, int operationsPerInvoke)
    {
        using var con = new SqlConnection(ConnectionString);
        using var cmd = con.CreateCommand();

        cmd.CommandText = procedureName;
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            con.Open();

            for (var i = 0; i < operationsPerInvoke; i++)
            {
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
        catch
        {
            // Discard
        }
        finally
        {
            if (con.State != ConnectionState.Closed) con.Close();
        }
    }
}
