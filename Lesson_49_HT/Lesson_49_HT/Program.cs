using MyColection.Generic;
using System;
using System.Reflection;
using Lesson_49_HT.Services.Patterns;
using Lesson_49_HT.Model;
using Lesson_49_HT.Controller;
using Lesson_49_HT.Services.Messages;
using System.Text.RegularExpressions;

ContactController contactController = new();

contactController.AddContact(new Contact("Seymur", "Vasifov", "+994508583748"));
contactController.AddContact(new Contact("Rasim", "Tairov", "+994705342305"));
contactController.AddContact(new Contact("Lale", "Resulova", "+994103204567"));

void IntertactionWithContatcs()
{
    bool isContinue = true;

    while (isContinue)
    {


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
                AddContact();
                break;
            case "2":
                EditContact();
                break;
            case "3":
                DeleteContact();
                break;
            case "4":
                contactController.ShowAllInfo();
                Message.EndOfProcess();
                break;
            case "5":
                break;
            case "6":
                isContinue = false;
                break;
            default:
                Errors.NonexistentOptionError();
                break;
        }
    }
}



// 1. AddContact function
void AddContact()
{
    MyList<string> new_contact = contactController.CreateContact();
    if (new_contact.Equals(null))
    {
        Errors.MistakeError();
    }
    else
    {
        contactController.AddContact(
            ContactController.ConvertToContact(new_contact));
        Message.NewContactAdded();
    }
}

// 2. EditContact function
void EditContact()
{
    Console.Clear();
    contactController.ShowAllInfo();

    Console.Write("Enter the id of contact which you want to edit: ");
    dynamic edit_id = Console.ReadLine();
    if (!Patterns.RE_numeric.IsMatch(edit_id))
    {
        Errors.MistakeError();
        return;
    }
    else
    {
        edit_id = Convert.ToInt32(edit_id);
    }

    Contact current_contact = contactController.GetContactByID(edit_id);

    if (current_contact.Equals(null))
    {
        Errors.ContactFindError();
        return;
    }
    Console.Clear();
    current_contact.ShowInfo();
    Console.WriteLine("==========================");
    Console.WriteLine(
    "Which parametr do you want to change:\n" +
    "1.Name\n" +
    "2.Surname\n" +
    "3.Phone Number\n"
    );

    Console.Write("Choose option: ");
    string edit_option = Console.ReadLine();

    Console.Write("Enter new value: ");
    string new_value = Console.ReadLine();

    if (current_contact.Update(new_value, edit_option))
    {
        Message.ContactUpdated();
    }
    else
    {
        Errors.MistakeError();
    };
}

// 3. DeleteContact function
void DeleteContact()
{
    Console.Clear();
    contactController.ShowAllInfo();

    Console.Write("Enter the id of contact which you want to delete: ");
    dynamic delete_id = Console.ReadLine();
    if (!Patterns.RE_numeric.IsMatch(delete_id))
    {
        Errors.MistakeError();
        return;
    }
    else
    {
        delete_id = Convert.ToInt32(delete_id);
    }

    if (contactController.DeleteContact(delete_id))
    {
        Message.ContactDeleted();
    }
    else
    {
        Errors.ContactFindError();
    }
}



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
