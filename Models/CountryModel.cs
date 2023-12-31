﻿using DBApp.Models;
using DBApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class CountryModel : AbstractModel<Country> 
{
    public CountryModel()
    {
        base.tableName = "countries";
        base.dataEntity = new Country();
    }

    public string Insert(string id, string name, int regionID)
    {
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("@id", id));
        parameters.Add(new SqlParameter("@name", name));
        parameters.Add(new SqlParameter("@region_id", regionID));

        return base.Insert(parameters);
    }

    public string Update(string id, string name, int regionID)
    {
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("@id", id));
        parameters.Add(new SqlParameter("@name", name));
        parameters.Add(new SqlParameter("@region_id", regionID));

        return base.Update(parameters);
    }
}
