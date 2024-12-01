using Lesson_54_HT.Model;
using Lesson_54_HT.DataAccess;
using Lesson_54_HT.Services.Patterns;

namespace Lesson_54_HT.Controller
{
	public class ContactController
	{
        private BuisnessLogicLayer BLL;
		public ContactController()
		{
            BLL = new();
		}

		public int AddContact()
		{
			Console.WriteLine("Enter name: ");
			string? name = Console.ReadLine();

            Console.WriteLine("Enter surname | For skip just push enter: ");
            string? surname = Console.ReadLine();

            
            string? phone_number = "";
            List<string> numbers = new();

            while (phone_number != "0")
            {
                Console.WriteLine("Enter phone numbers | " +
                "For stop enter 0");
                phone_number = Console.ReadLine();

                if (phone_number != "" && phone_number != "0")
                {
                    numbers.Add(phone_number);
                }
            }
            

            Console.WriteLine("Enter email | for skip just push enter:");
            string? email = Console.ReadLine();

            Console.WriteLine("Enter website | for skip just push enter:");
            string? website = Console.ReadLine();

            Contacts contact = new()
            {
                Name = name,
                Surname = surname,
                PhoneNumbers = numbers,
                Email = email,
                Website = website
            };

            return BLL.AddContact(contact);
        }

        public void ShowAllContacts()
        {
            BLL.ShowAllContacts();
        }

        private (int ErrorCode, List<Contacts> ContactsList) GetContactsBy()
        {
            Console.WriteLine("Show contacts by:\n" +
                "\t1. ID\n" +
                "\t2. Name\n" +
                "\t3. Surname\n" +
                "\t4. Email\n" +
                "\t5. Website\n" 
                );
            Console.Write("Choose option: ");

            (int ErrorCode, List<Contacts> ContactsList) SearchResults;

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter ID: ");
                    SearchResults = BLL.GetContactsBy("ID", Console.ReadLine());
                    break;
                case "2":
                    Console.Write("Enter Name: ");
                    SearchResults = BLL.GetContactsBy("Name", Console.ReadLine());
                    break;
                case "3":
                    Console.Write("Enter Surname: ");
                    SearchResults = BLL.GetContactsBy("Surname", Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Enter Email: ");
                    SearchResults = BLL.GetContactsBy("Email", Console.ReadLine());
                    break;
                case "5":
                    Console.Write("Enter Website: ");
                    SearchResults = BLL.GetContactsBy("Website", Console.ReadLine());
                    break;

                default:
                    return (10, null);
            }

            return SearchResults;

        }

        public int ShowContactsBy()
        {
            (int ErrorCode, List<Contacts> ContactsList) SearchResults;
            SearchResults = GetContactsBy();

            if (SearchResults.ErrorCode.Equals(0))
            {
                Console.Clear();
                SearchResults.ContactsList.ForEach(c => c.ShowInfo());
            }
            return SearchResults.ErrorCode;
        }

        public int DeleteContact()
        {
            (int ErrorCode, List<Contacts> ContactsList) SearchResults;
            SearchResults = GetContactsBy();

            if (SearchResults.ErrorCode.Equals(0))
            {
                Console.Clear();
                SearchResults.ContactsList.ForEach(c => c.ShowInfo());
            
                Console.Write("Enter ID which of contact do you want to remove: ");
                string? EnteredValue = Console.ReadLine();
                if (!Patterns.RE_numeric.IsMatch(EnteredValue))
                {
                    return 10;
                }

                return BLL.DeleteContact(
                        Convert.ToInt32(EnteredValue),
                        SearchResults.ContactsList);
            }

            return SearchResults.ErrorCode;
        }

        public int UpdateContact()
        {
            (int ErrorCode, List<Contacts> ContactsList) SearchResults;
            SearchResults = GetContactsBy();

            if (SearchResults.ErrorCode.Equals(0))
            {
                Console.Clear();
                SearchResults.ContactsList.ForEach(c => c.ShowInfo());

                dynamic update_id;
                Console.Write("Enter ID which of contact do you want to update: ");
                update_id = Console.ReadLine();
                if (!Patterns.RE_numeric.IsMatch(update_id))
                {
                    return 10;
                }
                update_id = Convert.ToInt32(update_id);

                List<int> DeleteAviliableIDs
                    = SearchResults.ContactsList.Select(c => c.ID).ToList();

                if (!DeleteAviliableIDs.Contains(update_id))
                {
                    return 400;
                }
                Contacts? update_contact =
                    SearchResults.ContactsList.
                    Where(c => c.ID.Equals(update_id)).
                    LastOrDefault();

                Console.Clear();
                Console.WriteLine("What do you want to update:\n" +
                "\t1. Name\n" +
                "\t2. Surname\n" +
                "\t3. Phone number\n" +
                "\t4. Email\n" +
                "\t5. Website\n"
                );
                Console.Write("Choose option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter new Name: ");
                        return BLL.UpdateContact("Name", Console.ReadLine(), update_contact);
                    case "2":
                        Console.Write("Enter new Surname: ");
                        return BLL.UpdateContact("Surname", Console.ReadLine(), update_contact);
                    case "4":
                        Console.Write("Enter new Email: ");
                        return BLL.UpdateContact("Email", Console.ReadLine(), update_contact);
                    case "5":
                        Console.Write("Enter new Website: ");
                        return BLL.UpdateContact("Website", Console.ReadLine(), update_contact);
                    default:
                        return 10;
                }


                return BLL.DeleteContact(
                        Convert.ToInt32(EnteredValue),
                        SearchResults.ContactsList);
            }

            return SearchResults.ErrorCode;
        }


    }
}

        

