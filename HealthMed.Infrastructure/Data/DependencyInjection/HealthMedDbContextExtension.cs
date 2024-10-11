using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Infrastructure.Data.DependencyInjection
{
    public static class HealthMedDbContextExtension
    {
        public static IServiceCollection AddHealthMedDbContext(this IServiceCollection services, string connectionString)
            => services.AddDbContext<HealthMedDbContext>(options =>
            {
                options.UseNpgsql(connectionString, providerOptions => providerOptions.EnableRetryOnFailure());
            });
    }
}
