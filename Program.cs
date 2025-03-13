using Auth0.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.MVC.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the IoC (Inversion of Control) container. This is to make Dependency Injection of the DB Context to the Controllers
// The DB Context is injected into the Controllers to enable the Controllers to interact with the Database
var conn = builder.Configuration.GetConnectionString("SchoolManagementDbConnection");
builder.Services.AddDbContext<SchoolMngmntDbContext>(q => q.UseSqlServer(conn));
builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
});
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
