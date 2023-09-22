using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Models.Entity;

public class Location : IDataEntity<Location>
{
    public int ID { get; set; }
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string CountryID { get; set; }

    public Location()
    {
        ID = 0;
        StreetAddress = "Empty";
        PostalCode = "Empty";
        City = "Empty";
        StateProvince = "Empty";
        CountryID = "Empty";
    }

    public string getString()
    {
        return $"[{ID}] Street Address : {StreetAddress}, Postal Code : {PostalCode}, City : {City}, State Province : {StateProvince}, Country ID : {CountryID}";
    }

    public Location SQLReader(SqlDataReader reader)
    {
        return new Location
        {
            ID = reader.GetInt32(0),
            StreetAddress = reader.GetString(1),
            PostalCode = reader.GetString(2),
            City = reader.GetString(3),
            StateProvince = reader.GetString(4),
            CountryID = reader.GetString(5),
        };
    }
}
