using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_13851.Data.Migrations;
using WAD_BACKEND_13851.Repositories;
using WAD_BACKEND_16232.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<FitnessTrackerDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FitnessTrackerConnectionStr")));


var allowedOrigins = "";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(allowedOrigins);

app.MapControllers();

app.Run();
