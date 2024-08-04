using Microsoft.EntityFrameworkCore;
using MyBGList.Context;

namespace MyBGList;

public static class DependencyInjection
{
    public static void SetDBContext(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
    }
}