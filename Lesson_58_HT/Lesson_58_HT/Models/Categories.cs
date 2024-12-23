namespace Lesson_58_HT.Models
{
    public class Categories
    {
        public int ID { get; set; }
        public string? Name { get; set; }

        public Categories() { }
        public Categories(int id, string name) {
            this.ID = id;
            this.Name = name;
        }




    }
}
