using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Gestion_De_compte
{
    public class AccountManage
    {
        List<UserOptionsMenu> userOptions;
        UserOptionsMenu MainMenu;
        UserOptionsMenu ClientMenu;
        UserOptionsMenu AccountMenu;
        UserOptionsMenu ClientAccountMenu; 

        UserOptionsMenu currentMenu;

        List<Client> clients;
        Client currentClient;
        
        public AccountManage()
        {
            ClientMenu = new UserOptionsMenu(
                "Client Menu",
                new List<unitary_option>()
                {
                    new unitary_option(){option_description = "Prompt 0 to go back to main menu",
                                            action = () => {currentMenu = MainMenu; }
                    },
                    new unitary_option(){option_description = "Prompt 1 to add a client",
                                            action = () => {AddClient(); }
                    }
                }
            );

            AccountMenu = new UserOptionsMenu(
                "Account Menu",
                new List<unitary_option>()
                {
                    new unitary_option(){option_description = "Prompt 0 to go back to main menu",
                                            action = () => {currentMenu = MainMenu; }
                    }
                }
            );

            AccountMenu = new UserOptionsMenu(
                "Account Menu",
                new List<unitary_option>()
                {
                    new unitary_option(){option_description = "Prompt 0 to go back to main menu",
                                            action = () => {currentMenu = MainMenu; }
                    }
                }
            );

            this.MainMenu = new UserOptionsMenu(
                "Main Menu",     
                new List<unitary_option>()
                {
                    new unitary_option(){option_description = "Prompt 0 to exit",
                                            action = () => {ExitApp(); }
                    },
                    new unitary_option(){option_description = "Prompt 1 to manage clients",
                                            action = () => {currentMenu = ClientMenu; }
                    },
                    new unitary_option(){option_description = "Prompt 2 to manage accounts",
                                            action = () => {currentMenu = AccountMenu; }
                    }
                }
            );

            userOptions = new List<UserOptionsMenu>()
            {
                MainMenu,
                AccountMenu,
                ClientMenu
            };
        }


        bool isWorking = true;
        public void StartDoingBankStuff()
        {
            currentMenu = MainMenu;
            while (isWorking)
            {
                string instruction = AskForInstruction();
            }
        }

        private string AskForInstruction()
        {
            bool isValidInstruction = false;
            ShowOptions();
            return " ";
        }

        private void ShowOptions()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to {currentMenu.MenuName}");
            Console.WriteLine();
            Console.WriteLine($"What do you wish to do? Here are {currentMenu.unitary_Options.Count()} options you can choose from");
            currentMenu.unitary_Options.ForEach(uo => Console.WriteLine(uo.option_description));
            Console.WriteLine();
            int index = 1000;

            while(index > currentMenu.unitary_Options.Count() || index < 0)
            {
                Console.WriteLine("Please choose wisely");
                try
                {
                    index = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            currentMenu.unitary_Options[index].action();
        }
        #region Fonctionnalities
        private void ExitApp()
        {
            Console.WriteLine($"Ho you are using a day off, Fine");
            isWorking = false;
        }

        private void AddClient()
        {
            if (clients == null) clients = new List<Client>();

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
                    if (Tools.CheckYesNo()) isStatisfied = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            clients.Add(new Client(firstname, age, name));

            Console.Clear();
            Console.WriteLine("Well done!!!");
            Console.WriteLine("Now do you whish to take a look at this client accounts ?");
            
            if (Tools.CheckYesNo())
            {

            }
        }
        #endregion

        #region data structure
        public class UserOptionsMenu
        {
            public UserOptionsMenu(string MenuName, List<unitary_option> unitary_Options)
            {
                this.MenuName = MenuName;
                this.unitary_Options = unitary_Options;
            }

            public string MenuName;

            public List<unitary_option> unitary_Options = new List<unitary_option>();
        }

        public struct unitary_option
        {
            public string option_description;
            public Action action;
        }
        #endregion
    }
}
