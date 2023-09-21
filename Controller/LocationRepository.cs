using DBApp.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class LocationRepository : Repository<Location>
{
    public LocationRepository()
    {
        base.tableEntity = new Location();
        base.tableName = "locations";
    }

    public string Insert(string streetAddress, string postalCode, string city, string stateProvince, string countryID) {
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("@id", base.GetLastRow().ID + 1));
        parameters.Add(new SqlParameter("@street_address", streetAddress));
        parameters.Add(new SqlParameter("@postal_code", postalCode));
        parameters.Add(new SqlParameter("@city", city));
        parameters.Add(new SqlParameter("@state_province", stateProvince));
        parameters.Add(new SqlParameter("@country_id", countryID));

        return base.Insert(parameters);
    }

    public string Update(int id, string streetAddress, string postalCode, string city, string stateProvince, string countryID)
    {
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("@id", id));
        parameters.Add(new SqlParameter("@street_address", streetAddress));
        parameters.Add(new SqlParameter("@postal_code", postalCode));
        parameters.Add(new SqlParameter("@city", city));
        parameters.Add(new SqlParameter("@state_province", stateProvince));
        parameters.Add(new SqlParameter("@country_id", countryID));

        return base.Update(parameters);
    }
}
