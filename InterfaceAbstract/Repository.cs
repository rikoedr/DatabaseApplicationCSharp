using DBApp.Entity;
using System.Data.Common;
using System.Data.SqlClient;

namespace DBApp;

public abstract class Repository<T>
    where T : IEntity<T>
{
    protected T tableEntity;
    protected string tableName;
    
    public virtual List<T> GetAll(){
        List<T> list = new List<T>();

        using SqlConnection dbConnection = DBConnection.Create();
        using SqlCommand dbCommand = DBConnection.GetCommand();

        dbCommand.Connection = dbConnection;
        dbCommand.CommandText = $"SELECT * FROM {tableName}";

        try {
            dbConnection.Open();

            using SqlDataReader reader = dbCommand.ExecuteReader();

            if(reader.HasRows) {
                while(reader.Read()) {
                    list.Add(tableEntity.SQLReader(reader));
                }
            }

            reader.Close();
            dbConnection.Close();

            return list;
        }
        catch(Exception error) {
            Console.WriteLine("Error : " + error);
        }

        return list;
    }

    public virtual T GetById<U>(U id) {
        using SqlConnection dbConnection = DBConnection.Create();
        using SqlCommand dbCommand = DBConnection.GetCommand();

        dbCommand.Connection = dbConnection;
        dbCommand.CommandText = $"SELECT * FROM {tableName} WHERE id = @id";
        dbCommand.Parameters.Add(new SqlParameter("@id", id));

        try {
            dbConnection.Open();

            using SqlDataReader reader = dbCommand.ExecuteReader();

            if (reader.HasRows) {
                while (reader.Read()) {
                    return tableEntity.SQLReader(reader);
                }
            }
            reader.Close();
            dbConnection.Close();

            return tableEntity;
        }
        catch (Exception error)
        {
            Console.WriteLine($"Insertion Error : {error.Message}");
            return tableEntity;
        }
    }

    protected string Insert(List<SqlParameter> parameters)
    {
        using SqlConnection connection = DBConnection.Create();
        using SqlCommand command = DBConnection.GetCommand();

        command.Connection = connection;
        command.CommandText = $"INSERT INTO {tableName} VALUES ({generateParameterString(parameters)})";

        foreach(SqlParameter parameter in parameters)
        {
            command.Parameters.Add(parameter);
        }

        try
        {
            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                command.Transaction = transaction;
                int result = command.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

                return result.ToString();
            }
            catch(Exception error)
            {
                transaction.Rollback();
                return $"Transaction Error : {error.Message}";
            }
            
        }
        catch (Exception error)
        {
            return $"Insertion Error : {error.Message}";
        }
    }

    protected T GetLastRow()
    {
        using SqlConnection dbConnection = DBConnection.Create();
        using SqlCommand dbCommand = DBConnection.GetCommand();

        dbCommand.Connection = dbConnection;
        dbCommand.CommandText = $"SELECT TOP 1 * FROM {tableName} ORDER BY id DESC";

        try
        {
            dbConnection.Open();

            using SqlDataReader reader = dbCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    return tableEntity.SQLReader(reader);
                }
            }
            reader.Close();
            dbConnection.Close();

            return tableEntity;
        }
        catch (Exception error)
        {
            Console.WriteLine($"Get Data Error : {error.Message}");
            return tableEntity;
        }
    }

    private string generateParameterString(List<SqlParameter> parameters)
    {
        string result = "";
        int count = 0;
        foreach(SqlParameter parameter in parameters)
        {
            if(count != parameters.Count - 1)
            {
                result += parameter.ParameterName + ", ";
                count++;
            }else
            {
                result += parameter.ParameterName;
            }
        }

        return result;
    }


    
}
