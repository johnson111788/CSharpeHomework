using System;

namespace Homework11
{
    [Serializable]
    public class Orderitem
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

        public override bool Equals(object obj)
        {
            Orderitem m = obj as Orderitem;
            return m != null && m.ProductName == ProductName
                && m.ProductNum == ProductNum && m.UnitPrice == UnitPrice;
        }

        public override int GetHashCode()
        {
            return OrderitemId;
        }

        public override string ToString()
        {
            return $"商品名：{ProductName}"+$" 数量：{ProductNum}"+$" 商品单价：{UnitPrice}\n";
        }
    }
}
