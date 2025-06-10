using Business_Logic_Layer;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using SoftoneStudentManagmentSystem;
using SoftoneStudentManagmentSystem.Middleware;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Softone Student Management System", Version = "v1" });
});

//Add dependancy injection for DAL and BLL layers
builder.Services.RegisterDALDependencies(builder.Configuration); 
builder.Services.RegisterBLLDependencies(builder.Configuration);
//Upgrade to Http 1 and Http 2
builder.WebHost.ConfigureKestrel(options =>
{
    // HTTP/1.1
    options.ListenAnyIP(5000);

    // HTTPS with HTTP/1.1, HTTP/2 and HTTP/3
    options.ListenAnyIP(5001, listenOptions =>
    {
        listenOptions.UseHttps();
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
    });
});
//Tune of Json Serialization
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

        options.JsonSerializerOptions.IgnoreNullValues = true;
    });


//var conString = builder.Configuration.GetConnectionString("StuConnStr") ??
//     throw new InvalidOperationException("Connection string 'StuConnStr'" +
//    " not found.");
//builder.Services.AddDbContext<SofttOneSmsnewContext>(options =>
//    options.UseSqlServer(conString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseAuthorization();

// Enable CORS to allow requests from any origin, header, and method
//Allow 3rd party frond end to connect this Api
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


app.MapControllers();

app.Run();
