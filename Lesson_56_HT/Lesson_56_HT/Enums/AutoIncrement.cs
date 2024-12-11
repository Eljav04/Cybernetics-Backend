namespace Lesson_56_HT.Enums
{
    public static class AutoIncrement
    {
        private static int UserID = 1;
        public static int GetUserID() => UserID++;
    }
}
