using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Gestion_De_compte
{
    public class SavingsAccount : AbstractBankAccount
    {
        decimal interestRate;
        public SavingsAccount(decimal interestRate, Client client) : base(client)
        { 
            this.interestRate = interestRate;
        }

        public override decimal CalculateBalance()
        {
            decimal balance = 0;
            var test = GetAccountActivity();
            GetAccountActivity().ForEach(ac =>
            {
                switch (ac.operation.Name)
                {
                    case "ICredit":
                        balance += ac.amount;
                        break;
                    case "IDebit":
                        balance -= ac.amount;
                        break;
                }
            });
            return balance + CalculateBenefice(balance);
        }

        public override decimal CalculateBenefice(decimal amount)
        {
            return amount * interestRate;
        }

        public override void DebitMoney(decimal amount)
        {
            try
            {
                if (CalculateBalance() - amount < 0)
                {
                    throw (new Exception($"Well there is not enought money on the {this.GetType().ToString()}"));
                }
                else
                {
                    base.DebitMoney(amount);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
