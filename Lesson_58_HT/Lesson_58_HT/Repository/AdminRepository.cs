

using Lesson_58_HT.Models;

namespace Lesson_58_HT.Repository
{
    public static class AdminRepository
    {
        public static List<Admin> AdminList { get; private set; } = new List<Admin>()
        {
            new Admin(1, "e@m.com", "1234"),
            new Admin (2, "admin", "password")
        };

        public static bool CheckExistence(Admin check_admin)
        {
            foreach(Admin admin in AdminList)
            {
                if(admin.Login.Equals(check_admin.Login) && 
                   admin.Password.Equals(check_admin.Password))
                {
                    return true;
                }
            
            }
            return false;
        }


    }
}
