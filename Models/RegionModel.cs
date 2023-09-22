using System.Data.SqlClient;
using System.Xml.Linq;
using DBApp.Models.Entity;

namespace DBApp;

public class RegionModel : GeneralDataModel<Region>
{
    public RegionModel()
    {
        base.tableName = "regions";
        base.dataEntity = new Region();
    }

    public string Insert(string name)
    {
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("@name", name));

        return base.Insert(parameters);
    }

    public string Update(int id, string name)
    {
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("@id", id));
        parameters.Add(new SqlParameter("@name", name));

        return base.Update(parameters);
    }
}
