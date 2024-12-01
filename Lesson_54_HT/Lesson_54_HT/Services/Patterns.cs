using System;
using System.Text.RegularExpressions;

namespace Lesson_54_HT.Services.Patterns
{
    public static class Patterns
    {
        //Patterns
        //Patterns for Name / Surname / Login
        public static readonly Dictionary<string, string> CheckPatterns = new(){
            {"Name", @"^[a-zA-Z]+$" },
            {"Surname", @"^[a-zA-Z]+$" },
            {"Email", @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" },
            {"PhoneNumber",  @"(^\+994(50|51|55|70|99|12|10|77)[0-9]{7}$)|(^0(50|51|55|70|99|12|10|77)[0-9]{7}$)" },

            {"hasNumber", @"[0-9]+"},
            {"hasUpperChar", @"[A-Z]+" },
            {"hasMinimum8Chars",@".{8,}" },

            {"Website", @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$" }

        };
        public readonly static Regex RE_name = new Regex(CheckPatterns["Name"]);
        public readonly static Regex RE_surname = new Regex(CheckPatterns["Surname"]);

        public readonly static Regex RE_phone_number = new Regex(CheckPatterns["PhoneNumber"]);

        public readonly static Regex RE_email = new Regex(CheckPatterns["Email"]);

        // Doesnt used, but may be used in future
        public readonly static Regex RE_website = new Regex(
            CheckPatterns["Website"], RegexOptions.Compiled | RegexOptions.IgnoreCase);


        public readonly static Regex RE_password_hasNumber = new Regex(CheckPatterns["hasNumber"]);
        public readonly static Regex RE_password_hasUpperChar = new Regex(CheckPatterns["hasUpperChar"]);
        public readonly static Regex RE_password_hasMinimum8Chars = new Regex(CheckPatterns["hasMinimum8Chars"]);

        public readonly static Regex RE_numeric = new Regex(@"^[0-9]+$");

        public static bool CheckIsNullable(string check_str)
        {
            if (check_str is null || check_str == "" || check_str == " ")
            {
                return true;
            }
            return false;
        }

        public static readonly Dictionary<string, string> ContactSearchPatterns = new(){
            {"ID", "id = @search_parametr" },
            {"Name", "name = @search_parametr" },
            {"Surname", "surname = @search_parametr" },
            {"Email", "email = @search_parametr"},
            {"Website", "website = @search_parametr"}
        };


    }
}
