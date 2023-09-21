using System.Data.SqlClient;

namespace DBApp;

public class Region : IEntity<Region>
{
    public int ID { get; set; }
    public string Name { get; set; }
    public Region(){
        this.ID = 0;
        this.Name = "Empty";
    }

    public string getString()
    {
        return $"[{ID}] {Name}";
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
