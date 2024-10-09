using MyColection.Generic;

using System;
using System.Reflection;
using System.Text.RegularExpressions;

string[][] ContactsData = new string[4][];

ContactsData[0] = new string[3] { "Name", "Surname", "Number" };
ContactsData[1] = new string[3] { "Seymur", "Vasifov", "+994508583748" };
ContactsData[2] = new string[3] { "Rasim", "Tairov", "+994705342305" };
ContactsData[3] = new string[3] { "Lale", "Resulova", "+994103204567" };

//Patterns for Name / Surname / Phone number
string[] CheckPatterns = {
    @"^[a-zA-Z]+$",
    @"^[a-zA-Z]+$",
    @"(^\+994(50|51|55|70|99|12|10|77)[0-9]{7}$)|(^0(50|51|55|70|99|12|10|77)[0-9]{7}$)"
};

intertactionWithContatcs:
Console.Clear();
Console.WriteLine(
    "1.Add contact\n" +
    "2.Edit contact\n" +
    "3.Delete contact\n" +
    "4.Show all contacts\n" +
    "5.Search\n" +
    "6.Quit\n"
    );
Console.Write("Choose option: ");
switch (Convert.ToString(Console.ReadLine()))
{
    case "1":
        goto AddContact;
    case "2":
        goto EditContact;
    case "3":
        goto DeleteContact;
    case "4":
        goto ShowAllContacts;
    case "5":
        goto Search;
    case "6":
        goto Quit;
    default:
        goto NonexistentOptionError;
}

// 1. AddContact function
AddContact:
Console.Clear();
string[] new_contact = new string[3];
for (int i = 0; i < 3; i++)
{
    Console.Write($"Enter {ContactsData[0][i]}: ");
    string current_value = Convert.ToString(Console.ReadLine());

    Regex regex = new Regex(CheckPatterns[i]);
    if (regex.IsMatch(current_value))
    {
        new_contact[i] = current_value;
    }
    else
    {
        goto MistakeError;
    };
};
ContactsData = ContactsData.Append(new_contact).ToArray();
Console.Clear();
Console.WriteLine("Required contact added successfully");
Console.WriteLine("Push any key to continue...");
Console.ReadKey();
goto intertactionWithContatcs;

// 2. EditContact function
EditContact:
Console.Clear();
for (int i = 1; i < ContactsData.Length; i++)
{
    Console.WriteLine($"Contact_ID: {i}");
    for (int j = 0; j < ContactsData[i].Length; j++)
    {
        Console.WriteLine(
            $"{ContactsData[0][j]}: {ContactsData[i][j]}"
            );
    };
    Console.WriteLine("==========================");
};
Console.Write("Enter the id of contact which you want to edit: ");
int edit_id = Convert.ToInt32(Console.ReadLine());
if ((edit_id < ContactsData.Length) && edit_id != 0)
{
    Console.Clear();
    Console.WriteLine($"Contact_ID: {edit_id}");
    for (int j = 0; j < ContactsData[edit_id].Length; j++)
    {
        Console.WriteLine(
            $"{ContactsData[0][j]}: {ContactsData[edit_id][j]}"
            );
    };
    Console.WriteLine("==========================");
    Console.WriteLine(
    "Which parametr do you want to change:\n" +
    "1.Name\n" +
    "2.Surname\n" +
    "3.Phone Number\n"
    );
    Console.Write("Choose option: ");
    const string StringToSeek = "123";
    string edit_option = Console.ReadLine();
    if (StringToSeek.Contains(edit_option))
    {
        int edit_prop_index = int.Parse(edit_option) - 1;
        Console.Write($"Enter new {ContactsData[0][edit_prop_index]}: ");
        string new_propererty = Console.ReadLine();

        // Checks mistakes in new property
        Regex regex = new Regex(CheckPatterns[edit_prop_index]);
        if (regex.IsMatch(new_propererty))
        {
            ContactsData[edit_id][edit_prop_index] = new_propererty;
            Console.Clear();
            Console.WriteLine("Required contact successfully changed");
            Console.WriteLine("Push any key to continue...");
            Console.ReadKey();
            goto intertactionWithContatcs;
        }
        else
        {
            goto MistakeError;
        };
    }
    else
    {
        goto NonexistentOptionError;
    }

}
else
{
    goto ContactFindError;
}

// 3. DeleteContact function
DeleteContact:
Console.Clear();
for (int i = 1; i < ContactsData.Length; i++)
{
    Console.WriteLine($"Contact_ID: {i}");
    for (int j = 0; j < ContactsData[i].Length; j++)
    {
        Console.WriteLine(
            $"{ContactsData[0][j]}: {ContactsData[i][j]}"
            );
    };
    Console.WriteLine("==========================");
};
Console.Write("Enter the id of contact which you want to delete: ");
int enter_id = Convert.ToInt32(Console.ReadLine());
if ((enter_id < ContactsData.Length) && enter_id != 0)
{
    for (int a = enter_id; a < ContactsData.Length - 1; a++)
    {
        // moving elements downwards, to fill the gap at [index]
        ContactsData[a] = ContactsData[a + 1];
    }
    // decrement Array's size by one
    Array.Resize(ref ContactsData, ContactsData.Length - 1);
    Console.Clear();
    Console.WriteLine("Required contact successfully deleted");
    Console.WriteLine("Push any key to continue...");
    Console.ReadKey();
    goto intertactionWithContatcs;
}
else
{
    goto ContactFindError;
}



