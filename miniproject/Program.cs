using System;

class ArrayMin
{
    public static int Min(int[] arr)
    {
        if (arr.Length == 0)
        {
            throw new ArgumentException("Array cannot be empty.");
        }

        int min = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }
        return min;
    }
}

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }

    public Employee(int id, string name, string position, double salary)
    {
        Id = id;
        Name = name;
        Position = position;
        Salary = salary;
    }

    public virtual double CalculateBonus()
    {
        return 50000; // fixed bonus
    }
}

class Developer : Employee
{
    public Developer(int id, string name, double salary) : base(id, name, "Developer", salary) { }

    public override double CalculateBonus()
    {
        double fixedBonus = 50000;
        double percentageBonus = Salary * 0.20; // 20% of salary
        return Math.Max(fixedBonus, percentageBonus);
    }
}

class Manager : Employee
{
    public Manager(int id, string name, double salary) : base(id, name, "Manager", salary) { }

    public override double CalculateBonus()
    {
        double fixedBonus = 50000;
        double percentageBonus = Salary * 0.25; // 25% of salary
        return Math.Max(fixedBonus, percentageBonus);
    }
}

class Admin : Employee
{
    public Admin(int id, string name, double salary) : base(id, name, "Admin", salary) { }
}

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = new int[5];

        Console.WriteLine("Enter 5 numbers:");

        for (int i = 0; i < numbers.Length; i++)
        {
            bool validInput = false;
            int number;

            do
            {
                Console.Write($"Number {i + 1}: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            } while (!validInput);

            numbers[i] = number;
        }

        int minValue = ArrayMin.Min(numbers);
        Console.WriteLine($"Minimum value in the array: {minValue}");

        Console.WriteLine("Adding a new employee as a Developer:");
        Developer developer = AddDeveloper();
        DisplayEmployeeInfo(developer);

        Console.WriteLine("Adding a new employee as a Manager:");
        Manager manager = AddManager();
        DisplayEmployeeInfo(manager);

        Console.WriteLine("Adding a new employee as an Admin:");
        Admin admin = AddAdmin();
        DisplayEmployeeInfo(admin);
    }

    static Developer AddDeveloper()
    {
        Console.Write("Enter Developer ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Enter Developer Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Developer Salary: ");
        double salary = double.Parse(Console.ReadLine());
        return new Developer(id, name, salary);
    }

    static Manager AddManager()
    {
        Console.Write("Enter Manager ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Enter Manager Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Manager Salary: ");
        double salary = double.Parse(Console.ReadLine());
        return new Manager(id, name, salary);
    }

    static Admin AddAdmin()
    {
        Console.Write("Enter Admin ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Enter Admin Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Admin Salary: ");
        double salary = double.Parse(Console.ReadLine());
        return new Admin(id, name, salary);
    }

    static void DisplayEmployeeInfo(Employee employee)
    {
        Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Position: {employee.Position}, Salary: {employee.Salary}, Bonus: {employee.CalculateBonus()}");
    }
}
