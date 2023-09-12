using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Test.Repository.Data;

namespace TP24Test.Repository.Extensions
{
    public static class RepositoryCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string connString = configuration.GetConnectionString("TP24Connection");

            services.AddDbContext<TP24Context>(o => o.UseSqlite(connString));

            return services;
        }
        public static void InitializeDatabase(this IServiceCollection services)
        {
            using var serviceScope = services.BuildServiceProvider().CreateScope();
            var context = serviceScope.ServiceProvider.GetService<TP24Context>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
}
