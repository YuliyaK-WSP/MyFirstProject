using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Models;
using MyFirstProject.Interfaces;
using MyFirstProject.Models.Services;
using System.Collections.Generic;
using MyFirstProject.Models.Enum;

namespace MyFirstProject.Controllers;

public class HomeController : Controller
{
    private readonly IOrderService _orderService;
    private readonly YourDbContext _yourDbContext;

    public HomeController(YourDbContext yourDbContext, IOrderService orderService)
    {
        _yourDbContext = yourDbContext;
        _orderService = orderService;
    }

    public IActionResult Index(string status)
    {
        Console.WriteLine(status);
        List<Order> orders;
        switch (status)
        {
            case "Completed":
                orders = _orderService.FilterOrders(StatusEnumeration.Completed);
                break;
            case "Pending":
                orders = _orderService.FilterOrders(StatusEnumeration.Pending);
                break;
            default:
                orders = _orderService.GetOrder();
                break;
        }
        return View(orders);
    }
    [HttpPost]
    public IActionResult Filter(StatusEnumeration status)
    {

        var orders = _orderService.FilterOrders(status);
        return View("Index",orders);
    }
    public IActionResult Details(int id)
    {
        var orderItem = _orderService.GetOrderItem(id);
        if (orderItem == null)
        {
            return NotFound(); // Возвращение страницы 404, если заказ не найден
        }
        return View(orderItem); // Передаем только один объект OrderItem, а не список
    }
    public ActionResult Delete(int id)
    {
        var order = _orderService.GetOrder();
        var orderItems = order.Find(p => p.Id == id);
        if (orderItems == null)
        {
            return NotFound(); // Возвращение страницы 404, если товар не найден
        }
        order.Remove(orderItems);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        // Получите заказ из базы данных по его идентификатору
        var order = _yourDbContext.Orders.FirstOrDefault(o => o.Id == id);

        if (order == null)
        {
            // Если заказ не найден, верните сообщение об ошибке или выполните другое действие
            return NotFound();
        }

        // Передайте заказ в представление для отображения формы редактирования
        return View(order);
    }

    [HttpPost]
    public IActionResult Edit(Order order)
    {
        if (ModelState.IsValid)
        {
            // Обновите заказ в базе данных
            _yourDbContext.Orders.Update(order);
            _yourDbContext.SaveChanges();

            // Перенаправьте пользователя на страницу со списком заказов или выполните другое действие
            return RedirectToAction("Edit");
        }

        // Если модель недействительна, верните представление снова для исправления ошибок
        return View(order);
    }

}


