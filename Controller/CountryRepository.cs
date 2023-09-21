using DBApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class CountryRepository : Repository<Country> 
{
    public CountryRepository()
    {
        base.tableName = "countries";
        base.tableEntity = new Country();
    }
}
