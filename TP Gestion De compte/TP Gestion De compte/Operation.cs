using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Gestion_De_compte
{
    public class Operation
    {
        decimal amount;
        IOperation operation;
        IDebit debit;
        ICredit credit;

        public Operation(decimal amount, IOperation operation)
        {
            this.amount = amount;
            this.operation = operation;
        }
        public Operation(decimal amount, IDebit ops)
        {
            this.amount = amount;
            this.debit = ops;
        }

        public Operation(decimal amount, ICredit ops)
        {
            this.amount = amount;
            this.credit = ops;
        }

        public void LaunchOperation()
        {
            if (credit != null) credit.CreditMoney(amount);
            if (debit != null) debit.DebitMoney(amount);
            if (operation != null) throw (new NotImplementedException());
        }
    }

    public class OperationHandler
    {
        List<Operation> operations = new List<Operation>();

        public OperationHandler(List<Operation> operations)
        {
            this.operations = operations;
            LaunchOperationsSequence();
        }

        private void LaunchOperationsSequence()
        {
            if (operations != null)
            {
                operations.ForEach(ops => ops.LaunchOperation());
            }
        }
    }
}
