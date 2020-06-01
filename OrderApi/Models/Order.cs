using System;
using System.Collections.Generic;

namespace OrderApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CusName { get; set; }
        public List<Orderitem> Orderitem { get; set; }

        public Order() { }

        public Order(int orderid, string cusname,List<Orderitem> orderItems)
        {
            OrderId = orderid;
            CusName = cusname;
            Orderitem = new List<Orderitem>();
            foreach(var temp in orderItems)
            {
                Orderitem.Add(temp);
            }
        }
    }
}