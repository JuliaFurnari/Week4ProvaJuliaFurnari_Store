using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Prova_Store.Client.Contracts
{
    public class OrderContract
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderCode { get; set; }

        public string ProductCode { get; set; }

        public decimal Amount { get; set; }
        public int CustomerId { get; set; }
    }
}
