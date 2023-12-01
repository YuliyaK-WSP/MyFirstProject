using System;
using MyFirstProject.Models;
using MyFirstProject.Controllers;
using System.Collections.Generic;
using MyFirstProject.Models.Enum;

namespace MyFirstProject.Interfaces
{
	public interface IOrderService
	{
        void Create(OrderItem orderItem);
        void Delete(int id);
        List<Order> FilterOrders(StatusEnumeration status);
        List<Order> GetOrder();
        List<OrderItem> GetOrderItem(int id);
        void Save(Order order);
        void Update(Order order);
    }
}

