using DBApp.Controller;
using DBApp.Models.Entity;
using DBApp.Util;
using DBApp.View;
using System.Data.SqlClient;
using System.Text;

namespace DBApp;

public class Program {
    CountryController countryController = new CountryController();
    DepartmentController departmentController = new DepartmentController();
    EmployeeController employeeController = new EmployeeController();
    HistoryController historyController = new HistoryController();
    JobController jobController = new JobController();
    LocationController locationController = new LocationController();
    RegionController regionController = new RegionController();

    public static void Main(string[] args) {
        Program application = new Program();

        application.Start();
    }

    public void Start()
    {
        bool isRun = true;

        while (isRun)
        {
            mainMenu();
            string input = ApplicationInput.String("Choose menu : ");

            switch (input)
            {
                case "1":
                    regionController.Menu();
                    break;
                case "2":
                    countryController.Menu();
                    break;
                case "3":
                    locationController.Menu();
                    break;
                case "4":
                    departmentController.Menu();
                    break;
                case "5":
                    jobController.Menu();
                    break;
                case "6":
                    employeeController.Menu();
                    break;
                case "7":
                    historyController.Menu();
                    break;
                case "X":
                    isRun = false;
                    ApplicationInput.Pause();
                    break;
            }

            Console.Clear();
        }
    }

    private void mainMenu()
    {
        Console.WriteLine("HUMAN RESOURCES DATA MANAGER");
        Console.WriteLine("1. Manage Regions");
        Console.WriteLine("2. Manage Countries");
        Console.WriteLine("3. Manage Locations");
        Console.WriteLine("4. Manage Departments");
        Console.WriteLine("5. Manage Jobs");
        Console.WriteLine("6. Manage Employees");
        Console.WriteLine("7. Manage Histories");
        Console.WriteLine("X  Quit Application");
    }


}
