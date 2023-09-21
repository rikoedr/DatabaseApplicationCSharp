using DBApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class DepartmentRepository : Repository<Department>
{
    public DepartmentRepository()
    {
        base.tableEntity = new Department();
        base.tableName = "departments";
    }
}
