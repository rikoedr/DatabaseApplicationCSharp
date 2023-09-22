using DBApp.Models.Entity;
using DBApp.Util;
using DBApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class RegionController : AbstractController<Region>
{
    RegionModel model = new RegionModel();
    RegionView view = new RegionView();
    public RegionController() {
        base.model = this.model;
        base.view = this.view;
    }

    public override void Insert()
    {
        string name = ApplicationInput.String("Insert Region Name: ");
        string transaction = model.Insert(name);

        view.Transaction(transaction, "Insert");
    }

    public override void Update()
    {
        int id = ApplicationInput.Integer("Insert Region ID: ");
        string name = ApplicationInput.String("Insert New Region Name: ");
        string transaction = model.Update(id, name);

        view.Transaction(transaction, "Update");
    }
}
