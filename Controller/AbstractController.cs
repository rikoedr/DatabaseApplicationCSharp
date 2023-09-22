using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBApp.Models;
using DBApp.Util;
using DBApp.View;

namespace DBApp.Controller;

public abstract class AbstractController<T> where T : IDataEntity<T>
{
    protected AbstractModel<T> model;
    protected AbstractView<T> view;
    public void GetAll()
    {
        List<T> results = model.GetAll();

        if (!results.Any())
        {
            Console.WriteLine("Data not found");
        }
        else
        {
            view.ShowList(results);
        }
    }

    public void GetByID() {
        object input = ApplicationInput.Dynamic("Insert ID To Search : ");
        T result = model.GetById(input);

        view.ShowData(result);
    }

    public void Delete() {
        object input = ApplicationInput.Dynamic("Insert ID To Delete : ");
        string result = model.Delete(input);

        view.Transaction(result, "Delete");
    }

}
