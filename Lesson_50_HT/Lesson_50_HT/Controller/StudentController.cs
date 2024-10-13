using System;
using Lesson_50_HT.Model;

namespace Lesson_50_HT.Controller
{
	internal class StudentController
	{
		public List<Student> StudentList { get; set; }

        public StudentController()
		{
			StudentList = new();
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
    }
}

