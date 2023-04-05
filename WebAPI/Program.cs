using Library.Context;
using Library.Models;
using Library.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<WeightContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("WebAPI"));
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository<WeightDbModel>, WeightRepository>();
builder.Services.AddScoped<IRepository<UserDbModel>, UserRepository>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var _db = scope.ServiceProvider.GetRequiredService<WeightContext>();
    _db.Database.EnsureCreated();
}
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

