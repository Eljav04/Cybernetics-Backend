using System;
using System.Text.RegularExpressions;

namespace Lesson_49_HT.Services.Patterns
{
	public static class Patterns
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
        public readonly static Regex RE_numeric = new Regex(@"^[0-9]+$");

    }
}

