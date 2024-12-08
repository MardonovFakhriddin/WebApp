using Npgsql;

namespace Infrastructure.Data;

public class DapperContext
{
    private readonly string connectionString = "Server = localhost;Port = 5432;Database = Company_DB;Username = postgres;Password = LMard1909";

    public NpgsqlConnection Connection
    {
        get
        {
            return new NpgsqlConnection(connectionString); 
            
        }
    }
}