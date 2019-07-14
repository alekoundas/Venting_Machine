using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace FrontEnd.Repository
{
    class Repository<T>
    {
        public static T AddToVentingMachine(T Product)
        {
            VentingMachine.Instance.ProductQueue.Enqueue((Iproduct)Product);
            return Product;
        }

        public static void RemoveFromVentingMachine(Queue<Iproduct> ProdQueue, Iproduct ItemToRemove)
        {
            //Backup The Data List type
            Queue<Iproduct> BackupQueue = ProdQueue;

            //Filter ProductQueue In List By Title
            var FilteredQueueListByType = ProdQueue.Where(x => x.Title == ItemToRemove.Title).ToList();
            var FilteredQueueList = ProdQueue.Where(x => x.Title != ItemToRemove.Title).ToList();

            //Reset The ProductQueue...So Rebuild!               
            ProdQueue.Clear();

            //Combine Data From Backup And Filtered And Remove Selected Item
            FilteredQueueListByType.ToList().ForEach(x => ProdQueue.Enqueue(x));
            ProdQueue.Dequeue();
            FilteredQueueList.ToList().ForEach(x => ProdQueue.Enqueue(x));
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
