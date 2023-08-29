using Repay_Bank.BusinessLayer.Abstract;
using Repay_Bank.BusinessLayer.Concrate;
using Repay_Bank.DataAccessLayer.Abstract;
using Repay_Bank.DataAccessLayer.Concrete;
using Repay_Bank.DataAccessLayer.EntityFramwork;
using Repay_Bank.DTO.DTOS.AppUserDtos;
using Repay_Bank.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(
    opt =>
    {
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequiredLength = 3;
        opt.Password.RequireUppercase = false;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireDigit = false;
        // opt.SignIn.RequireConfirmedEmail = true;//mail doðrulamasý olsun mu

    }
    )
    .AddErrorDescriber<CustomerIdentityValidation>()
    .AddEntityFrameworkStores<Context>();

builder.Services.AddScoped<ICustomerAccountProcessDAL, efCustomerAccountProcessDal>();
builder.Services.AddScoped<ICustomerAccountProcessService, CustomerAccountProcessManager>();


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
