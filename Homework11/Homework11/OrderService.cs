using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Homework11
{
    public class OrderService
    {
        public List<Order> Orders;
        public OrderService(){
            Orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            int newOrderId = 0;
            using (var context = new OrderContext())
            {
                context.Orders.Add(order);
                context.SaveChanges();
                newOrderId = order.OrderId;
            }
            Console.WriteLine("成功添加" + order.ToString());
        }

        public void DeleteOrder(int DelId)
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders.Include("OrderItem").FirstOrDefault(p => p.OrderId == DelId);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
            }
        }

        public IEnumerable SearchById(int id)
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders.Include("Orderitem").SingleOrDefault(b => b.OrderId == id);
                yield return order;
            }
        }

        public IEnumerable SearchByName(string name)
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders.Include("Orderitem").SingleOrDefault(b => b.CusName == name);
                yield return order;
            }
        }

        public void ModifyOrder(int UpdId, Order order)
        {
            try
            {
                DeleteOrder(UpdId);
                AddOrder(order);
            }
            catch(Exception e)
            {
                Console.WriteLine("修改失败，原因："+e.Message);
            }
        }

        public Order GetOrder(int id)
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders.Include("Orderitem").SingleOrDefault(b => b.OrderId == id);
                return order;
            }
        }

        public void Export(String fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using (var context = new OrderContext())
                {
                    var Orders = context.Orders.Include("Orderitem");
                    xs.Serialize(fs, Orders);
                }
            }
        }

        public void Import(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Order> Orders = new List<Order>();
                using (var context = new OrderContext())
                {
                    var order = context.Orders.Include("Orderitem");
                    foreach (var o in order)
                        Orders.Add(o);
                }
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach(order => {
                    if (!Orders.Contains(order))
                    {
                        AddOrder(order);
                    }
                });
            }
        }
    }
}
