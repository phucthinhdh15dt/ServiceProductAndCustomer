using System;
using System.Collections.Generic;

namespace testdbfirst.Models
{
    public partial class OrderItem
    {
        public string ItemId { get; set; }
        public string OrderItemStatusCode { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string ItemStatusCode { get; set; }
        public TimeSpan? ItemDeliveredDatatime { get; set; }
        public string ItemOrderQuantity { get; set; }

        public CustomerOrders Order { get; set; }
        public Product Product { get; set; }
    }
}
