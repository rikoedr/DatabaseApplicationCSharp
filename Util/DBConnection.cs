using System.Data.SqlClient;

namespace DBApp.Util;

public class DBConnection
{
    private static readonly string connectionString = "Data Source=ENRICHO;Initial Catalog=db_hr_dts;Integrated Security=True;Connect Timeout=30;Database=db_hr_dts";
    public static string SelectAllQuery = "SELECT * FROM @table_name";
    public static SqlConnection Create()
    {
        return new SqlConnection(connectionString);
    }

    public static SqlCommand GetCommand()
    {
        return new SqlCommand();
    }

    public static SqlParameter AddParamater<T>(string name, T value)
    {
        return new SqlParameter(name, value);
    }
}
