﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Models.Entity;

public class Department : IDataEntity<Department>
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int LocationID { get; set; }
    public int ManagerID { get; set; }

    public Department()
    {
        ID = 0;
        Name = "Empty";
        LocationID = 0;
        ManagerID = 0;
    }
    public string getString()
    {
        return $"[{ID}] Name : {Name}, Location ID : {LocationID}, Manager ID : {ManagerID}";
    }

    public Department SQLReader(SqlDataReader reader)
    {
        return new Department
        {
            ID = reader.GetInt32(0),
            Name = reader.GetString(1),
            LocationID = reader.GetInt32(2),
            ManagerID = reader.GetInt32(3)
        };
    }

}