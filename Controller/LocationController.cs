using DBApp.Models.Entity;
using DBApp.Util;
using DBApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Controller;

public class LocationController : AbstractController<Location>
{
    LocationModel model = new LocationModel();
    LocationView view = new LocationView();
    public LocationController()
    {
        base.model = this.model;
        base.view = this.view;
    }

    public override void Insert()
    {
        string streetAddress = ApplicationInput.String("Insert Street Address: ");
        string postalCode = ApplicationInput.String("Insert Postal Code: ");
        string city = ApplicationInput.String("Insert Postal City: ");
        string stateProvince = ApplicationInput.String("Insert State Province: ");
        string countryID = ApplicationInput.String("Insert Postal Country ID: ");

        string transaction = model.Insert(streetAddress, postalCode, city, stateProvince, countryID);

        view.Transaction(transaction, "Insert");
    }

    public override void Update()
    {
        int id = ApplicationInput.Integer("Insert Location ID: ");
        string streetAddress = ApplicationInput.String("Insert Street Address: ");
        string postalCode = ApplicationInput.String("Insert Postal Code: ");
        string city = ApplicationInput.String("Insert Postal City: ");
        string stateProvince = ApplicationInput.String("Insert State Province: ");
        string countryID = ApplicationInput.String("Insert Postal Country ID: ");

        string transaction = model.Update(id, streetAddress, postalCode, city, stateProvince, countryID);

        view.Transaction(transaction, "Update");
    }
}
