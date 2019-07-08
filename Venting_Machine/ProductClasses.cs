using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    class Cigar : Iproduct
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public Cigar(string title, double price)
        {
            Title = title;
            Price = price;
            ID = Guid.NewGuid().ToString();
        }
    }
    class Water : Iproduct
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Water(string title, double price)
        {
            Title = title;
            Price = price;
            ID = Guid.NewGuid().ToString();
        }
    }
}
