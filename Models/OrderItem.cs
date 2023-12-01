using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace MyFirstProject.Models
{
	public class OrderItem
	{
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string? Name { get; set; }
        public decimal Quantity { get; set; }
        public string? Unit { get; set; }

        // Связь с таблицей Order
        public Order? Order { get; set; }
    }
}