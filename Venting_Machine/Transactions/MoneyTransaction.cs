using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venting_Machine;

namespace Venting_Machine.Transactions
{
    class MoneyTransaction<T>
    {
        public static double TransferMoney(Queue<Iproduct> ProductList , double UserBalance )
        {
            
            return UserBalance -= ProductList.Peek().Price;

        }
    }
}
