using System;
using System.Collections.Generic;

namespace Homework11
{
    [Serializable]
    public class Order:IComparable
    {
        public int OrderId { get; set; }
        public string CusName { get; set; }
        public List<Orderitem> Orderitem { get; set; }

        public double SumPrice
        {
            get
            {
                double sum = 0;
                foreach(var temp in Orderitem)
                {
                    sum += temp.UnitPrice * temp.ProductNum;
                }
                return sum;
            }
        }

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

        public override bool Equals(object obj)
        {
            Order m = obj as Order;
            return m != null && m.OrderId == OrderId && m.CusName == CusName;
        }

        public override int GetHashCode()
        {
            return OrderId;
        }

        public override string ToString()
        {
            string OrderDetail = "";
            foreach(var temp in Orderitem)
            {
                OrderDetail = OrderDetail + temp + "\r";
            }
            return $"订单号：{OrderId}, 客户名：{CusName}, 订单总金额：{SumPrice}\n" + OrderDetail;
        }

        public int CompareTo(object obj)
        {
            Order order = obj as Order;
            if(order ==null)
                throw new NotImplementedException();
            return this.OrderId.CompareTo(order.OrderId);
        }
    }
}
