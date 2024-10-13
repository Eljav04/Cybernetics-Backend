using System;

namespace Lesson_50_HT.Services.PasswordGenerator
{
	internal static class PasswordGenerator
	{
        public static int GeneratePassword()
        {
            Random random = new Random();
            int new_password = random.Next(1000, 9999);
            return new_password;
        }
    }
}

