using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplication.DI
{
    public  static class Config_MediatR
    {
        public static IServiceCollection ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(f =>
            {
                f.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
            return services;
        }
    }
}
