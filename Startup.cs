using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyFirstProject.Interfaces;
using MyFirstProject.Models;
using MyFirstProject.Models.Services;

namespace MyFirstProject
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // ...
            services.AddSingleton<IOrderService, OrderService>();
            
            // ...
        }
        
    }
}

