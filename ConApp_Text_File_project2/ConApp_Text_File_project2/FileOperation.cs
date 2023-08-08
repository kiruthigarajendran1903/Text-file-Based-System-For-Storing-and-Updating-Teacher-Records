using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_file_Based_System_Lib;

namespace ConApp_Text_File_project2
{
    public class FileOperation
    {
        private const string FileName = @"D:\SimpliLearn\Phase End Project\C# Final project\Text-file Based System project 2\Record.txt";
        public void AddTeacher(Teacher teacher)
        {
            using (StreamWriter writer = File.AppendText(FileName))
            {
                writer.WriteLine($"{teacher.ID},{teacher.Name},{teacher.Class},{teacher.Section}");
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            if (File.Exists(FileName))
            {
                foreach (string line in File.ReadAllLines(FileName))
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        teachers.Add(new Teacher
                        {
                            ID = int.Parse(parts[0]),
                            Name = parts[1],
                            Class = parts[2],
                            Section = parts[3]
                        });
                    }
                }
            }
            return teachers;
        }

        public void UpdateTeacher(int id, Teacher updatedTeacher)
        {
            List<string> lines = new List<string>();
            if (File.Exists(FileName))
            {
                foreach (string line in File.ReadAllLines(FileName))
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4 && int.Parse(parts[0]) == id)
                    {
                        lines.Add($"{updatedTeacher.ID},{updatedTeacher.Name},{updatedTeacher.Class},{updatedTeacher.Section}");
                    }
                    else
                    {
                        lines.Add(line);
                    }
                }
                File.WriteAllLines(FileName, lines);
            }
        }
    }
}


