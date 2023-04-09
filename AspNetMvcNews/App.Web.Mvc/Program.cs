using App.Data;
using App.Data.Abstract;
using App.Data.Concrete;
using App.Service.Abstract;
using App.Service.Concrete;
using App.Web.Mvc.Models.Validators;
using App.Web.Mvc.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ApplicationIdentityDbContext>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
builder.Services.AddTransient<INewsService, NewsService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ISendGridEmail, SendGridEmail>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration.GetSection("SendGrid"));

builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
	opt.SignIn.RequireConfirmedEmail = false;
	opt.SignIn.RequireConfirmedAccount = false; // Bunu açınca confirmed account istediği için giriş yapmıyor!!!!
	opt.SignIn.RequireConfirmedPhoneNumber = false;

	// User
	opt.User.RequireUniqueEmail = true;
	opt.User.AllowedUserNameCharacters = "abcçdefgğhiıjklmnoöpqrsştuüvwxyzABCÇDEFGĞHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-";

	//Password
	opt.Password.RequiredLength = 5;
	opt.Password.RequireLowercase = true;

	//Lockout
	opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
	opt.Lockout.MaxFailedAccessAttempts = 5;

}).AddEntityFrameworkStores<ApplicationIdentityDbContext>().AddUserValidator<UserValidator>().AddPasswordValidator<PasswordValidator>().AddErrorDescriber<ErrorDescriber>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.AccessDeniedPath = "/Account/AccessDenied";
    x.Cookie.Name = "Administrator";
    x.Cookie.MaxAge = TimeSpan.FromDays(1);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/CustomError");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
			name: "Admin",
			pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
		  );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
