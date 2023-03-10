using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            var numbersSum = numbers.Sum();
            Console.WriteLine(numbersSum);
            Console.WriteLine("----------");

            //TODO: Print the Average of numbers
            var numersAvg = numbers.Average();
            Console.WriteLine(numersAvg);
            Console.WriteLine("----------");

            //TODO: Order numbers in ascending order and print to the console
            var numAscending = numbers.OrderBy(item => item);

            foreach (var num in numAscending)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("----------");

            //TODO: Order numbers in decsending order and print to the console
            var numDescending = numbers.OrderByDescending(item => item);
            foreach (var num in numDescending)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("----------");

            //TODO: Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(item => item > 6);
            foreach (var num in greaterThanSix)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("----------");

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            //var fourAscending = numbers.Where(item => item > 5);
            //foreach (var num in fourAscending)
            //{
            //    Console.WriteLine(num);
            //}

            foreach (var num in numAscending.Take(4))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("----------");


            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 20;
            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------");

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var employeeCS = employees.Where(employee => employee.FirstName[0] == 'C' || employee.FirstName[0] == 'S')
                .OrderBy(employee => employee.FirstName);

            Console.WriteLine("C or S Employees");
            foreach (var employee in employeeCS)
            {
                Console.WriteLine(employee.FullName);
            }

            Console.WriteLine("----------");

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            //var overTwentySix = employees.Where(employee => employee.Age >= 27);
            //foreach (var employee in overTwentySix)
            //{
            //    Console.WriteLine(employee.Age);
            //    Console.WriteLine(employee.FirstName);
            //}

            var twentySix = employees.Where(employee => employee.Age > 26).OrderByDescending(employee => employee.Age)
                .ThenBy(employee => employee.FirstName);

            
            foreach (var employee in twentySix)
            {
                Console.WriteLine($"{employee.FullName}, {employee.Age}");
            }
            Console.WriteLine("----------");
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            var YOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            Console.WriteLine($"Total YOE: {YOE.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Avg YOE: {YOE.Average(x => x.YearsOfExperience)}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("John", "Doe", 98, 1 )).ToList();

            foreach(var employee in employees)
            {
                Console.Write($"{employee.FirstName} {employee.Age}, ");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
