using DBApp.Models;
using DBApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class EmployeeModel : AbstractModel<Employee>
{
    public EmployeeModel()
    {
        base.dataEntity = new Employee();
        base.tableName = "employees";
    }

    public string Insert(string firstName, string? lastName, 
                         string email, string? phoneNumber, DateTime hireDate, 
                         int salary, Decimal? comissionPCT, int managerID, 
                         string jobID, int departmentID)
    {
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("@id", base.GetLastRow().ID + 1));
        parameters.Add(new SqlParameter("@first_name", firstName));
        parameters.Add(new SqlParameter("@last_name", lastName));
        parameters.Add(new SqlParameter("@email", email));
        parameters.Add(new SqlParameter("@phone_number", phoneNumber));
        parameters.Add(new SqlParameter("@hire_date", hireDate));
        parameters.Add(new SqlParameter("@salary", salary));
        parameters.Add(new SqlParameter("@comission_pct", comissionPCT));
        parameters.Add(new SqlParameter("@manager_id", managerID));
        parameters.Add(new SqlParameter("@job_id", jobID));
        parameters.Add(new SqlParameter("@department_id", departmentID));

        return base.Insert(parameters);
    }

    public string Update(int id, string firstName, string? lastName,
                         string email, string? phoneNumber, DateTime hireDate,
                         int salary, Decimal? comissionPCT, int managerID,
                         string jobID, int departmentID)
    {
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("@id", id));
        parameters.Add(new SqlParameter("@first_name", firstName));
        parameters.Add(new SqlParameter("@last_name", lastName));
        parameters.Add(new SqlParameter("@email", email));
        parameters.Add(new SqlParameter("@phone_number", phoneNumber));
        parameters.Add(new SqlParameter("@hire_date", hireDate));
        parameters.Add(new SqlParameter("@salary", salary));
        parameters.Add(new SqlParameter("@comission_pct", comissionPCT));
        parameters.Add(new SqlParameter("@manager_id", managerID));
        parameters.Add(new SqlParameter("@job_id", jobID));
        parameters.Add(new SqlParameter("@department_id", departmentID));

        return base.Update(parameters);
    }

    private List<SqlParameter> setParameters(string firstName, string? lastName,
                         string email, string? phoneNumber, DateTime hireDate,
                         int salary, Decimal? comissionPCT, int managerID,
                         string jobID, int departmentID)
    {
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("@id", base.GetLastRow().ID + 1));
        parameters.Add(new SqlParameter("@first_name", firstName));
        parameters.Add(new SqlParameter("@last_name", lastName));
        parameters.Add(new SqlParameter("@email", email));
        parameters.Add(new SqlParameter("@phone_number", phoneNumber));
        parameters.Add(new SqlParameter("@hire_date", hireDate));
        parameters.Add(new SqlParameter("@salary", salary));
        parameters.Add(new SqlParameter("@comission_pct", comissionPCT));
        parameters.Add(new SqlParameter("@manager_id", managerID));
        parameters.Add(new SqlParameter("@job_id", jobID));
        parameters.Add(new SqlParameter("@department_id", departmentID));

        return parameters;
    }
}
