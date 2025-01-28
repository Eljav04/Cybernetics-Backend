using Udemy.Entity;

namespace Udemy.DAL.Interfaces
{
    public interface ICourseRepository
    {
        public List<Course> GetCourses();
        public List<Course> GetCoursesWithCategories();
        public Course GetCourseById(int id);
        public void AddCourse(Course course);
        public void UpdateCourse(Course course);
        public void DeleteCourse(Course course);
        public List<Course> GetCoursesByCategory(int id);
        public List<Course> GetFeaturedCourses();
    }
}
