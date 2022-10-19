using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Gestion_De_compte
{
    public interface IOperation
    {

    }

    public interface ICredit : IOperation
    {
        public abstract void CreditMoney(decimal amount);
    }

    public interface IDebit : IOperation
    {
        public abstract void DebitMoney(decimal amount);
    }
}
