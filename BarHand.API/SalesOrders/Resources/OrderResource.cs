﻿using BarHand.API.SalesOrders.Domain.Models;
using BarHand.API.Stores.Resources;

namespace BarHand.API.SalesOrders.Resources;

public class OrderResource
{
    public long Id { get; set; }
    public long StoreId { get; set; }
    public StoreResource Store { get; set; }
    public List<OrderDetail> orderDetails { get; set; }
}