using System;
using System.Text.RegularExpressions;
using Lesson_50_HT.Model;
using Lesson_50_HT.Services.Patterns;

namespace Lesson_50_HT.Controller
{
	internal class StudentController
	{
		public List<Student> StudentList { get; set; }



        public StudentController(List<Student> studentList)
		{
            this.StudentList = studentList;
		}

        public void Add(Student new_student)
        {
            StudentList.Add(new_student);
        }

        public bool DeleteByID(int _id)
        {
            foreach (Student student in StudentList)
            {
                if (student.ID == _id)
                {
                    StudentList.Remove(student);
                    return true;
                }
            }
            return false;
        }

        public void ShowAllStudents()
        {
            StudentList.ForEach(s => s.ShowInfo());
        }

        public List<string>? CreateStudent(List<Category> categories_list)
        {
            Console.Clear();
            List<string> new_student = new();
            foreach (string prop in Student.Properties)
            {
                Console.Write($"Enter {prop}: ");
                string? current_value = Console.ReadLine();

                Regex current_regex = new Regex(Patterns.CheckPatterns[prop]);
                if (current_regex.IsMatch(current_value))
                {
                    new_student.Add(current_value);
                }
                else
                {
                    return null;
                };
            }

            Console.Clear();
            categories_list.ForEach(c => Console.WriteLine($"{c.ID} - {c.Name}"));
            Console.Write($"Choose category ID: ");
            dynamic? choosen_category = Console.ReadLine();

            if (Patterns.RE_numeric.IsMatch(choosen_category))
            {
                choosen_category = Convert.ToInt32(choosen_category);

                foreach (Category category in categories_list)
                {
                    if (category.ID == choosen_category)
                    {
                        new_student.Add(choosen_category.ToString());
                        return new_student;
                    }
                }
                return null;
            }
            else
            {
                return null;
            };
  
        }

        public static Student ConvertToStudent(List<string> list)
        {
            return new Student(
                list[0],
                list[1],
                list[2],
                Convert.ToInt32(list[3]));
        }
        public Student? GetStudentByLogin(string login)
        {
            foreach (Student student in StudentList )
            {
                if (student.Login == login)
                {
                    return student;
                }
            }
            return null;
        }

    }
}

