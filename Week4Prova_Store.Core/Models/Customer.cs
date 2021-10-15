using System;
using System.Collections.Generic;
using System.Runtime.Serialization;



namespace Week4Prova_Store.Core.Models
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CustomerCode { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    
        public virtual List<Order> Orders { get; set; } 
        
    }
}
