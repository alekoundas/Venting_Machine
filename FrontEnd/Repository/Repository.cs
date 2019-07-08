using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace FrontEnd.Repository
{
    class Repository<T>
    {
        public static T AddToVentingMachine(T Product)
        {
            VentingMachine.Instance.ProductQueue.Enqueue((Iproduct)Product);
            return Product;
        }

        public static void RemoveFromVentingMachine()
        {
            if (VentingMachine.Instance.ProductQueue.Where(x => x.GetType() == typeof(T)).Any())
            {
                //Backup The Data List type
                Queue<Iproduct> BackupQueue = VentingMachine.Instance.ProductQueue;

                //Filter ProductQueue In List type
                var FilteredQueueListByType = VentingMachine.Instance.ProductQueue.Where(x => x.GetType() == typeof(T)).ToList();
                var FilteredQueueList = VentingMachine.Instance.ProductQueue.Where(x => x.GetType() != typeof(T)).ToList();

                //Reset The ProductQueue...So Rebuild!               
                VentingMachine.Instance.ProductQueue.Clear();

                //Combine Data From Backup And Filtered And Remove Selected Item
                FilteredQueueListByType.ToList().ForEach(x=> VentingMachine.Instance.ProductQueue.Enqueue(x));
                VentingMachine.Instance.ProductQueue.Dequeue();
                FilteredQueueList.ToList().ForEach(x=> VentingMachine.Instance.ProductQueue.Enqueue(x));
            }
        }

        public static void RemainingProducts()
        {
            //Make a List Of Diferent Product Title
            List<string> DistinctTitles = VentingMachine.Instance.ProductQueue.ToList().Select(x=>x.Title).Distinct().ToList();
           
            //Print every Product Count
            foreach (var item in DistinctTitles)
            {
                Console.WriteLine("  " + VentingMachine.Instance.ProductQueue.Where(x => x.Title == item).Count() + " Remaining " + item  );
            }
        }
    }
}
