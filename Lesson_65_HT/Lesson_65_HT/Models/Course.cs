namespace Lesson_65_HT.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public byte[]? Image { get; set; }

        public Category? Category { get; set; }
        public int? CategoryID { get; set; }

    }
}
