using System.Data.SqlClient;

namespace DBApp;

public interface IEntity<T> {
    string getString();
    public T SQLReader(SqlDataReader reader);
}
