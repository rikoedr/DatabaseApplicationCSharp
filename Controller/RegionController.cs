using DBApp.InterfaceAbstract;
using DBApp.Models.Entity;
using DBApp.Util;
using DBApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class RegionController : GeneralDataController<Region>
{
    RegionModel model = new RegionModel();
    RegionView view = new RegionView();
    public RegionController() {
        base.model = this.model;
        base.view = this.view;
    }

    public void GetByID() {
        string input = base.view.InputID();
        int.TryParse(input, out int result);

        base.GetByID(result);
    }

    public override void Insert()
    {
        string name = ApplicationInput.String("Insert Region Name: ");

        view.Transaction(model.Insert(name), "Insert");
    }
}
