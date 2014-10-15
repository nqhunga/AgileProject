using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Order
    {
        public int CustId { get; set; }
        public int ProdID { get; set; }
        public int Amount { get; set; }
        public string OrderDate { get; set; }
    }
}