using DBApp.Controller;
using DBApp.Entity;

namespace DBApp;

public class Program {
    public static void Main(string[] args) {
        EmployeeDataLinq();
    }

    public static void EmployeeDataLinq()
    {
        List<Region> regions = new RegionRepository().GetAll();
        List<Country> countries = new CountryRepository().GetAll();
        List<Location> locations = new LocationRepository().GetAll();
        List<Department> departments = new DepartmentRepository().GetAll();
        List<Job> jobs = new JobRepository().GetAll();
        List<Employee> employees = new EmployeeRepository().GetAll();

        var resultJoin = regions.Join(countries, r => r.ID, c => c.RegionID, (r, c) => new { r, c })
                                    .Join(locations, rc => rc.c.ID, l => l.CountryID, (rc, l) => new { rc, l })
                                    .Join(departments, rcl => rcl.l.ID, d => d.LocationID, (rcl, d) => new { rcl, d })
                                    .Join(employees, rcld => rcld.d.ID, e => e.DepartmentID, (rcld, e) => 
                                    new EmployeeData
                                    {
                                        ID = e.ID,
                                        FullName = $"{e.FirstName} {e.LastName}",
                                        Email = e.Email,
                                        Salary = e.Salary,
                                        DepartmentName = rcld.d.Name,
                                        StreetAddress = rcld.rcl.l.StreetAddress,
                                        CountryName = rcld.rcl.rc.c.Name,
                                        RegionName = rcld.rcl.rc.r.Name
                                    });

        var groupJoin = from employee in resultJoin
                        group employee by employee.DepartmentName into departmentGroup
                        where departmentGroup.Count() > 3
                        select new
                        {
                            DepartmentName = departmentGroup.Key,
                            DepartmentEmployees = departmentGroup.Count(),
                            MinSalary = departmentGroup.Min(data => data.Salary),
                            MaxSalary = departmentGroup.Max(data => data.Salary),
                            AvgSalary = departmentGroup.Average(data => data.Salary)
                        };
        
        foreach (var item in groupJoin)
        {
            Console.WriteLine($"Department: {item.DepartmentName}, Employees: {item.DepartmentEmployees}, Min Salary: {item.MinSalary}, Max Salary: {item.MaxSalary}, Average Salary : {item.AvgSalary}");
        }

    }

    public class EmployeeData
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public string DepartmentName { get; set; }
        public string StreetAddress { get; set; }
        public string CountryName { get; set; }
        public string RegionName { get; set; }

        public string getString()
        {
            return $"ID: {ID}, Full Name: {FullName}, Email: {Email}, Salary: {Salary}, Department: {DepartmentName}, Street Address: {StreetAddress}, Country : {CountryName}, Region: {RegionName}";
        }

    }
}
