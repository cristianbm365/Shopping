using Microsoft.EntityFrameworkCore;
using Shopping.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(o => // ac�, esto viene de CountriesController
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}); // significa que cualquier clase que llame al datacontext trae lo anterior, una conexi�n con el sql server y est� basado con el GetConnectionString

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
