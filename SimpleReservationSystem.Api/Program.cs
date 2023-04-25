using Microsoft.EntityFrameworkCore;
using SimpleReservationSystem.Model;
using SimpleReservationSystem.Repository;
using SimpleReservationSystem.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IRoomService, RoomService>(); 
builder.Services.AddTransient<IReservationService, ReservationService>(); 
builder.Services.AddDbContext<SimpleReservationSystemContext>(options =>
    options.UseSqlite(("Data Source=SimpleReservationSystem.db"))
);
builder.Services.AddScoped<IRepository<Room>, RoomRepository>();
builder.Services.AddScoped<IRepository<Reservation>, ReservationRepository>();

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

using var scope = app.Services.CreateScope();
using var context = scope.ServiceProvider.GetRequiredService<SimpleReservationSystemContext>();
context.Database.Migrate();

app.Run();