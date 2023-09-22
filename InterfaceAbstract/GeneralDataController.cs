using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.InterfaceAbstract;

public abstract class GeneralDataController<T> where T : IDataEntity<T>
{
    protected GeneralDataModel<T> model;
    protected GeneralDataView<T> view;
    public void GetAll()
    {
        List<T> results = model.GetAll();

        if (!results.Any()) {
            Console.WriteLine("Data not found");
        }else {
            view.ShowList(results);
        }
    }

    protected void GetByID<U>(U id) {
        T result = model.GetById(id);
        view.ShowData(result);
    }

    public abstract void Insert();




}
