﻿using BarHand.API.Inventory.Domain.Models;

namespace BarHand.API.SalesOrders.Domain.Models;

public class OrderDetail
{
    public long Id { get; set; }
    public int Quantity { get; set; }
    public int QuotedPrice { get; set; }
    
    //Relationship
   public long orderId { get; set; }
   public Order Order { get; set; }
   public long productId { get; set; }
   public Product Product { get; set; }
}