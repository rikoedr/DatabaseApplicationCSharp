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
}
