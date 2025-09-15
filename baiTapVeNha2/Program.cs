using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace baiTapVeNha2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Student> stuList = new List<Student>();
            stuList.Add(new Student(2301, "Nguyễn Hoàng Tùng", 20));
            stuList.Add(new Student(2302, "Nguyễn Hoàng Khánh  Vy", 19));
            stuList.Add(new Student(2303, "Nguyễn Hoàng Khánh Huyền", 21));
            stuList.Add(new Student(2304, "Nguyễn Hoàng Thanh Trúc", 17));
            stuList.Add(new Student(2305, "Nguyễn Hoàng Gia Uyên", 10));
            int choice;
            do
            {
                prinmenu();
                Console.WriteLine("Input your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("output information student:  ");
                            foreach (Student student in stuList)
                            {
                                Console.WriteLine("{0,-4} | {1,-40} | {2,2}", student.Id, student.Name, student.Age);
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("output students list aged 15 to 18:  ");
                            var seachAge = stuList.Where(student => student.Age >= 15 && student.Age <= 18);
                            foreach (Student student in seachAge)
                            {
                                Console.WriteLine("{0,-4} | {1,-40} | {2,2}", student.Id, student.Name, student.Age);
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("output stundentList name begin A: ");
                            var beginA = stuList.Where(Student => Student.Name.StartsWith("A"));
                            foreach (Student student in beginA)
                            {
                                Console.WriteLine("{0,-4} | {1,-40} | {2,2}", student.Id, student.Name, student.Age);
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Total age of all students: ");
                            int totalAge = stuList.Sum(student => student.Age);
                            Console.WriteLine(totalAge);
                            break;
                        }
                    case 5:
                        {
                            int maxAge = stuList.Max(student => student.Age);
                            var oldest = stuList.Where(sttuden => sttuden.Age == maxAge);
                            foreach (Student student in oldest)
                            {
                                Console.WriteLine("{0,-4} | {1,-40} | {2,2}", student.Id, student.Name, student.Age);
                            }
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Students sorted by age ascending:  ");
                            var sortAge = stuList.OrderBy(student => student.Age);
                            foreach (Student student in sortAge)
                            {
                                Console.WriteLine("{0,-4} | {1,-40} | {2,2}", student.Id, student.Name, student.Age);
                            }
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Nice to meet you");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice! Please try again.");
                            break;
                        }
                }
            } while (choice != 7);
        }
        private static void Switch(int choice)
        {
            throw new NotImplementedException();
        }

        static void prinmenu()
        {
            Console.WriteLine("Menu management Student");
            Console.WriteLine("1.output information");
            Console.WriteLine("2.Seach and output students aged 15 to 18");
            Console.WriteLine("3.Seach and output stundent name begin A ");
            Console.WriteLine("4.Calculate the total age of all students in the list.");
            Console.WriteLine("5.Find and print the student(s) with the maximum age.");
            Console.WriteLine("6.Sort the student list in ascending order of age and print the list after sorting.");
            Console.WriteLine("7.Exit");
        }
    }
}

