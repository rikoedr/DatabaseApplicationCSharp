using System.Data.SqlClient;

namespace DBApp;

public class RegionRepository : Repository<Region>
{
    public RegionRepository()
    {
        base.tableName = "regions";
        base.tableEntity = new Region();
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
