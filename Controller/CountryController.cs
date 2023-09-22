using DBApp.Models.Entity;
using DBApp.Util;
using DBApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class CountryController : AbstractController<Country>
{
    CountryModel model = new CountryModel();
    CountryView view = new CountryView();

    public CountryController()
    {
        base.model = this.model;
        base.view = this.view;
    }

    public override void Insert()
    {
        string id = ApplicationInput.String("Insert Country ID: ");
        string name = ApplicationInput.String("Insert Name: ");
        int regionID = ApplicationInput.Integer("Insert Region ID: ");

        string transaction = model.Insert(id, name, regionID);

        view.Transaction(transaction, "Insert");
    }

    public override void Update()
    {
        string id = ApplicationInput.String("Insert Country ID: ");
        string name = ApplicationInput.String("Insert Name: ");
        int regionID = ApplicationInput.Integer("Insert Region ID: ");

        string transaction = model.Update(id, name, regionID);

        view.Transaction(transaction, "Update");
    }
}
