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
}
