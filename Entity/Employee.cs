using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Entity;

public class Employee : IEntity<Employee>
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public int Salary { get; set; }
    public Decimal ComissionPCT { get; set; }
    public int ManagerID { get; set; }
    public string JobID { get; set; }
    public int DepartmentID { get; set; }

    public Employee()
    {
        ID = 0;
        FirstName = "Empty";
        LastName = "Empty";
        Email = "Empty";
        PhoneNumber = "Empty";
        HireDate = DateTime.MinValue;
        Salary = 0;
        ComissionPCT = 0;
        ManagerID = 0;
        JobID = "Empty";
        DepartmentID = 0;
    }

    public string getString()
    {
        return $"ID : {ID}, First Name : {FirstName}, Last Name : {LastName}, E-Mail : {Email}, Phone Number : {PhoneNumber}, Hire Date : {HireDate}, Salary : {Salary}, Comission : {ComissionPCT}%, Manager ID : {ManagerID}, Job ID : {JobID}, Department ID : {DepartmentID}";
    }

    public Employee SQLReader(SqlDataReader reader)
    {
        return new Employee
        {
            ID = reader.GetInt32(0),
            FirstName = reader.GetString(1),
            LastName = reader.IsDBNull(2) ? "" : reader.GetString(2),
            Email = reader.IsDBNull(3) ? "" : reader.GetString(3),
            PhoneNumber = reader.IsDBNull(4) ? "" : reader.GetString(4),
            HireDate = reader.GetDateTime(5),
            Salary = reader.GetInt32(6),
            ComissionPCT = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7),
            ManagerID = reader.GetInt32(8),
            JobID = reader.GetString(9),
            DepartmentID = reader.GetInt32(10)
        };
    }
    
}
