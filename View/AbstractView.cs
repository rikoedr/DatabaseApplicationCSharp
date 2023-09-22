using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.View;

public abstract class AbstractView<T> where T : IDataEntity<T>
{
    protected string title;
    public void ShowList(List<T> dataList)
    {
        int counter = 1;
        Console.WriteLine($"Show All {title} :");
        foreach (T data in dataList)
        {
            Console.WriteLine($"[{counter}]{data.getString()}");
            counter += 1;
        }
    }
    public void ShowData(T data)
    {
        Console.WriteLine($"Show {title} :");
        Console.WriteLine($"[1] {data.getString()}");
    }

    public void Transaction(string result, string method)
    {
        int.TryParse(result, out int res);
        if (res > 0)
        {
            Console.Write($"{method} completed successfully");
        }
        else
        {
            Console.Write($"{method} failed. {result}");
        }
    }
    public void Menu()
    {
        Console.WriteLine($"{title.ToUpper()} MENU");
        Console.WriteLine($"1. List of All {title}");
        Console.WriteLine($"2. Get {title} by ID");
        Console.WriteLine($"3. Insert {title}");
        Console.WriteLine($"4. Update {title}");
        Console.WriteLine($"5. Delete {title}");
    }

    public string InputID()
    {
        Console.Write($"Insert {title} ID: ");
        string input = Console.ReadLine();

        return input;
    }
}
