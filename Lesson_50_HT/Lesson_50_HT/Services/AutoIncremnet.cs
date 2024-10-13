using System;
namespace Lesson_50_HT.Services.AutoIncrement
{
    internal static class AutoIncrement
    {
        // Autoincremented IDs
        private static int student_id = 1;
        private static int admin_id = 1;
        private static int queston_id = 1;

        public static int GetStudentID() => student_id++;
        public static int GetAdminID() => admin_id++;
        public static int GetQuestionID() => queston_id++;
    }
}

