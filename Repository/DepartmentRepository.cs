using DBApp.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class DepartmentRepository : Repository<Department>
{
    public DepartmentRepository()
    {
        base.tableEntity = new Department();
        base.tableName = "departments";
    }

    public string Insert(string name, int locationID, int managerID)
    {
        List<SqlParameter> parameters = setParameters(name, locationID, managerID);

        return base.Insert(parameters);
    }
    public string Update(string name, int locationID, int managerID)
    {
        List<SqlParameter> parameters = setParameters(name, locationID, managerID);

        return base.Update(parameters);
    }


    private List<SqlParameter> setParameters(string name, int locationID, int managerID)
    {
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("@id", base.GetLastRow().ID + 1));
        parameters.Add(new SqlParameter("@name", name));
        parameters.Add(new SqlParameter("@location_id", locationID));
        parameters.Add(new SqlParameter("@manager_id", managerID));

        return parameters;
    }

}
