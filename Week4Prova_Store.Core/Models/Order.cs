using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week4Prova_Store.Core.Models
{

    public class Order
    {

        public int Id { get; set; }

        public DateTime OrderDate { get; set; }
 
        public string OrderCode { get; set; }

        public string ProductCode { get; set; }
    
        public decimal Amount { get; set; }
        
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
