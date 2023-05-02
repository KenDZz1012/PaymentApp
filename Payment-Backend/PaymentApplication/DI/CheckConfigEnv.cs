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
        public static IServiceCollection CheckEnv(this IServiceCollection services)
        {
            var GetAllConfig = Environment.GetEnvironmentVariables();
            foreach (var key in GetAllConfig as Dictionary<string, Object>)
            {
                if (key.Value == null)
                {
                    Console.WriteLine(string.Format("{key} : is null", key.Key));
                }
            }
            return services;
        }
    }
}
