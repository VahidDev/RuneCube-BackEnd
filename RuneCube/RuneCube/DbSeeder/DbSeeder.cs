using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Repository.DAL;

namespace RuneCube.DbSeeder
{
    public static class DbSeeder
    {
        public async static void Seed(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            DataInitializer dataInitializer = new(context);
            await dataInitializer.InitializeDataAsync();
        }
    }
}
