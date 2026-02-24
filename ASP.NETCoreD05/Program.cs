namespace ASP.NETCoreD05
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Container
            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {
                foreach (var provider in options.ModelBinderProviders)
                {
                    Console.WriteLine(provider.GetType().ToString());
                }
            });
            //.AddCookieTempDataProvider(); // This is the default provider that uses cookies to store TempData.
            //.AddSessionStateTempDataProvider(); // This provider uses the session state to store TempData. It requires session services to be added and configured.

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
