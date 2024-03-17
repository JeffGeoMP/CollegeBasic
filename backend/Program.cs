using backend.Data;
using backend.Data.Validator;
using backend.Seguridad;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<StudentValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors((policy) =>
{
    policy.AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed((origin) => true)
    .AllowAnyOrigin();
});

app.UseMiddleware<BasicAuthHandler>("RES");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
