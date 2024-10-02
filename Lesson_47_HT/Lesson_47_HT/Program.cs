using Lesson_47_HT;

string password = "1234";
decimal balance = 4.5m;


launch_atm:
Console.Write("Enter your password: ");
string input_passwor = Console.ReadLine();
Console.Clear();
if (input_passwor == password)
{
select_operation:
    Console.Clear();
    Console.WriteLine($"Your balance equal {balance}");
    Console.WriteLine("Choose operation: \n 1 - Cash In \n 2 - Cash Out \n 0 - Cancel");
    string choosen_operation = Console.ReadLine();

    switch (choosen_operation)
    {
        case "1":
            Console.Write("Enter needed amount: ");
            try
            {
                decimal add_amount = MyConvert.ToDecimal(Console.ReadLine());
                balance += add_amount;
            }
            catch(ConvertException exp)
            {
                Console.WriteLine(exp.Message);
                Console.ReadLine();
            }

            Console.Clear();
            goto select_operation;

        case "2":
            Console.Write("Enter needed amount: ");
            try
            {
                decimal take_amount = MyConvert.ToDecimal(Console.ReadLine());
                if (take_amount > balance)
                {
                    Console.Clear();
                    Console.WriteLine("You don't have enough money");
                    Console.ReadKey();

                }
                else
                {
                    balance -= take_amount;
                    Console.Clear();
                }
            }
            catch (ConvertException exp)
            {
                Console.WriteLine(exp.Message);
                Console.ReadLine();
            }

            goto select_operation;

        case "0":
            goto greetings;
        default:
            Console.Clear();
            Console.WriteLine("You choose nonexistant option!");
            Console.ReadKey();
            Console.Clear();
            goto select_operation;
    }
}

else
{
    Console.Clear();
    Console.WriteLine("Your password is incorrect!");
    Console.WriteLine("Try again");
    goto launch_atm;
}

greetings:
Console.Clear();
Console.WriteLine("Thank you for using our bank!");

Console.ReadKey();