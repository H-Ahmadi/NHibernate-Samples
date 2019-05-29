using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CollectionOfValueObjects.Model
{
    public class Order
    {
        private IList<OrderItem> items;
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public DateTime CreateDate { get; set; }
        public IReadOnlyCollection<OrderItem> Items=> new ReadOnlyCollection<OrderItem>(items);
        public Order()
        {
            this.items = new List<OrderItem>();    
        }
        public void AssignItems(List<OrderItem> items)
        {
            var added = items.Except(this.items).ToList();
            var deleted = this.items.Except(items).ToList();

            added.ForEach(a=> this.items.Add(a));
            deleted.ForEach(a=> this.items.Remove(a));
        }
    }
}       
