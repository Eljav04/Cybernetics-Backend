using Microsoft.EntityFrameworkCore;
using Udemy.DAL.Interfaces;
using Udemy.Entity;

namespace Udemy.DAL
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context) 
        { 
            _context = context;
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();

        }

        public void DeleteCourse(Course course)
        {
            _context.Courses.Remove(course); 
            _context.SaveChanges();
        }

        public Course? GetCourseById(int id) => _context.Courses.Where(c => c.Id == id).FirstOrDefault();        

        public List<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public List<Course> GetCoursesWithCategories()
        {
            return _context.Courses.Include(c => c.Category).ToList();

        }

        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public List<Course> GetCoursesByCategory(int _id)
        {
            return _context.Courses.Where(cr => cr.CategoryId == _id).Include(c => c.Category).ToList();
        }

        public List<Course> GetFeaturedCourses()
        {
            return _context.Courses.OrderByDescending(c => c.Id).Take(3).Include(cr => cr.Category).ToList();
        }
    }
}
