using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskMangement.Data;
using TaskMangement.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<SystemUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>()

    .AddDefaultUI().AddDefaultTokenProviders();
builder.Services.AddDbContext<ApplicationDbContext>
    (option => option
    .UseSqlServer(builder.Configuration.GetConnectionString("defa")));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseAuthentication();
app.UseAuthorization();
app.Run();
