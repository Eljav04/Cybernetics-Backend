using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Registration
{
    public abstract class ProfileController
    {
        public abstract List<Profile> ProfilesData { get; set; }

        // Add user function
        public abstract void AddUser(Profile new_profile);

        // Find User function
        public abstract int FindUserIDbyEmail(string inputEmail);

        // Get User by Id function
        public abstract Profile GetUserById(int id);

        // UpdateById function
        public abstract void UpdateByID(int userID);

      
    }
}
