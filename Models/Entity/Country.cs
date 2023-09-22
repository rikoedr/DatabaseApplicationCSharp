using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Models.Entity;

public class Country : IDataEntity<Country>
{
    public string ID { get; set; }
    public string Name { get; set; }
    public int RegionID { get; set; }

    public Country()
    {
        ID = "Empty";
        Name = "Empty";
        RegionID = 0;
    }

    public Country SQLReader(SqlDataReader reader)
    {
        return new Country
        {
            ID = reader.GetString(0),
            Name = reader.GetString(1),
            RegionID = reader.GetInt32(2)
        };
    }

    public string getString()
    {
        return $"[{ID}] Name : {Name} - Region ID : {RegionID}";
    }

}
