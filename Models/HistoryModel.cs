﻿using DBApp.Models;
using DBApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class HistoryModel : AbstractModel<History>
{
    public HistoryModel()
    {
        base.dataEntity = new History();
        base.tableName = "histories";
    }

    public string Insert(DateTime startDate, int employeeID, DateTime? endDate, int departmentID, string jobID) {
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("@start_date", startDate));
        parameters.Add(new SqlParameter("@employee_id", employeeID));
        parameters.Add(new SqlParameter("@end_date", endDate));
        parameters.Add(new SqlParameter("@department_id", departmentID));
        parameters.Add(new SqlParameter("@job_id", jobID));

        return base.Insert(parameters);
    }

    public string Update(DateTime startDate, int employeeID, DateTime? endDate, int departmentID, string jobID)
    {
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("@start_date", startDate));
        parameters.Add(new SqlParameter("@employee_id", employeeID));
        parameters.Add(new SqlParameter("@end_date", endDate));
        parameters.Add(new SqlParameter("@department_id", departmentID));
        parameters.Add(new SqlParameter("@job_id", jobID));

        return base.Update(parameters);
    }
}
