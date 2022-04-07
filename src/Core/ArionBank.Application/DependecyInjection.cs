using ArionBank.Application.Common.Interfaces;
using ArionBank.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application
{
    public static class DependecyInjection
    {
        public static void AddApplication(this IServiceCollection
            services)
        {
            services.AddScoped<ICardService, CardService>();
        }
    }
}
