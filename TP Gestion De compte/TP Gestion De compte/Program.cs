using System;

namespace TP_Gestion_De_compte
{
    public class TP_Gestion_De_compte
    {
        static AccountManage accountManage;
        static OperationGenerator opGen;
        static Client newClient;
        public static void Main()
        {
            Console.WriteLine("Nice to see you once more");
            Console.WriteLine();
            Console.WriteLine("                         ");
            Console.WriteLine("    ___            ___   ");
            Console.WriteLine("    | |            | |   ");
            Console.WriteLine("    | |            | |   ");
            Console.WriteLine("    ___            ___   ");
            Console.WriteLine("                         ");
            Console.WriteLine("            ||           ");
            Console.WriteLine("            ||           ");
            Console.WriteLine(@"   \                /   ");
            Console.WriteLine(@"    \              /    ");
            Console.WriteLine(@"     \            /     ");
            Console.WriteLine("       ____________      ");
            Console.WriteLine();

            Console.WriteLine("Do you wish to manage account or do you go on eek end ??");
            Tools.CheckYesNo();
            Console.WriteLine();
            Console.WriteLine("Well write whatever you want lets do some bank stuff");

            accountManage = new AccountManage();
            accountManage.StartDoingBankStuff();

            #region DEbug Zone lmao
            newClient = new Client("paul", 18 ,"roger");
            newClient.AddAccount(new MainAccount(15000, newClient));
            opGen = new OperationGenerator();

            opGen.OperationGen(150000, (newClient.GetAccounts()[0] as ICredit));
            opGen.OperationGen(150, newClient.GetAccounts()[0] as IDebit);
            try
            {
                opGen.OperationGen(15000000, newClient.GetAccounts()[0] as IDebit);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            HandleAccountActivity();
            #endregion
        }

        public static void HandleAccountActivity()
        {
            List<AccountActivity> accountActivities = newClient.GetAccounts()[0].GetAccountActivity();
            accountActivities.ForEach(aa =>
            {
                Console.WriteLine($"{aa.operation.Name} :::::  {aa.amount}");
            });
            Console.WriteLine($"The account balance is {newClient.GetAccounts()[0].CalculateBalance()}");
        }
    }
}