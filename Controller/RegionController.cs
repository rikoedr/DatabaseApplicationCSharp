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


}
