using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Gestion_De_compte
{
    public static class Tools
    {
        public static void ExitApp(AccountManage manage)
        {
            Console.WriteLine($"Ho you are using a day off, Fine");
            manage.IsWorking = false;
        }
        public static bool CheckYesNo()
        {
            string truth = " ";
            while (truth != "yes" || truth != "no")
            {
                Console.WriteLine("Yes/No");
                try
                {
                    if ((truth = Console.ReadLine().ToLower()) != null)
                    {
                        if (truth == "yes")
                        {
                            return true;
                        }
                        else if (truth == "no")
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return false;
        }
        public static void AddClient(AccountManage manage)
        {
            if (manage.Clients == null) manage.Clients = new List<Client>();

            bool isStatisfied = false;

            string name = "Smith";
            string firstname = "Tom";
            int age = 18;

            while (!isStatisfied)
            {
                try
                {
                    Console.WriteLine("Client Name");
                    name = Console.ReadLine();
                    Console.WriteLine("Client FirstName");
                    firstname = Console.ReadLine();
                    Console.WriteLine("Client Age");
                    age = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                try
                {
                    Console.Clear();
                    Console.WriteLine($"You Got {name} {firstname} {age}");
                    Console.WriteLine("Are you satisfied?");
                    if (CheckYesNo()) isStatisfied = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Client client = new Client(firstname, age, name);
            manage.Clients.Add(client);

            Console.Clear();
            Console.WriteLine("Well done!!!");
            Console.WriteLine("Now do you whish to take a look at this client accounts ?");

            if (CheckYesNo())
            {
                manage.CurrentClient = client;
                manage.CurrentMenu = manage.clientAccountMenu;
            }
        }
        public static void AddAccount(AccountManage manage, Type type)
        {
            if (manage.CurrentClient != null)
            {
                switch (type.Name)
                {
                    case "MainAccount":

                        break;

                    case "SavingsAccount":

                        break;
                }
            }
            else
            {
                Console.WriteLine("No Client selected");
            }
        }
    }
}
