using backendpv.Data;
using System.Runtime.CompilerServices;

namespace backendpv
{
    public static class ManagerSeeder
    {
        public static void Initializer(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<ResContext>();
            context.Database.EnsureCreated();
            InitManager(context);
        }

        private static void InitManager(ResContext context)
        {
            
           var admin = context.Managers.FirstOrDefault();
            if(admin == null)
           {
                context.Managers.Add(new Models.Manager
                {
                    UserName = "admin",
                    Email = "test@yahoo.com",
                    PasswordHash = "friday!4"
                });
            }
            
            context.SaveChanges(); 
        }
    }
}
