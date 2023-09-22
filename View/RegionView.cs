using DBApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.View;

public class RegionView : AbstractView<Region>
{
    public RegionView()
    {
        base.title = "Region";
    }
}
