using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Gestion_De_compte
{
    public abstract class AbstractBankAccount : ICredit, IDebit
    {
        Client AccountOwner;
        public AbstractBankAccount(Client client)
        {
            AccountOwner = client;
        }

        List<AccountActivity> accountActivity = new List<AccountActivity>(); 

        public virtual List<AccountActivity> GetAccountActivity()
        {
            if (accountActivity == null) return new List<AccountActivity>();
            else return accountActivity;
        }

        public virtual void CreditMoney(decimal amount)
        {
            accountActivity.Add(new AccountActivity
            {
                operation = typeof(ICredit),
                amount = amount
            });
        }

        public virtual void DebitMoney(decimal amount)
        {
            accountActivity.Add(new AccountActivity
            {
                operation = typeof(IDebit),
                amount = amount
            });
        }

        public abstract decimal CalculateBenefice(decimal amount);

        public abstract decimal CalculateBalance();
    }

    public struct AccountActivity
    {
        public Type operation;
        public decimal amount;
    }
}
