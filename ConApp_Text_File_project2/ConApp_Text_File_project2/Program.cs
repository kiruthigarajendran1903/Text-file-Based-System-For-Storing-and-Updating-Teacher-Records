using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Text_file_Based_System_Lib;
using System.Runtime.Serialization;


namespace ConApp_Text_File_project2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileOperation manager = new FileOperation();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Teacher Record Management");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. Display All Teachers");
                Console.WriteLine("3. Update Teacher");
                Console.WriteLine("4. Exit");
                Console.WriteLine("---------------------------------");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Teacher ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Teacher Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Teacher Class: ");
                        string classValue = Console.ReadLine();

                        Console.Write("Enter Teacher Section: ");
                        string section = Console.ReadLine();

                        Teacher newTeacher = new Teacher { ID = id, Name = name, Class = classValue, Section = section };
                        manager.AddTeacher(newTeacher);
                        Console.WriteLine("Teacher added successfully.\n\n");
                        break;

                    case 2:
                        var teachers = manager.GetAllTeachers();
                        foreach (var teacher in teachers)
                        {
                            Console.WriteLine($"ID: {teacher.ID}, Name: {teacher.Name}, Class: {teacher.Class}, Section: {teacher.Section}");
                        }
                        break;

                    case 3:
                        Console.Write("Enter Teacher ID to Update: ");
                        int teacherIdToUpdate = int.Parse(Console.ReadLine());

                        Console.Write("Enter Updated Teacher Name: ");
                        string uName = Console.ReadLine();

                        Console.Write("Enter Updated Teacher Class: ");
                        string uClass = Console.ReadLine();

                        Console.Write("Enter Updated Teacher Section: ");
                        string uSection = Console.ReadLine();

                        Teacher updatedTeacher = new Teacher { ID = teacherIdToUpdate, Name = uName, Class = uClass, Section = uSection };
                        manager.UpdateTeacher(teacherIdToUpdate, updatedTeacher);
                        Console.WriteLine("Teacher updated successfully.\n\n");
                        break;

                    case 4:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice!!!!!!");
                        break;
                }

                Console.ReadKey();
            }
        }

    }
}
