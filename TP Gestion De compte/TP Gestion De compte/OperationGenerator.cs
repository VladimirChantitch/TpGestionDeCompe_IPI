using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Gestion_De_compte
{
    public class OperationGenerator
    {
        public void OperationGen(decimal amount, IDebit debtor, ICredit creditor)
        {
            List<Operation> operations = new List<Operation>()
            {
                new Operation(amount, debtor),
                new Operation(amount, creditor)
            };
            new OperationHandler(operations);
        }

        public void OperationGen(decimal amount, IDebit debtor)
        {
            List<Operation> operations = new List<Operation>()
            {
                new Operation(amount, debtor),
            };
            new OperationHandler(operations);
        }

        public void OperationGen(decimal amount, ICredit creditor)
        {
            List<Operation> operations = new List<Operation>()
            {
                new Operation(amount, creditor)
            };
            new OperationHandler(operations);
        }
    }
}
