using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using project_Zahar_home.Logic.Dishes;
using project_Zahar_home.Logic.Ratings;
using project_Zahar_home.Storage;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();
services.AddScoped<IDishManager, DishManager>();
services.AddScoped<IRatingManager, RatingManager>();

// получаем строку подключения из файла конфигурации
var connectionString = builder.Configuration.GetConnectionString("DbConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
services.AddDbContext<RecipeContext>(options => options.UseSqlServer(connectionString));
services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                    options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(//проверка
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
