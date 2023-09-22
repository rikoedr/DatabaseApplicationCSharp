using DBApp.Models.Entity;
using DBApp.Util;
using DBApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class EmployeeController : AbstractController<Employee>
{
    EmployeeModel model = new EmployeeModel();
    EmployeeView view = new EmployeeView();

    public EmployeeController()
    {
        base.model = this.model;
        base.view = this.view;
    }

    public override void Insert()
    {
        string firstName = ApplicationInput.String("Insert First Name: ");
        string? lastName = ApplicationInput.String("Insert Last Name: ");
        string email = ApplicationInput.String("Insert Email: ");
        string? phoneNumber = ApplicationInput.String("Insert Phone Number: ");
        DateTime hireDate = ApplicationInput.Date("Insert Hire Date: ");
        int salary = ApplicationInput.Integer("Insert Salary: ");
        Decimal? comission = ApplicationInput.DecimalNumber("Insert Comission Percentage: ");
        int managerID = ApplicationInput.Integer("Insert Manager ID: ");
        string jobID = ApplicationInput.String("Insert Job ID: ");
        int departmentID = ApplicationInput.Integer("Insert Department ID: ");

        string transaction = model.Insert(firstName, lastName, email, phoneNumber, hireDate, salary, comission, managerID, jobID, departmentID);

        view.Transaction(transaction, "Insert");
    }

    public override void Update()
    {
        int id = ApplicationInput.Integer("Insert Employee ID: ");
        string firstName = ApplicationInput.String("Insert First Name: ");
        string? lastName = ApplicationInput.String("Insert Last Name: ");
        string email = ApplicationInput.String("Insert Email: ");
        string? phoneNumber = ApplicationInput.String("Insert Phone Number: ");
        DateTime hireDate = ApplicationInput.Date("Insert Hire Date: ");
        int salary = ApplicationInput.Integer("Insert Salary: ");
        Decimal? comission = ApplicationInput.DecimalNumber("Insert Comission Percentage: ");
        int managerID = ApplicationInput.Integer("Insert Manager ID: ");
        string jobID = ApplicationInput.String("Insert Job ID: ");
        int departmentID = ApplicationInput.Integer("Insert Department ID: ");

        string transaction = model.Update(id, firstName, lastName, email, phoneNumber, hireDate, salary, comission, managerID, jobID, departmentID);

        view.Transaction(transaction, "Update");
    }
}
