using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Util;

public class ApplicationInput { 
    public static string String(string description) {
        Console.Write(description);
        string input = Console.ReadLine();

        return input;
    }

    public static int Integer(string description) {
        Console.Write(description);
        string input = Console.ReadLine();

        return int.Parse(input);
    }

    public static object Dynamic(string description) {
        Console.Write(description);
        object input = Console.ReadLine();

        return input;
    }

    public static DateTime Date(string description)
    {
        Console.Write(description);
        string input = Console.ReadLine();

        return DateTime.Parse(input);
    }

    public static Decimal DecimalNumber(string description)
    {
        Console.Write(description);
        string input = Console.ReadLine();

        return Decimal.Parse(input);
    }

    public static void Pause()
    {
        Console.Write("Press any key to continue...");
        Console.ReadLine();
    }
}
