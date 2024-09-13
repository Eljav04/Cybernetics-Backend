using Lesson_43_HT;
using System.Collections;

ProfileController PC = new();

ArrayList new_profile = new();


PC.CreateProfile(ref new_profile);
Profile prof = PC.ConvertToProfile(new_profile);
PC.AddUser(prof);
PC.ShowAllProfilesInfo();   
