using DBApp.Models;
using DBApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class JobModel : AbstractModel<Job>
{
    public JobModel()
    {
        base.dataEntity = new Job();
        base.tableName = "jobs";
    }

    public string Insert(string id, string title, int  minSalary, int maxSalary)
    {
        List<SqlParameter> parameters = setParameters(id, title, minSalary, maxSalary);

        return base.Insert(parameters);
    }

    public string Update(string id, string title, int minSalary, int maxSalary)
    {
        List<SqlParameter> parameters = setParameters(id, title, minSalary, maxSalary);
        
        return base.Update(parameters);
    }

    private List<SqlParameter> setParameters(string id, string title, int minSalary, int maxSalary)
    {
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("@id", id));
        parameters.Add(new SqlParameter("@title", title));
        parameters.Add(new SqlParameter("@min_salary", minSalary));
        parameters.Add(new SqlParameter("@max_salary", maxSalary));

        return parameters;
    }
}
