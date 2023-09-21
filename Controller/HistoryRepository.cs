using DBApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class HistoryRepository : Repository<History>
{
    public HistoryRepository()
    {
        base.tableEntity = new History();
        base.tableName = "histories";
    }
}
