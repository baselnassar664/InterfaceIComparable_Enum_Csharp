using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace assigmnet05_oop
{
    #region 3.	We need to restrict the Gender field to be only M or F [Male or Female] 
    public enum Gender
    {
        Male = 1, Female = 2
    }
    #endregion

    #region 4.	Assign the following security privileges to the employee (guest, Developer, secretary and DBA) in a form of Enum
    [Flags]
    public enum SecurityPrivilages : byte
    {
        Guest = 1,
        Developer = 2,
        Secretary = 4,
        DBA = 8
    }
    #endregion
    internal class Employee:IComparable
    {
      
        private int id;
        private string name;
        private double salary;
        private Gender gender;
        private SecurityPrivilages securityLevel;
        private HiringDate hiringDate;
      

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Salary { get => salary; set => salary = value; }
        public Gender Gender { get => gender; set => gender = value; }
        public SecurityPrivilages Sequrity { get => securityLevel; set => securityLevel = value; }
        public HiringDate Hiring { get => hiringDate; set => hiringDate = value; }
    
       
        public override string ToString()
        {
            return $"Id ={id} \n Name ={name}\n SecurityLevel ={securityLevel} \n Salary ={salary:C}\n HireDate = {hiringDate}\n Gender ={gender}";
        }
       

        //create array of employee take parametr size
        public static Employee[] GetArrEmployee(int size)
        {

            Employee[] employees = new Employee[size];

            for(int i = 0; i < employees.Length;i++)
            {
                employees[i] = new Employee();
            }

            return employees ;
        }

        //insert data into employee
        public static void InsertDataIntoEmployee(Employee[] employee)
        {

            for(int i=0; i < employee.Length;i++)
            {
                Console.WriteLine($"Insert Data Employee: {i+1}");
                Console.Write("-------------------------------");

                bool flag;
                do
                {
                    Console.WriteLine("\nID:");
                    flag = int.TryParse(Console.ReadLine(), out employee[i].id);
                } while (!flag);

                do
                {
                    Console.Write("Name: ");
                    employee[i].name = Console.ReadLine();

                } while (!Regex.IsMatch(employee[i].name, @"^[a-zA-Z]"));

                do
                {
                    Console.Write("Salary:");
                    flag = double.TryParse(Console.ReadLine(), out employee[i].salary);
                } while (!flag);

                int gender;
                do
                {
                    Console.Write("Gender (1 for male , 2 for female) :");
                    flag = int.TryParse(Console.ReadLine(), out gender);

                } while (!(flag && Enum.IsDefined(typeof(Gender), gender)));//check input gender from user is int and 1 or 2 because enum gender contain male=1 or female=2
                employee[i].gender = (Gender)gender;

                int security;
                Console.WriteLine("Hint : guest = 1\n Developer = 2\nsecretary = 4\nDBA = 8");
                do
                {
                    Console.Write("Security Level Number (from 1 to 15) :");
                    flag= int.TryParse(Console.ReadLine(), out security);

                } while (!flag || security>15 || security <1);//check if user input number >15 or number <1 he will return input

                employee[i].securityLevel = (SecurityPrivilages)security;

                int day, month, year;
                Console.WriteLine("Hire Date");

                do
                {
                    Console.Write("Day: ");
                    flag= int.TryParse(Console.ReadLine(), out day);

                } while (!flag || day>31 || day <1);

                do
                {
                    Console.Write("Month: ");
                    flag = int.TryParse(Console.ReadLine(), out month);

                } while (!flag || month > 12 || month < 1);
                do
                {
                    Console.Write("Year: ");
                    flag = int.TryParse(Console.ReadLine(), out year);

                } while (!flag || year > 2023 || year < 2000);

                employee[i].hiringDate=new HiringDate(day, month, year);
   
            }

        }

        //print array

        public static void printArray(Employee[] employees)
        {
            for(int i=0; i<employees.Length; i++)
            {
                Console.WriteLine($"Info Employee {i+1}");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(employees[i]);
                Console.WriteLine("==========================================");

            }

        }

        //sort array by (hiring data)

        public static void sortArray(Employee[] employees)

        {

            Array.Sort(employees);

        }


        //compare hirig date between employee

        public int CompareTo(object? obj)
        {
            Employee employees = (Employee)obj;

            if (Hiring.Year > employees.Hiring.Year) {
                return 1;
            }
            else if (Hiring.Year < employees.Hiring.Year)
            {
                return -1;
            }

            else
            {
                if (Hiring.Month > employees.Hiring.Month)
                {
                    return 1;
                }
                else if (Hiring.Month < employees.Hiring.Month)
                {
                    return -1;
                }

                else {
                    if (Hiring.Day > employees.Hiring.Day)
                    {
                        return 1;
                    }
                    else if (Hiring.Day < employees.Hiring.Day)
                    {
                        return -1;
                    }
                    else
                    {

                        return 0;
                    }
                }

            }


        }

    }
}
