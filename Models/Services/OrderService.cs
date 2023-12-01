using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Interfaces;
using MyFirstProject.Models.Enum;
using Microsoft.EntityFrameworkCore;
using MyFirstProject.Models;


namespace MyFirstProject.Models.Services
{
    public class OrderService : IOrderService
    {
        private readonly YourDbContext _dbContext;

        public OrderService(DbContextOptions<YourDbContext> options)
        {
            _dbContext = new YourDbContext(options);
        }

        public List<Order> GetOrders()
        {
            var orders = _dbContext.Orders.ToList();
            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.Id}, Number: {order.Number}, Date: {order.Date}, Status: {order.Status}");
            }
            return orders;
        }

        private static List<OrderItem> orderItem = new List<OrderItem>()
        {
            new OrderItem {Id=1, OrderId = 2, Name = "FGBFG", Quantity = 12, Unit = "GHNGHG" }
        };

        public void Create(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        public List<Order> FilterOrders(StatusEnumeration status)
        {
            List<Order> filteredOrders = _dbContext.Orders.Where(o => o.Status == status).ToList();
            return filteredOrders;
        }
        public List<Order> GetOrder()
        {
            return _dbContext.Orders.ToList();
        }

        public List<OrderItem> GetOrderItem(int id)
        {
            List<OrderItem> matchingOrderItems = orderItem.Where(orderItem => orderItem.OrderId == id).ToList();
            return matchingOrderItems;
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

