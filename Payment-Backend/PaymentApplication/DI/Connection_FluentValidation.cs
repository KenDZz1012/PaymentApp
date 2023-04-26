using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.InteropServices.ObjectiveC;

namespace PaymentApplication.DI
{
    public static class Connection_FluentValidation
    {
        public static IServiceCollection ConfigFluentValidation(this IServiceCollection services, Assembly assembly)
        {
            services.AddControllers().AddFluentValidation(_ =>
            {
                _.RegisterValidatorsFromAssembly(assembly);
            }).ConfigureApiBehaviorOptions(o =>
            {
                o.InvalidModelStateResponseFactory = c =>
                {
                    var errors = c.ModelState.Values.Where(v => v.Errors.Count > 0).SelectMany(v => v.Errors).Select(v => v.ErrorMessage);
                    return new BadRequestObjectResult(new { Messenger = errors });
                };
            });

            return services;
        }
    }
}
