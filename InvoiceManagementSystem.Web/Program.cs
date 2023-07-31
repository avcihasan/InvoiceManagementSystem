using InvoiceManagementSystem.Web.Areas.Admin.Services.Abstractions;
using InvoiceManagementSystem.Web.Areas.Admin.Services.Concretes;
using InvoiceManagementSystem.Web.Services.Abstractions;
using InvoiceManagementSystem.Web.Services.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


Uri baseAddress = new Uri(builder.Configuration["APIUrl"]);


builder.Services.AddHttpClient<IApartmentService, ApartmentService>(opts => opts.BaseAddress = baseAddress);
builder.Services.AddHttpClient<IInvoiceService, InvoiceService>(opts => opts.BaseAddress = baseAddress);
builder.Services.AddHttpClient<IMessageService, MessageService>(opts => opts.BaseAddress = baseAddress);
builder.Services.AddHttpClient<IPaymentService, PaymentService>(opts => opts.BaseAddress = baseAddress);
builder.Services.AddHttpClient<IUserService, UserService>(opts => opts.BaseAddress = baseAddress);


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

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();
app.Run();
