using System;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject
{
	public class HtmlResult : IActionResult
    {
        string htmlCode;
        public HtmlResult(string html) => htmlCode = html;
        public async Task ExecuteResultAsync(ActionContext context)
        {
            string fullHtmlCode = @$"
            <head>
                    <meta charset=utf-8 />
                </head>
                <body>
    <h1>Главная страница</h1>

    <div class=""filters"">
        <input type=""date"" id=""startDate"">
        <input type=""date"" id=""endDate"">
        <select class=""filter-select"">
            <option value=""{{{{str (StatusEnumeration.Defaul)}}}}"">Все заказы</option>
            <option value=""{{{{str (StatusEnumeration.Completed)}}}}"">Завершенные заказы</option>
            <option value=""{{{{str (StatusEnumeration.Pending)}}}}"">Ожидающие заказы</option>
        </select>
        <button asp-controller=""Home"" asp-action=""Filter"">Применить фильтры</button>
    </div>

    <table id=""ordersTable"">
        <thead>
            <tr>
                <th>Номер заказа|</th>
                <th>Дата заказа|</th>
                <th>Статус</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var orderItem in Model)
            {{
                <tr>
                    <td>@orderItem.Number</td>
                    <td>@orderItem.Date</td>
                    <td>@EnumExtensions.GetDescription(orderItem.Status)</td>
                    <td><a href=""@Url.Action(""Details"", new {{ id = orderItem.Id }})"">Подробнее</a></td>
                    <td>
                        <a asp-controller=""Home"" asp-action=""Edit"" asp-route-id=""@orderItem.Id"">Изменить</a> |
                        <a asp-controller=""Home"" asp-action=""Delete"" asp-route-id=""@orderItem.Id"">Удалить</a>
                    </td>
                </tr>
            }}

        </tbody>
    </table>

    
</body>";
            await context.HttpContext.Response.WriteAsync(fullHtmlCode);
        }
    }
}


