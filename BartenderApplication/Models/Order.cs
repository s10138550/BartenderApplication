using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BartenderApplication.Models
{
    public class Order
    {
        private List<OrderLine> lineCollection = new List<OrderLine>();
        public virtual void AddItem(Menu product, int quantity)
        {
            OrderLine line = lineCollection
            .Where(p => p.Product.MenuID == product.MenuID)
            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new OrderLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Menu product) =>
 lineCollection.RemoveAll(l => l.Product.MenuID == product.MenuID);
        public virtual decimal ComputeTotalValue() =>
        lineCollection.Sum(e => e.Product.Price * e.Quantity);
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<OrderLine> Lines => lineCollection;
    }
    public class OrderLine
    {
        public int CartLineID { get; set; }
        public Menu Product { get; set; }
        public int Quantity { get; set; }
    }
}
