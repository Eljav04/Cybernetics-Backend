using System;
using System.Text.RegularExpressions;

namespace Lesson_50_HT.Services.Patterns
{
    public static class Patterns
    {
        //Patterns
        //Patterns for Name / Surname / Login
        public static readonly Dictionary<string, string> CheckPatterns = new(){
            {"Name", @"^[a-zA-Z]+$" },
            {"Surname", @"^[a-zA-Z]+$" },
            {"Login", @"^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}" },

};
        public readonly static Regex RE_name = new Regex(CheckPatterns["Name"]);
        public readonly static Regex RE_surname = new Regex(CheckPatterns["Surname"]);

        public readonly static Regex RE_numeric = new Regex(@"^[0-9]+$");

    }
}
