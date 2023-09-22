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

    public abstract void Insert();
    public abstract void Update();

    public void Menu()
    {
        bool isRun = true;
        Console.Clear();

        while(isRun)
        {
            view.Menu();
            string input = ApplicationInput.String("Choose menu : ");

            switch (input)
            {
                case "1":
                    GetAll();
                    ApplicationInput.Pause();
                    break;
                case "2":
                    GetByID();
                    ApplicationInput.Pause();
                    break;
                case "3":
                    Insert();
                    ApplicationInput.Pause();
                    break;
                case "4":
                    Update();
                    ApplicationInput.Pause();
                    break;
                case "5":
                    Delete();
                    ApplicationInput.Pause();
                    break;
                case "B":
                    isRun = false;
                    ApplicationInput.Pause();
                    break;
            }

            Console.Clear();
        }
    }

}
