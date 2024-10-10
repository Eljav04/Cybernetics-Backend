using System;
using System.Text.RegularExpressions;
using System.Collections;

namespace Lesson_49_HT.Services.AutoIncremnet
{
    internal static class AutoIncrement
    {
        // Autoincremented IDs
        private static int contact_id = 1;

        public static int GetUserId() => contact_id++;
    }
}
