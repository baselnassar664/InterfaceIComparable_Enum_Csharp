namespace assigmnet05_oop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = Employee.GetArrEmployee(2);
            Employee.InsertDataIntoEmployee(employees);
            Console.Clear();
            Console.WriteLine("Employess Before Sorting:");
            Employee.printArray(employees);
            Console.WriteLine("================================================================ \n \n");
            Console.WriteLine("Employess After Sorting:");
            Employee.sortArray(employees);
            Employee.printArray(employees);

        }
    }
}