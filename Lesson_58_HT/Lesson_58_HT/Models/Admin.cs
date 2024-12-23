namespace Lesson_58_HT.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Admin(int id, string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;

        }

        public Admin()
        { }

    }
}
