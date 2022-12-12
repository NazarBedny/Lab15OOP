using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Lab15OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=DESKTOP-RMR3B82\\SQLEXPRESS;Database=Student_Marks;Trusted_Connection=True;MultipleActiveResultSets=true";
            var choise = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * FROM StudentInfo";

                    SqlDataReader dr = cmd.ExecuteReader();
                    var users = new List<User>();
                    while (choise != "END")
                    {
                        while (dr.Read())
                        {
                            users.Add(new User
                            {
                                AverageMark = int.Parse(dr["AverageMark"].ToString()),
                                FullName = dr["FullName"].ToString(),
                                GroupName = dr["GroupName"].ToString(),
                                LowerMarkSubject = dr["LowerMarkSubject"].ToString(),
                                MaxMarkSubject = dr["MaxMarkSubject"].ToString()

                            });
                            
                        }
                        
                        Console.Write("Enter what you want to see from the listed options: ");
                        Console.WriteLine("All info | Full name | Average marks | Lower mark | Min average mark subject");
                        choise = Console.ReadLine();
                        switch (choise)
                        {
                            case "All info":
                                for (int i = 0; i < users.Count; i++)
                                {
                                    Console.WriteLine("Full name: " + users[i].FullName);
                                    Console.WriteLine("Group: " + users[i].GroupName);
                                    Console.WriteLine("Average mark: " + users[i].AverageMark);
                                    Console.WriteLine("Lowwer mark subj: " + users[i].LowerMarkSubject);
                                    Console.WriteLine("Biggest marksubj: " + users[i].MaxMarkSubject);
                                    Console.WriteLine(new string('-',50));
                                }
                                break;
                            case "Full name":

                                for (int i = 0; i < users.Count; i++)
                                {
                                    Console.WriteLine("Full name: " + users[i].FullName);
                                    Console.WriteLine(new string('-', 50));
                                }
                                break;
                            case "Average marks":
                                for (int i = 0; i < users.Count; i++)
                                {
                                    Console.WriteLine("Full name: " + users[i].FullName + " Average mark: " + users[i].AverageMark);  
                                    Console.WriteLine(new string('-', 50));
                                }
                                break;
                            case "Lower mark":
                                var selectedMark = int.Parse(Console.ReadLine());
                                for (int i = 0; i < users.Count; i++)
                                {
                                    if (users[i].AverageMark> selectedMark)
                                    {
                                        Console.WriteLine("Full name: " + users[i].FullName + " Average mark: " + users[i].AverageMark);
                                        Console.WriteLine(new string('-', 50));
                                    }
                                }
                                break;
                            case "Min average mark subject":
                                for (int i = 0; i < users.Count; i++)
                                {
                                    if (users[i].AverageMark == 2)
                                    {
                                        Console.WriteLine("Full name: " + users[i].FullName + " Average mark: " + users[i].AverageMark + " subject: " + users[i].LowerMarkSubject);
                                        Console.WriteLine(new string('-', 50));
                                    }
                                    
                                }
                                break;
                            case "Min average mark":
                                    Console.WriteLine("Min Average mark is: "+ users.Min(x => x.AverageMark)); 
                                break;
                            case "Max average mark":
                                Console.WriteLine("Max average mark is: " + users.Max(x => x.AverageMark));
                                break;
                            case "Count student who have min average mark":
                                var count = 0;
                                for (int i = 0; i < users.Count; i++)
                                {
                                    if (users[i].AverageMark == 2)
                                    {
                                        count++;
                                    }
                                }
                                Console.WriteLine("Count student who have min average mark: " +count);
                                break;
                            case "Count student who have max average mark":
                                count = 0;
                                for (int i = 0; i < users.Count; i++)
                                {
                                    if (users[i].AverageMark == 5)
                                    {
                                        count++;
                                    }
                                }
                                Console.WriteLine("Count student who have min average mark: " + count);
                                break;
                            case "Min math mark":
                                count = 0;
                                for (int i = 0; i < users.Count; i++)
                                {
                                    if (users[i].AverageMark == 2&& users[i].LowerMarkSubject=="Math")
                                    {
                                        count++;
                                    }
                                }
                                Console.WriteLine("Count min math mark: " + count);
                                break;
                            case "Max math mark":
                                count = 0;
                                for (int i = 0; i < users.Count; i++)
                                {
                                    if (users[i].AverageMark == 5 && users[i].LowerMarkSubject == "Math")
                                    {
                                        count++;
                                    }
                                }
                                Console.WriteLine("Count max math mark: " + count);
                                break;
                            case "Student in one group":
                                var firtsGroup = 0;
                                var secondGroup = 0;
                                for (int i = 0; i < users.Count; i++)
                                {
                                    if (users[i].GroupName=="144")
                                    {
                                        firtsGroup++;
                                    }
                                    else
                                    {
                                        secondGroup++;
                                    }
                                }
                                Console.WriteLine("Count student in 144: " + firtsGroup);
                                Console.WriteLine("Count student in 244: " + secondGroup);
                                break;
                            default:
                                break;
                        }
                    }
                    dr.Close();
                }

            }

        }
    }
}

