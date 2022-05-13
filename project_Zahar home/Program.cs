using Microsoft.EntityFrameworkCore;
using project_Zahar_home.Storage;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();

// �������� ������ ����������� �� ����� ������������
var connectionString = builder.Configuration.GetConnectionString("DbConnection");

// ��������� �������� ApplicationContext � �������� ������� � ����������
services.AddDbContext<RecipeContext>(options => options.UseSqlServer(connectionString));

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

app.UseAuthorization();

app.MapControllerRoute(//��������
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
