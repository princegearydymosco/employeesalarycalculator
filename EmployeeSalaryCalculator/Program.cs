using System;

public abstract class Employee
{
    public string Id { get; private set; }
    public double HoursWorked { get; set; }
    public double TotalSalary { get; protected set; }

    public abstract void CalculateSalary();

    public void PrintSalary()
    {
        Console.WriteLine($"Employee ID: {Id}");
        Console.WriteLine($"Hours Worked: {HoursWorked}");
        Console.WriteLine($"Total Salary: PHP {TotalSalary}");
    }
}

public class PermanentEmployee : Employee
{
    public override void CalculateSalary()
    {
        double hourlyRate = 750;
        double bonus = HoursWorked > 200 ? 750 : 0;

        TotalSalary = HoursWorked * hourlyRate + bonus;
    }
}

public class HourlyEmployee : Employee
{
    public override void CalculateSalary()
    {
        double hourlyRate = 1000;
        double bonus = HoursWorked > 250 ? 500 : 0;

        TotalSalary = HoursWorked * hourlyRate + bonus;
    }
}

public class Program
{
    static void Main()
    {
        string id = "";

        while (id.Length == 0)
        {
            Console.Write("Enter employee ID: ");
            id = (Console.ReadLine() ?? "").Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Invalid input. Please enter a non-empty employee ID.");
            }
            else if (id[0] != 'P' && id[0] != 'H')
            {
                Console.WriteLine("Invalid input. Employee ID must start with 'P' or 'H'.");
            }
            else
            {
                break;
            }

            id = "";
        }

        Employee employee;
        double hoursWorked;

        if (id.StartsWith("P"))
        {
            employee = new PermanentEmployee();
        }
        else
        {
            employee = new HourlyEmployee();
        }

        Console.Write("Enter hours worked: ");
        while (!double.TryParse(Console.ReadLine(), out hoursWorked))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.Write("Enter hours worked: ");
        }

        employee.HoursWorked = hoursWorked;
        employee.CalculateSalary();
        employee.PrintSalary();
    }
}