using System;
using System.Collections.Generic;

namespace testdbfirst.Models
{
    public partial class CustomerOrders
    {
        public CustomerOrders()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public string OrderStatusCode { get; set; }
        public string ShippingMethodCode { get; set; }
        public string OderPlaceDatatime { get; set; }
        public TimeSpan? OrderDeliveDatatime { get; set; }
        public string OrderShoppingCharges { get; set; }
        public string OtherOrtherDetails { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }
    }
}
