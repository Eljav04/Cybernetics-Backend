using Lesson_54_HT.DataAccess;
using Lesson_54_HT.Controller;
using Lesson_54_HT.Services.Messages;

ContactController contactController = new();


int addContact_ErrorCode = contactController.AddContact();
if (addContact_ErrorCode.Equals(0))
{
    Message.NewContactAdded();
}
else
{
    Errors.AddContactError(addContact_ErrorCode);
}


Console.ReadLine();