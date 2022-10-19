using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Gestion_De_compte
{
    public class Client
    {
        string name;
        int age;
        string firstname;

        public Client(string firstname, int age, string name)
        {
            this.firstname = firstname;
            this.age = age;
            this.name = name;
        }

        List<AbstractBankAccount> accounts = new List<AbstractBankAccount>();

        public void AddAccount(AbstractBankAccount bankAccount)
        {
            if (bankAccount != null)
            {
                if (accounts != null)
                {
                    if (!accounts.Contains(bankAccount)) accounts.Add(bankAccount);
                }
            }
        }

        public void RemoveAccount(AbstractBankAccount bankAccount)
        {
            if (bankAccount != null)
            {
                if (accounts != null)
                {
                    if (accounts.Contains(bankAccount)) accounts.Remove(bankAccount);
                }
            }
        }

        public List<AbstractBankAccount> GetAccounts()
        { 
            if (accounts == null) return new List<AbstractBankAccount>();
            else return accounts;
        }
    }
}
