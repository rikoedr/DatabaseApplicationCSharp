using System.Data.SqlClient;

namespace DBApp;

public interface IDataEntity<T> {
    string getString();
    public T SQLReader(SqlDataReader reader);
}
