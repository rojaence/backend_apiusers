using System.Text.Json.Serialization;
using apiUsers.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var appCors = "_appCors";

builder.Services.AddCors(options => 
{
    options.AddPolicy
    (
        name: appCors,
        policy => 
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        }
    );
}); 

builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddDbContext<ConnSqlServer>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("connStringSqlServer")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(appCors);
app.MapControllers();

app.Run();