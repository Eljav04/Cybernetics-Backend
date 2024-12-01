using Lesson_54_HT.DataAccess;
using Lesson_54_HT.Controller;
using Lesson_54_HT.Services.Messages;
using Lesson_54_HT.Model;

ContactController contactController = new();
DataLogicLayer DLL = new();

//int addContact_ErrorCode = contactController.AddContact();
//if (addContact_ErrorCode.Equals(0))
//{
//    Message.NewContactAdded();
//}
//else
//{
//    Errors.AddContactError(addContact_ErrorCode);
//}


//int showContact_ErrorCode = contactController.ShowContactsBy();
//if (!showContact_ErrorCode.Equals(0))
//{
//    Errors.ShowErrorByErrorCode(showContact_ErrorCode);
//}

int deleteContact_ErrorCode = contactController.DeleteContact();
if (deleteContact_ErrorCode.Equals(0))
{
    Message.ContactDeleted();
}
else
{
    Errors.ShowErrorByErrorCode(deleteContact_ErrorCode);
}



//Console.WriteLine(DLL.GetLastRowID("Contacts"));


Console.ReadLine();