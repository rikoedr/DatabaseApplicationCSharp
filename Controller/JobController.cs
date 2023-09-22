using DBApp.Models.Entity;
using DBApp.Util;
using DBApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class JobController : AbstractController<Job>
{
    JobModel model = new JobModel();
    JobView view = new JobView();

    public JobController()
    {
        base.model = this.model;
        base.view = this.view;
    }

    public override void Insert()
    {
        string id = ApplicationInput.String("Insert Job ID: ");
        string title = ApplicationInput.String("Insert Job Title: ");
        int minSalary = ApplicationInput.Integer("Insert Min Salary: ");
        int maxSalary = ApplicationInput.Integer("Insert Max Salary: ");

        string transaction = model.Insert(id, title, minSalary, maxSalary);

        view.Transaction(transaction, "Insert");
    }

    public override void Update()
    {
        string id = ApplicationInput.String("Insert Job ID: ");
        string title = ApplicationInput.String("Insert New Job Title: ");
        int minSalary = ApplicationInput.Integer("Insert New Min Salary: ");
        int maxSalary = ApplicationInput.Integer("Insert New Max Salary: ");

        string transaction = model.Update(id, title, minSalary, maxSalary);

        view.Transaction(transaction, "Update");
    }
}
