using System;

namespace OrderApi.Models
{    public class Orderitem
    {
        public int OrderitemId { get; set; }

        public string ProductName { get; set; }
        public int ProductNum { get; set; }
        public double UnitPrice { get; set; }

        public int OrderId;
        public Order Order { get; set; }

        public Orderitem(int orderitemid, string productname, int productnum, double unitprice)
        {
            OrderitemId = orderitemid;
            ProductName = productname;
            ProductNum = productnum;
            UnitPrice = unitprice;
        }

        public Orderitem() { }
    }
}