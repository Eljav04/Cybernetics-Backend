using Lesson_54_HT.DataAccess;
using Lesson_54_HT.Controller;
using Lesson_54_HT.Services.Messages;
using Lesson_54_HT.Model;

ContactController contactController = new();
ProfileController profileController = new();
DataLogicLayer DLL = new();





Profile profile = new()
{
    ID = 1,
    Name = "elya",
    PhoneNumber = "3434534",
};

LaunchProgram();

//open_contactsEditor(profile);

void LaunchProgram()
{
    bool is_Continue = true;

    while (is_Continue)
    {
        Console.Clear();
        Console.WriteLine("What do you want to do:\n" +
                    "\t1. Sign Up\n" +
                    "\t2. Sign In\n" +
                    "\t0. Quit\n"
                    );
        Console.Write("Choose option: ");

        switch (Console.ReadLine())
        {
            case "1":
                int SignUp_ErrorCode = profileController.AddProfile();
                if (SignUp_ErrorCode.Equals(0))
                {
                    Message.SignUp();
                }
                else
                {
                    Errors.ShowErrorByErrorCode(SignUp_ErrorCode);
                }
                break;
            case "2":
                (Profile profile, int ErrorCode) SignInResult = profileController.GetProfile();
                int SignIN_ErrorCode = SignInResult.ErrorCode;
                if (SignIN_ErrorCode.Equals(0))
                {
                    open_contactsEditor(SignInResult.profile);
                }
                else
                {
                    Errors.ShowErrorByErrorCode(SignIN_ErrorCode);
                }
                break;

            case "0":
                is_Continue = false;
                return;
            default:
                Errors.NonexistentOptionError();
                return;

        }
    }

}

void open_contactsEditor(Profile profile)
{
    bool is_Continue = true;

    while (is_Continue)
    {
        Console.Clear();
        profile.ShowInfo();

        Console.WriteLine("What do you want to do:\n" +
                    "\t1. Add contact\n" +
                    "\t2. Show all contacts\n" +
                    "\t3. Show contacts by\n" +
                    "\t4. Delete contact\n" +
                    "\t5. Update contact\n\n" +
                    "\t0. Qiit\n"
                    );
        Console.Write("Choose option: ");

        switch (Console.ReadLine())
        {
            case "1":
                int addContact_ErrorCode = contactController.AddContact(profile.ID);
                if (addContact_ErrorCode.Equals(0))
                {
                    Message.NewContactAdded();
                }
                else
                {
                    Errors.ShowErrorByErrorCode(addContact_ErrorCode);
                }
                break;
            case "2":
                contactController.ShowAllContacts(profile.ID);            
                break;
            case "3":
                int showContact_ErrorCode = contactController.ShowContactsBy(profile.ID);
                if (!showContact_ErrorCode.Equals(0))
                {
                    Errors.ShowErrorByErrorCode(showContact_ErrorCode);
                }
                break;
            case "4":
                int deleteContact_ErrorCode = contactController.DeleteContact(profile.ID);
                if (deleteContact_ErrorCode.Equals(0))
                {
                    Message.ContactDeleted();
                }
                else
                {
                    Errors.ShowErrorByErrorCode(deleteContact_ErrorCode);
                }
                break;
            case "5":
                int updateContact_ErrorCode = contactController.UpdateContact(profile.ID);
                if (updateContact_ErrorCode.Equals(0))
                {
                    Message.ContactUpdated();
                }
                else
                {
                    Errors.ShowErrorByErrorCode(updateContact_ErrorCode);
                }
                break;
            case "0":
                is_Continue = false;
                return;
            default:
                Errors.NonexistentOptionError();
                break;
        }
    }
}






