namespace Lesson_65_HT.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Course> Courses { get; set; } = new List<Course>();

    }
}
