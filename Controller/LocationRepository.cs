using DBApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class LocationRepository : Repository<Location>
{
    public LocationRepository()
    {
        base.tableEntity = new Location();
        base.tableName = "locations";
    }
}
