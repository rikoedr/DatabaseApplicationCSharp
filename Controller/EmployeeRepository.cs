using DBApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class EmployeeRepository : Repository<Employee>
{
    public EmployeeRepository()
    {
        base.tableEntity = new Employee();
        base.tableName = "employees";
    }
}
