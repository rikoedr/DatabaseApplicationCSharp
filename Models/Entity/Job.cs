using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Models.Entity;

public class Job : IDataEntity<Job>
{
    public string ID { get; set; }
    public string Title { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }

    public Job()
    {
        ID = "Empty";
        Title = "Empty";
        MinSalary = 0;
        MaxSalary = 0;
    }
    public string getString()
    {
        return $"[{ID}] Title : {Title}, Min Salary : {MinSalary}, Max Salary : {MaxSalary}";
    }

    public Job SQLReader(SqlDataReader reader)
    {
        return new Job
        {
            ID = reader.GetString(0),
            Title = reader.GetString(1),
            MinSalary = reader.GetInt32(2),
            MaxSalary = reader.GetInt32(3)
        };
    }
}
