using System.Data.SqlClient;
using System.Text;

namespace DBApp;

public abstract class GeneralDataModel<T>
    where T : IDataEntity<T>
{
    protected T dataEntity;
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
                    list.Add(dataEntity.SQLReader(reader));
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
                    return dataEntity.SQLReader(reader);
                }
            }
            reader.Close();
            dbConnection.Close();

            return dataEntity;
        }
        catch (Exception error)
        {
            Console.WriteLine($"Insertion Error : {error.Message}");
            return dataEntity;
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

    protected string Update(List<SqlParameter> parameters)
    {
        using SqlConnection connection = DBConnection.Create();
        using SqlCommand command = DBConnection.GetCommand();

        command.Connection = connection;
        command.CommandText = $"UPDATE {tableName} SET {generateUpdateParameterString(parameters)} WHERE id = {parameters[0].ParameterName}";
        
        foreach (SqlParameter parameter in parameters)
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
            catch (Exception error)
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

    public string Delete<U>(U id)
    {
        using SqlConnection connection = DBConnection.Create();
        using SqlCommand command = DBConnection.GetCommand();

        command.Connection = connection;
        command.CommandText = $"DELETE FROM {tableName} WHERE id = @id ";
        command.Parameters.Add(new SqlParameter("@id", id));

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
            catch (Exception error)
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
                    return dataEntity.SQLReader(reader);
                }
            }
            reader.Close();
            dbConnection.Close();

            return dataEntity;
        }
        catch (Exception error)
        {
            Console.WriteLine($"Get Data Error : {error.Message}");
            return dataEntity;
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
    private string generateUpdateParameterString(List<SqlParameter> parameters)
    {
        StringBuilder result = new StringBuilder("");
        int count = 0;

        foreach (SqlParameter parameter in parameters)
        {
            StringBuilder tableName = new StringBuilder(parameter.ParameterName).Remove(0, 1);
            if (count > 0 && count != parameters.Count - 1) {
                result.Append($"{tableName.ToString()} = {parameter.ParameterName}, ");
            }

            if (count == parameters.Count - 1)
            {
                result.Append($"{tableName.ToString()} = {parameter.ParameterName}");
            }

            count += 1;
        }

        return result.ToString();

    }


    
}
