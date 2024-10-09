using System;
using System.Text.RegularExpressions;
using System.Collections;

namespace Lesson_49_HT.Services.AutoIncremnet
{
    internal static class AutoIncrement
    {
        //Patterns
        //Patterns for Name / Surname / Phone number
        public static readonly Dictionary<string, string> CheckPatterns = new(){
            {"Name", @"^[a-zA-Z]+$" },
            {"Surname", @"^[a-zA-Z]+$" },
            {"PhoneNumer",  @"(^\+994(50|51|55|70|99|12|10|77)[0-9]{7}$)|(^0(50|51|55|70|99|12|10|77)[0-9]{7}$)" }
            
};
        public readonly static Regex RE_name = new Regex(CheckPatterns["Name"]);
        public readonly static Regex RE_surname = new Regex(CheckPatterns["Surname"]);
        public readonly static Regex RE_phone_number = new Regex(CheckPatterns["PhoneNumber"]);
        


        // Autoincremented IDs
        private static int contact_id = 1;

        public static int GetUserId() => contact_id++;
    }
}
