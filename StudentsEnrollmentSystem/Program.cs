using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using StudentsEnrollmentSystem.Data;
using StudentsEnrollmentSystem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders(); // هذا يحذف أي مزود لوجينغ موجود مسبقًا
builder.Logging.AddConsole();
// Configure DbContext with your connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Students")));


builder.Services.AddSingleton<Microsoft.AspNetCore.Identity.UI.Services.IEmailSender, DummyEmailSender>();


// Add Identity with roles (optional) and token providers for features like password reset
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;

    // Password settings example
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;

    // Lockout settings example
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings example
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();  // مهم لميزات الهوية المتقدمة مثل استعادة كلمة المرور

// Add MVC controllers with views (for your MVC pages)
builder.Services.AddControllersWithViews();

// Configure cookie settings (مسارات صفحات الدخول والخروج)
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";  // صفحة تسجيل الدخول الخاصة بك في MVC
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true;
});
builder.Services.AddRazorPages();
var app = builder.Build();
var emailSender = app.Services.GetRequiredService<IEmailSender>();
await emailSender.SendEmailAsync("test@fake.com", "Test Subject", "<strong>This is a test message</strong>");
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Map controller routes for MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Razor Pages for Identity UI (scaffolded pages)
app.MapRazorPages();
Console.WriteLine("🚀 The app is starting!");
Console.WriteLine("you can see it ");
app.Run();
