using DBApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.View;

public class CountryView : AbstractView<Location>
{
    public CountryView()
    {
        base.title = "Country";
    }
}
