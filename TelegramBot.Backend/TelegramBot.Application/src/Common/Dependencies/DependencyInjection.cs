using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Behaviors;

namespace TelegramBot.Application.src.Common.Dependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(
            this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));
            return services;
        }
    }
}
