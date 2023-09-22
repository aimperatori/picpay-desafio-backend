using Microsoft.EntityFrameworkCore;
using picpay_desafio_backend.Data;
using picpay_desafio_backend.Service;
using picpay_desafio_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<InMemoryContext>(opts => opts.UseInMemoryDatabase("picpay"));
builder.Services.AddDbContext<InMemoryContext>(opts => opts.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TransferService>();

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
