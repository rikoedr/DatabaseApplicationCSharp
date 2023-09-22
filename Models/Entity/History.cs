using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Models.Entity;

public class History : IDataEntity<History>
{
    public DateTime StartDate { get; set; }
    public int EmployeeID { get; set; }
    public DateTime EndDate { get; set; }
    public int DepartmentID { get; set; }
    public string JobID { get; set; }


    public History()
    {
        StartDate = DateTime.MinValue;
        EmployeeID = 0;
        EndDate = DateTime.MinValue;
        DepartmentID = 0;
        JobID = "Empty";
    }
    public string getString()
    {
        return $"Start Date : {StartDate}, Employee ID : {EmployeeID}, End Date : {EndDate}, Department ID : {DepartmentID}, Job ID : {JobID}";
    }

    public History SQLReader(SqlDataReader reader)
    {
        return new History
        {
            StartDate = reader.GetDateTime(0),
            EmployeeID = reader.GetInt32(1),
            EndDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2),
            DepartmentID = reader.GetInt32(3),
            JobID = reader.GetString(4)
        };
    }

}
