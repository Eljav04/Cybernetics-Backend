using System;
using Lesson_60_HT.Models;
using Lesson_60_HT.DAL;
using Microsoft.EntityFrameworkCore;

namespace Lesson_60_HT.Repos
{
	public static class StudentsRepo
	{
		public static List<Student>? GetStudentsEager()
		{
            using (var db = new StudentDBContext())
            {
				List<Student> students = db.StudentsList
					.Include(s => s.StudentSubject)
					.Include(s => s.StudentDetails)
					.ToList();

				return students;
            }
        }

        public static List<Student>? GetStudentsExplict()
        {
            using (var db = new StudentDBContext())
            {
                List<Student> students = db.StudentsList.Where(s => s.Age > 16).ToList();

                foreach(Student student in students)
                {
                    db.Entry(student).Reference(s => s.StudentSubject).Load();
                    db.Entry(student).Reference(s => s.StudentDetails).Load();
                }

                return students;
            }
        }

    }
}

