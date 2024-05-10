using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker
{
    class PeopleFetcher
    {
        // GetEmployees method to manually input data
    static List<Employee> GetEmployees()
{
    List<Employee> employees = new List<Employee>();
    Console.Write("Enter company name (default: CatWorx): ");
    string companyName = Console.ReadLine() ?? "CatWorx";

    while (true)
    {
        Console.WriteLine("Enter first name (leave empty to exit): ");
        string firstName = Console.ReadLine() ?? "";
        if (firstName == "")
        {
            break;
        }

        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine() ?? "";
        Console.Write("Enter ID: ");
        int id = Int32.Parse(Console.ReadLine() ?? "");
        Console.Write("Enter Photo URL (leave empty for default image): ");
        string photoUrl = Console.ReadLine() ?? "";
        if (string.IsNullOrEmpty(photoUrl))
        {
            photoUrl = "https://i.stack.imgur.com/34AD2.jpg"; 
        }
        Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl, companyName);
        employees.Add(currentEmployee);
    }
    return employees;
}


        // GetFromApi method to fetch data from an API
        async public static Task<List<Employee>> GetFromApi()
        {
            List<Employee> employees = new List<Employee>();
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                JObject json = JObject.Parse(response);

                foreach (JToken token in json.SelectToken("results")!)
                {
                    Employee emp = new Employee(
                        token.SelectToken("name.first")!.ToString(),
                        token.SelectToken("name.last")!.ToString(),
                        Int32.Parse(token.SelectToken("id.value")!.ToString().Replace("-", "")),
                        token.SelectToken("picture.large")!.ToString()
                    );
                    employees.Add(emp);
                }
            }
            return employees;
        }

        // New method to choose data source
        public static async Task<List<Employee>> FetchEmployees()
        {
            Console.Write("Do you want to fetch employee data from the API? (yes/no): ");
            string input = Console.ReadLine()?.ToLower() ?? "";

            if (input == "yes")
            {
                return await GetFromApi();
            }
            else
            {
                return GetEmployees();
            }
        }

        // Main method orchestrating everything
        async static Task Main(string[] args)
        {
            List<Employee> employees = await FetchEmployees();
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadges(employees);
        }
    }
}
