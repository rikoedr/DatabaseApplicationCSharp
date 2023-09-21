using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Entity;

public class History : IEntity<History>
{
    public DateTime StartDate { get; set; }
    public int EmployeeID { get; set; }
    public DateTime EndDate { get; set; }
    public int DepartmentID { get; set; }
    public string JobID { get; set; }


    public History()
    {
        this.StartDate = DateTime.MinValue;
        this.EmployeeID = 0;
        this.EndDate = DateTime.MinValue;
        this.DepartmentID = 0;
        this.JobID = "Empty";
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
