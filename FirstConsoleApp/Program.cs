using FirstConsoleApp.Models;
using System.Text.Json;
using System.Linq;


string filePath = "employees.json";
List<Employee> employees = new List<Employee>();

if (File.Exists(filePath))
{
    string jsonData = File.ReadAllText(filePath);

    if (!string.IsNullOrWhiteSpace(jsonData))
    {
        employees = JsonSerializer.Deserialize<List<Employee>>(jsonData);
    }
}

while (true)
{
    
    Console.WriteLine("\n=== Employee Management ===");
    Console.WriteLine("1. Add Employee");
    Console.WriteLine("2. View Employees");
    Console.WriteLine("3. Delete Employee");
    Console.WriteLine("4. Exit the application");

    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();

    switch(choice)
    {
        case "1":
        {
            Employee emp = new Employee();


            //Below code throws error when value other than numerals is entered, need to add exception handling
            //Console.Write("Enter Id: ");  
            //emp.Id = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Enter Name: ");  
            //emp.name = Convert.ToString(Console.ReadLine());

            int id;
            Console.Write("Enter the Id: ");

                while(!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Invaid input, enter a numeric value:");
                }

            emp.Id = id;


            string Name;

            Console.Write("Enter Name: ");
            Name = Console.ReadLine();

                while(string.IsNullOrWhiteSpace(Name) || Name.Any(char.IsDigit))
                {
                    Console.WriteLine("Invaid input, enter a name:");
                        Name = Console.ReadLine();

                }

                emp.Name = Name;

    
            int Age;
            Console.Write("Enter the Age: ");

                while(!int.TryParse(Console.ReadLine(), out Age))
                {
                    Console.WriteLine("Invaid input, enter Age:");
                }

                 emp.Age = Age;

            double Salary;
            Console.Write("Enter the Salary: ");

                while(!double.TryParse(Console.ReadLine(), out Salary))
                {
                    Console.WriteLine("Invaid input, enter Salary:");
                }

                emp.Salary = Salary;

            employees.Add(emp);

            string updatedJson = JsonSerializer.Serialize(employees);
            File.WriteAllText(filePath,updatedJson);


            Console.WriteLine("Employee Added Successfully");

        break;
        }    
            

        case "2":
        {
            Console.WriteLine("\nEmployee List");

            if(employees.Count == 0)
            {
                Console.WriteLine("No Employees Found");
            }

            else{
            foreach (var employee in employees)
            {
                Console.WriteLine($"Id: {employee.Id}");
                Console.WriteLine($"Name: {employee.Name}");
                Console.WriteLine($"Age: {employee.Age}");
                Console.WriteLine($"Salary:{employee.Salary}");
                Console.WriteLine("-------------------");
             
             }
            }

        break;
        }

            
                
        case "3":
        {                 
        int deleteId;

        Console.Write("Enter Employee Id to delete: ");
        while (!int.TryParse(Console.ReadLine(), out deleteId))
        {
            Console.Write("Invalid input. Enter numeric Id: ");
        }


        Employee employeeToDelete = employees.FirstOrDefault( e => e.Id == deleteId);
        if (employeeToDelete == null)
        {
            Console.WriteLine("Employee not found");
        }

        else
        {
            employees.Remove(employeeToDelete);
            string updatedJson = JsonSerializer.Serialize(employees);
            File.WriteAllText(filePath,updatedJson);
            Console.WriteLine("Employee deleted succesfully");
        }

        break;
        }

        case "4":
        {
            return;
        }

        default:
        Console.WriteLine("Invalid Option");
        break;

    }
 }
