using DBApp.Models.Entity;
using DBApp.Util;
using DBApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class HistoryController : AbstractController<History>
{
    HistoryModel model = new HistoryModel();
    HistoryView view = new HistoryView();
    
    public HistoryController()
    {
        base.model = this.model;
        base.view = this.view;
    }

    public override void Insert()
    {
        DateTime startDate = ApplicationInput.Date("Insert Start Date (yyyy-mm-dd): ");
        int employeeID = ApplicationInput.Integer("Insert Employee ID: ");
        DateTime? endDate = ApplicationInput.Date("Insert End Date (yyyy-mm-dd): ");
        int departmentID = ApplicationInput.Integer("Insert Department ID: ");
        string jobID = ApplicationInput.String("Insert Job ID: ");

        string transaction = model.Insert(startDate, employeeID, endDate, departmentID, jobID);

        view.Transaction(transaction, "Insert");
    }

    public override void Update()
    {
        DateTime startDate = ApplicationInput.Date("Insert Start Date (yyyy-mm-dd): ");
        int employeeID = ApplicationInput.Integer("Insert Employee ID: ");
        DateTime? endDate = ApplicationInput.Date("Insert New End Date (yyyy-mm-dd): ");
        int departmentID = ApplicationInput.Integer("Insert New Department ID: ");
        string jobID = ApplicationInput.String("Insert New Job ID: ");

        string transaction = model.Update(startDate, employeeID, endDate, departmentID, jobID);

        view.Transaction(transaction, "Update");
    }
}
