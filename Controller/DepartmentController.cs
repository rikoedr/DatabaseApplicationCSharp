using DBApp.Models.Entity;
using DBApp.Util;
using DBApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class DepartmentController : AbstractController<Department>
{
    DepartmentModel model = new DepartmentModel();
    DepartmentView view = new DepartmentView();
    
    public DepartmentController()
    {
        base.model = this.model;
        base.view = this.view;
    }

    public override void Insert()
    {
        string name = ApplicationInput.String("Insert Name: ");
        int locationID = ApplicationInput.Integer("Insert Location ID: ");
        int managerID = ApplicationInput.Integer("Insert Manager ID: ");

        string transaction = model.Insert(name, locationID, managerID);

        view.Transaction(transaction, "Insert");
    }

    public override void Update()
    {
        int id = ApplicationInput.Integer("Insert Department ID: ");
        string name = ApplicationInput.String("Insert Name: ");
        int locationID = ApplicationInput.Integer("Insert Location ID: ");
        int managerID = ApplicationInput.Integer("Insert Manager ID: ");

        string transaction = model.Update(id, name, locationID, managerID);

        view.Transaction(transaction, "Update");
    }
}