// 4. ShowAllContacts function
ShowAllContacts:
Console.Clear();
for (int i = 1; i < ContactsData.Length; i++)
{
    Console.WriteLine($"Contact_ID: {i}");
    for (int j = 0; j < ContactsData[i].Length; j++)
    {
        Console.WriteLine(
            $"{ContactsData[0][j]}: {ContactsData[i][j]}"
            );
    };
    Console.WriteLine("==========================");
};
Console.WriteLine("Push any key to continue...");
Console.ReadKey();
goto intertactionWithContatcs;

// 5. Search function
Search:

// Variable that can help to determine if could find any contact
bool isFoundAnyContact = false;

Console.Clear();
Console.WriteLine(
    "How do you want to find contact:\n" +
    "1. By ID\n" +
    "2. By Name\n" +
    "3. By Surname\n" +
    "4. By Phone Number\n"
    );
Console.Write("Choose option: ");
switch (Convert.ToString(Console.ReadLine()))
{
    case "1":
        Console.Write("Enter ID: ");
        int input_id = Convert.ToInt32(Console.ReadLine());
        if (input_id < ContactsData.Length)
        {
            Console.Clear();
            Console.WriteLine($"Contact_ID: {input_id}");
            for (int i = 0; i < ContactsData[input_id].Length; i++)
            {
                Console.WriteLine(
                    $"{ContactsData[0][i]}: {ContactsData[input_id][i]}"
                    );
            };
            Console.ReadKey();
        }
        else
        {
            goto ContactFindError;
        };
        goto intertactionWithContatcs;
    case "2":
        Console.Write("Enter Name: ");
        string input_name = Convert.ToString(Console.ReadLine()).ToLower();
        Console.Clear();
        for (int i = 1; i < ContactsData.Length; i++)
        {
            if (ContactsData[i][0].ToLower() == input_name)
            {
                Console.WriteLine($"Contact_ID: {i}");
                for (int j = 0; j < ContactsData[i].Length; j++)
                {
                    Console.WriteLine(
                        $"{ContactsData[0][j]}: {ContactsData[i][j]}"
                        );
                };
                Console.WriteLine("==========================");
                isFoundAnyContact = true;
            }
        };
        break;
    case "3":
        Console.Write("Enter Surname: ");
        string input_surname = Convert.ToString(Console.ReadLine()).ToLower();
        Console.Clear();
        for (int i = 1; i < ContactsData.Length; i++)
        {
            if (ContactsData[i][1].ToLower() == input_surname)
            {
                Console.WriteLine($"Contact_ID: {i}");
                for (int j = 0; j < ContactsData[i].Length; j++)
                {
                    Console.WriteLine(
                        $"{ContactsData[0][j]}: {ContactsData[i][j]}"
                        );
                };
                Console.WriteLine("==========================");
                isFoundAnyContact = true;
            }
        };
        break;
    case "4":
        Console.Write("Enter Phone Number: ");
        string input_number = Convert.ToString(Console.ReadLine());
        Console.Clear();
        for (int i = 1; i < ContactsData.Length; i++)
        {
            if (ContactsData[i][2] == input_number)
            {
                Console.WriteLine($"Contact_ID: {i}");
                for (int j = 0; j < ContactsData[i].Length; j++)
                {
                    Console.WriteLine(
                        $"{ContactsData[0][j]}: {ContactsData[i][j]}"
                        );
                };
                Console.WriteLine("==========================");
                isFoundAnyContact = true;
            }
        };
        break;
    default:
        goto NonexistentOptionError;
}

if (!isFoundAnyContact)
{
    goto ContactFindError;
}

Console.ReadKey();
goto intertactionWithContatcs;

// Show mistake error and interrupt implementing a process
MistakeError:
Console.Clear();
Console.WriteLine("You have a mistake! Please try again");
Console.ReadKey();
goto intertactionWithContatcs;

// Show that choosen option is nonexistent and interrupt implementing a process
NonexistentOptionError:
Console.Clear();
Console.WriteLine(
    "You chose nonexistent option\n" +
    "Try again!"
    );
Console.ReadKey();
Console.Clear();
goto intertactionWithContatcs;

// Show that required contact сouldn't find in Contact list
ContactFindError:
Console.Clear();
Console.WriteLine(
    "Couldn't find the required contact\n" +
    "Try again!"
    );
Console.ReadKey();
Console.Clear();
goto intertactionWithContatcs;

// 6. Quit function
Quit:
Console.Clear();