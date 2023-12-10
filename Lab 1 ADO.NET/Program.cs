namespace Lab_1_ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the program");
            StartOfProgram:
            Console.WriteLine("1.) Show all students \n2.) Show all students in a specific class \n3.) Add new staff \n4.) Show staff information \n5.) Show latest grades \n6.) Show grade statistics \n7.) Add new students ");
            Console.Write("Please select an action:");
            
            string userInput = Console.ReadLine();
                 
            switch (userInput)
            {
                case "1":
                    
                    Console.WriteLine("Sort names by [1] Surname OR [2] Firstname?");
                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        Console.WriteLine("Sort names by [1] Ascending OR [2] Descending order?");
                        input = Console.ReadLine();
                        if (input == "1")
                        {
                            Methods.StudentSurnameAscending();
                            Console.ReadKey();
                            Console.Clear();
                            goto StartOfProgram;
                        }
                        else if (input == "2")
                        {
                            Methods.StudentSurnameDescending();
                            Console.ReadKey();
                            Console.Clear();
                            goto StartOfProgram;
                        }
                    }

                    else if (input == "2")
                    {
                        if (input == "1")
                        {
                            Console.WriteLine("Sort names by [1] Ascending OR [2] Descending order?");
                            input = Console.ReadLine();
                            if (input == "1")
                            {
                                Methods.StudentSurnameAscending();
                                Console.ReadKey();
                                Console.Clear();
                                goto StartOfProgram;
                            }
                            else if (input == "2")
                            {
                                Methods.StudentSurnameDescending();
                                Console.ReadKey();
                                Console.Clear();
                                goto StartOfProgram;
                            }
                        }
                    }

                    break;
                case "2":
                    Console.WriteLine("All classes in system:");
                    Methods.ShowAllClasses();
                    Console.WriteLine("\nEnter name of class:");
                    input = Console.ReadLine();

                    Methods.GetStudentsByClassName(input);
                    Console.ReadKey();
                    Console.Clear();
                    goto StartOfProgram;
                    
                case "3":

                    Methods.AddNewStaff();
                    Console.ReadKey();
                    Console.Clear();
                    goto StartOfProgram;
                   
                case "4":
                    Methods.ShowStaff();            
                    Console.ReadKey();
                    Console.Clear();
                    goto StartOfProgram;
                case "5":

                    Methods.ShowLatestGrades();
                    Console.ReadKey();
                    Console.Clear();
                    goto StartOfProgram;
                    
                case "6":
                    Methods.GradeStatistics();
                    Console.ReadKey();
                    Console.Clear();
                    goto StartOfProgram;

                case "7":
                    Methods.AddNewStudents();
                    Console.ReadKey();
                    Console.Clear();
                    goto StartOfProgram;
                default:
                    
                    Console.WriteLine("Invalid option");
                    goto StartOfProgram;
                    
            }

        }
    }
}
