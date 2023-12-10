using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.VisualBasic.FileIO;

namespace Lab_1_ADO.NET
{
    internal class Methods
    {
        public static void StudentSurnameAscending()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=Lab1;Integrated Security=True;Pooling=False;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("StudentsBySurnameRising", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentId = reader.GetInt32(reader.GetOrdinal("StudentID"));
                            string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                            string lastName = reader.GetString(reader.GetOrdinal("LastName"));

                            Console.WriteLine($"\nStudentID: {studentId}, Name: {firstName}, {lastName}");
                        }
                    }
                }
            }
        }

        public static void StudentSurnameDescending()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=Lab1;Integrated Security=True;Pooling=False;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("StudentsBySurnameFalling", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentId = reader.GetInt32(reader.GetOrdinal("StudentID"));
                            string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                            string lastName = reader.GetString(reader.GetOrdinal("LastName"));

                            Console.WriteLine($"\nStudentID: {studentId}, Name: {firstName}, {lastName}");
                        }
                    }
                }
            }
        }

        public static void StudentFirstNameAscending()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=Lab1;Integrated Security=True;Pooling=False;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("StudentsByFirstNameRising", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentId = reader.GetInt32(reader.GetOrdinal("StudentID"));
                            string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                            string lastName = reader.GetString(reader.GetOrdinal("LastName"));

                            Console.WriteLine($"\nStudentID: {studentId}, Name: {firstName}, {lastName}");
                        }
                    }
                }
            }
        }

        public static void StudentFirstNameDescending()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=Lab1;Integrated Security=True;Pooling=False;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("StudentsByFirstNameFalling", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentId = reader.GetInt32(reader.GetOrdinal("StudentID"));
                            string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                            string lastName = reader.GetString(reader.GetOrdinal("LastName"));

                            Console.WriteLine($"\nStudentID: {studentId}, Name: {firstName}, {lastName}");
                        }
                    }
                }
            }
        }

        public static void GetStudentsByClassName(string input)
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=Lab1;Integrated Security=True;Pooling=False;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetStudentsByClassName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClassName", input);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentId = reader.GetInt32(reader.GetOrdinal("StudentID"));
                            string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                            string lastName = reader.GetString(reader.GetOrdinal("LastName"));

                            Console.WriteLine($"\nStudentID: {studentId}, Name: {firstName}, {lastName}");
                        }
                    }
                }
            }
        }

        public static void ShowAllClasses()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=Lab1;Integrated Security=True;Pooling=False;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT ClassName FROM Classes", conn))
                {
                    cmd.CommandType = CommandType.Text;                  
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            string className = reader.GetString(reader.GetOrdinal("ClassName"));

                            Console.WriteLine($"\nClass Name: {className}");
                        }
                    }
                }
            }
        }

        public static void AddNewStaff()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=Lab1;Integrated Security=True;Pooling=False;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("AddNewStaff", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    Console.WriteLine("List of roles are as follows: \nPrincipal: 1 \nTeacher: 2 \nAdmin: 3");

                    Console.Write("Enter your role:");

                    string strRole = Console.ReadLine();

                    int role = Convert.ToInt32(strRole);

                    Console.Write("Enter your firstname: ");

                    string firstName = Console.ReadLine();

                    Console.Write("Enter your surname: ");

                    string surname = Console.ReadLine();
                                       
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", surname);
                    cmd.Parameters.AddWithValue("@Position", role);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("New staff member added successfully.");

                }
            }
        }

        public static void ShowStaff()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=Lab1;Integrated Security=True;Pooling=False;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                
                Console.WriteLine("Select an option: \n1.) Show all staff \n2.) Show all rectors\n3.) Show all teachers \n4.) Show all admins");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        using (SqlCommand cmd = new SqlCommand("SELECT LastName, FirstName FROM Staff", conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            Console.WriteLine("Showing all staff:");
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                    string lastName = reader.GetString(reader.GetOrdinal("LastName"));

                                    Console.WriteLine($"\nName: {lastName} {firstName}");
                                }
                            }
                        }
                        break;

                    case "2":
                        using (SqlCommand cmd = new SqlCommand("SELECT LastName, FirstName FROM Staff WHERE PositionId = 1", conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            Console.WriteLine("Showing all rectors:");
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                    string lastName = reader.GetString(reader.GetOrdinal("LastName"));

                                    Console.WriteLine($"\nName: {lastName} {firstName}");
                                }
                            }
                        }
                        break;

                    case "3":
                        using (SqlCommand cmd = new SqlCommand("SELECT LastName, FirstName FROM Staff WHERE PositionId = 2", conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            Console.WriteLine("Showing all teachers:");
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                    string lastName = reader.GetString(reader.GetOrdinal("LastName"));

                                    Console.WriteLine($"\nName: {lastName} {firstName}");
                                }
                            }
                        }
                        break;

                    case "4":
                        using (SqlCommand cmd = new SqlCommand("SELECT LastName, FirstName FROM Staff WHERE PositionId = 3", conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            Console.WriteLine("Showing all administrators:");
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                    string lastName = reader.GetString(reader.GetOrdinal("LastName"));

                                    Console.WriteLine($"\nName: {lastName} {firstName}");
                                }
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

                
            }
        }

        public static void ShowLatestGrades()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=Lab1;Integrated Security=True;Pooling=False;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetLatestGrades", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string studentName = reader.GetString(reader.GetOrdinal("StudentName"));
                            string courseName = reader.GetString(reader.GetOrdinal("CourseName"));
                            int gradeValue = reader.GetInt32(reader.GetOrdinal("GradeValue"));
                            DateTime gradeDate = reader.GetDateTime(reader.GetOrdinal("GradeDate"));

                            Console.WriteLine($"\n Student Name: {studentName}, Course Name: {courseName}, Grade: {gradeValue}, Date: {gradeDate.ToShortDateString()}");
                        }
                    }
                }
            }
        }

        public static void GradeStatistics()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=Lab1;Integrated Security=True;Pooling=False;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Courses.CourseName, AVG(Grades.GradeValue) AS AverageGrade, MAX(Grades.GradeValue) AS MaxGrade, MIN(Grades.GradeValue) AS MinGrade FROM Courses LEFT JOIN Grades ON Courses.CourseID = Grades.CourseID GROUP BY     Courses.CourseName;", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string courseName = reader.GetString(reader.GetOrdinal("CourseName"));
                            int averageGrade = reader.GetInt32(reader.GetOrdinal("AverageGrade"));
                            int minGrade = reader.GetInt32(reader.GetOrdinal("MinGrade"));
                            int maxGrade = reader.GetInt32(reader.GetOrdinal("maxGrade"));

                            Console.WriteLine($"\n Course Name: {courseName}, Average Grade: {averageGrade}, Lowest Grade: {minGrade}, Highest Grade: {maxGrade}" );
                        }
                    }
                }
            }
        }

        public static void AddNewStudents() 
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=Lab1;Integrated Security=True;Pooling=False;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("AddNewStudent", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                                      
                    Console.Write("Enter your firstname: ");

                    string firstName = Console.ReadLine();

                    Console.Write("Enter your surname: ");

                    string surname = Console.ReadLine();

                    Console.WriteLine("List of classes are as follows: \nClass 1: 1 \nClass2: 2 \nClass3: 3");

                    Console.Write("Enter new student's class:");

                    int studentClass = Convert.ToInt32(Console.ReadLine());

                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", surname);
                    cmd.Parameters.AddWithValue("@Class", studentClass);
                  
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("New student added successfully.");

                }
            }
        }
    }
}

