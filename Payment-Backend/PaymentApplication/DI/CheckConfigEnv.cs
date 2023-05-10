using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplication.DI
{
    public static class CheckConfigEnv
    {
        public static string URL_Redirect = string.Empty;
        public static IServiceCollection CheckEnv(this IServiceCollection services)
        {
          
            return services;
        }
    }
}
