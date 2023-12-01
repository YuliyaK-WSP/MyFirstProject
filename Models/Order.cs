using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Models.Enum;

namespace MyFirstProject.Models
{
	public class Order
	{
        public int Id { get; set; }
        public string? Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        public StatusEnumeration Status { get; set; }
        // Связь с таблицей Provider
        public Provider? Provider { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}

