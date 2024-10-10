using MyColection.Generic;
using System;
using System.Reflection;
using Lesson_49_HT.Services.Patterns;
using Lesson_49_HT.Model;
using Lesson_49_HT.Controller;
using Lesson_49_HT.Services.Messages;
using System.Text.RegularExpressions;
using Lesson_49_HT.Services;

string path = @"Contacts.txt";

if (!File.Exists(path))
{
    FileStream fileStream = new FileStream(path, FileMode.Create);
    fileStream.Close();
}

ContactController contactController = new(FileServices<Contact>.GetData(path));



//contactController.AddContact(new Contact("Seymur", "Vasifov", "+994508583748"));
//contactController.AddContact(new Contact("Rasim", "Tairov", "+994705342305"));
//contactController.AddContact(new Contact("Lale", "Resulova", "+994103204567"));

IntertactionWithContatcs();
void IntertactionWithContatcs()
{
    bool isContinue = true;

    while (isContinue) {

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
                Console.Clear();
                contactController.ShowAllInfo();
                Message.EndOfProcess();
                break;
            case "5":
                Search();
                break;
            case "6":
                Quit();
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
    if (new_contact is null)
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

    if (current_contact is null)
    {
        Errors.ContactFindError();
        return;
    }
    Console.Clear();
    current_contact.ShowInfo();
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
void Search()
{
    // Variable that can help to determine if could find any contact
    bool isFoundAnyContact = false;
    List<Contact> finded_contatcs = new();

    Console.Clear();
    Console.WriteLine(
        "How do you want to find contact:\n" +
        "1. By ID\n" +
        "2. By Name\n" +
        "3. By Surname\n" +
        "4. By Phone Number\n"
        );
    Console.Write("Choose option: ");
    switch (Console.ReadLine())
    {
        case "1":
            Console.Write("Enter ID: ");
            dynamic search_id = Console.ReadLine();
            if (!Patterns.RE_numeric.IsMatch(search_id))
            {
                Errors.MistakeError();
                return;
            }
            else
            {
                search_id = Convert.ToInt32(search_id);           
            }

            Contact finded_contact = contactController.GetContactByID(search_id);
            if (finded_contact is not null)
            {
                Console.Clear();
                finded_contact.ShowInfo();
                isFoundAnyContact = true;
            }
            break;
        case "2":
            Console.Write("Enter Name: ");
            string? input_name = Console.ReadLine();
            Console.Clear();
            finded_contatcs = contactController.GetContactByName(input_name);
            ContactController.ShowAllInfo(finded_contatcs);
            break;
        case "3":
            Console.Write("Enter Surname: ");
            string? input_surname = Console.ReadLine();
            Console.Clear();
            finded_contatcs = contactController.GetContactBySurname(input_surname);
            ContactController.ShowAllInfo(finded_contatcs);
            break;
        case "4":
            Console.Write("Enter Phone number: ");
            string? input_number = Console.ReadLine();
            Console.Clear();
            finded_contatcs = contactController.GetContactByPhoneNumber(input_number);
            ContactController.ShowAllInfo(finded_contatcs);
            break;
        default:
            Errors.NonexistentOptionError();
            return;
    }
    // If list is empty => no contact is finded
    if (finded_contatcs.Count > 0)
    {
        isFoundAnyContact = true;
    }

    if (!isFoundAnyContact)
    {
        Errors.ContactFindError();
    }
    else
    {
        Message.EndOfProcess();
    }
}

void Quit()
{
    FileServices<Contact>.SaveData(contactController.ContactList.ToList(), path);
}
