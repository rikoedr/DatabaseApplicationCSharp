using System.Data.SqlClient;

namespace DBApp.Models.Entity;

public class Region : IDataEntity<Region>
{
    public int ID { get; set; }
    public string Name { get; set; }
    public Region()
    {
        ID = 0;
        Name = "Empty";
    }

    public string getString()
    {
        return $"ID: {ID} - {Name}";
    }

    public Region SQLReader(SqlDataReader reader)
    {
        return new Region
        {
            ID = reader.GetInt32(0),
            Name = reader.GetString(1)
        };
    }
}
