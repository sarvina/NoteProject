using Microsoft.EntityFrameworkCore;
using NoteProject.Dal;
using NoteProject.Dal.Interfaces;
using NoteProject.Dal.Repositories;
using NoteProject.Domain.Entity;
using NoteProject.Service.Implementation;
using NoteProject.Service.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IUserService, UserService>();



builder.Services.AddScoped<IBaseRepository<NoteEntity>, NoteRepository>();
builder.Services.AddScoped<INoteService, NoteService>();

var connectionString = builder.Configuration.GetConnectionString(name: "MSSQL");
builder.Services.AddDbContext<AppDbContext>(optionsAction: options =>
{
    options.UseSqlServer(connectionString);
});
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
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();


