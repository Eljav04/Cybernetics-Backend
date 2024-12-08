namespace Lesson_56_HT.Models
{
    public class City
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Dictionary<string, string> Advantages { get; set; }

        public City(int id,
            string name,
            string descriptioon,
            Dictionary<string, string> advantages
            ) {
            ID = id;
            Name = name;
            Description = descriptioon;
            Advantages = advantages;
        }
    }
}
