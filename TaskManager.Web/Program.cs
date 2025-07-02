using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Common.Interfaces;

using TaskManager.Application.Services;

//using TaskManager.Application.Interfaces;
using TaskManager.Infrastructure.Persistence.Context;
using TaskManager.Infrastructure.Persistence.Repositories;
using TaskManager.Infrastructure.Services;
//using TaskManager.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 🔌 Add services to the container
builder.Services.AddControllersWithViews();

// ✅ Register AppDbContext with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Register the TaskService with ITaskService interface
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IProjectService, ProjectService>();


var app = builder.Build();

// 🔧 Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Enforce HTTPS
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // ✅ Enables serving wwwroot files

app.UseRouting();

app.UseAuthorization();

//// ✅ Set default route to TaskController Index
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Task}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
