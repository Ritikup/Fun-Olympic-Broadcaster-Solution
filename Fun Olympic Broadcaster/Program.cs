using Fun_Olympic_Broadcaster.Data;
using Fun_Olympic_Broadcaster.Models;
using Fun_Olympic_Broadcaster.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<SMTPConfigModel>(builder.Configuration.GetSection("SMTP"));

builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddAuthentication().AddFacebook(options =>
{
    options.AppId = "394688372825561";
    options.AppSecret = "2b9bf2a2723e23a427ee0f760e46494a";
}).AddGoogle(options=>
{ options.ClientId = "335913462567-9o57s3dnfj698gu1hkvuf4f89r8kb6ce.apps.googleusercontent.com";
    options.ClientSecret = "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";
})
    ;
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
