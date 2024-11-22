using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Persistence.src.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            services.AddDbContext<TelegramBotDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ConnectionDbString"),
            b => b.MigrationsAssembly(typeof(TelegramBotDbContext).Assembly.FullName)), ServiceLifetime.Transient);
            services.AddScoped<ITelegramBotDbContext>(provider =>
            provider.GetService<TelegramBotDbContext>());
            return services;
        }
    }
}
