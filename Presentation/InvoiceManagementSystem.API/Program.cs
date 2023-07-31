using InvoiceManagementSystem.Application.Abstractions.Services;
using InvoiceManagementSystem.Application.Extensions;
using InvoiceManagementSystem.Domain.Entities;
using InvoiceManagementSystem.Persistence.Contexts;
using InvoiceManagementSystem.Persistence.Extensions;
using InvoiceManagementSystem.Persistence.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IPaymentService, PaymentService>(opts =>
{
    opts.BaseAddress = new Uri(string.Concat("http://localhost:5198", "/api/"));
});

builder.Services.AddApplicationService(); 
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<InvoiceManagementSystemDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
