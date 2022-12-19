using IssueTracker.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IssueDbContextConnection") ?? throw new InvalidOperationException("Connection string 'IssueDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped(Sp => new HttpClient()
{
    BaseAddress = new Uri("https://localhost:44391/")
});
builder.Services.AddRazorPages();
builder.Services.AddDbContext<IssueDbContext>(Options => Options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<IssueDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
