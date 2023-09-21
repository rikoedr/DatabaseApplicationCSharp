using DBApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class JobRepository : Repository<Job>
{
    public JobRepository()
    {
        base.tableEntity = new Job();
        base.tableName = "jobs";
    }
}
