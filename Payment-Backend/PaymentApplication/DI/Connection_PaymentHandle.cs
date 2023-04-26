using Microsoft.Extensions.DependencyInjection;
using PaymentApplication.Handle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplication.DI
{
    public static class Connection_PaymentHandle
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<interfaces.IConnection_Payment, PaymentHandle>();
            return services;
        }
    }
}
