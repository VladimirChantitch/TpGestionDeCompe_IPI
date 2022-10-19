using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Gestion_De_compte
{
    public class AccountManage
    {
        #region Attributs
        List<UserOptionsMenu> userOptions;
        public List<UserOptionsMenu> UserOptions { get { return userOptions; } set { userOptions = value; } }
        UserOptionsMenu MainMenu;
        public UserOptionsMenu mainMenu { get { return MainMenu; } set { MainMenu = value; } }
        UserOptionsMenu ClientMenu;
        public UserOptionsMenu clientMenu { get { return ClientMenu; } set {ClientMenu = value; } }
        UserOptionsMenu AccountMenu;
        public UserOptionsMenu accountMenu { get { return AccountMenu; } set { AccountMenu = value; } }
        UserOptionsMenu ClientAccountMenu; 
        public UserOptionsMenu clientAccountMenu { get { return ClientAccountMenu; } set { ClientAccountMenu = value; } }

        UserOptionsMenu currentMenu;
        public UserOptionsMenu CurrentMenu { get { return currentMenu; } set { currentMenu = value; } }

        List<Client> clients;
        public List<Client> Clients { get { return clients; } set { clients = value; } }
        Client currentClient;
        public Client CurrentClient { get { return currentClient; } set { currentClient = value; } }

        bool isWorking = true;
        public bool IsWorking { get { return isWorking; } set { isWorking = value; } }
        #endregion

        #region InitMenu
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
                                            action = () => {Tools.AddClient(this); }
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

            ClientAccountMenu = new UserOptionsMenu(
                "Client Account Menu",
                new List<unitary_option>()
                {
                    new unitary_option(){option_description = "Prompt 0 to go back to main menu",
                                            action = () => {currentMenu = MainMenu; currentClient = null; }
                    },
                    new unitary_option(){option_description = "Prompt 1 to add a main account to your client",
                                            action = () => {Tools.AddAccount(this, typeof(MainAccount)); }
                    },
                    new unitary_option(){option_description = "Prompt 2 to add a savings account to your client",
                                            action = () => {Tools.AddAccount(this, typeof(SavingsAccount)); }
                    }
                }
            );

            this.MainMenu = new UserOptionsMenu(
                "Main Menu",     
                new List<unitary_option>()
                {
                    new unitary_option(){option_description = "Prompt 0 to exit",
                                            action = () => {Tools.ExitApp(this); }
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
                ClientMenu,
                ClientAccountMenu
            };
        }
        #endregion

        #region Menu  Loop
        public void StartDoingBankStuff()
        {
            currentMenu = MainMenu;
            while (isWorking)
            {
                AskForInstruction();
            }
        }

        private void AskForInstruction()
        {
            ShowOptions();
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
