using Microsoft.EntityFrameworkCore;
using troja.Data;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

  
// Add services to the container.

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("MyAllowSpecificOrigins",
            policy =>
            {
                policy.WithOrigins("http://localhost:5132",
                        "http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
    });

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<DataContext>(options =>
        options.UseNpgsql("Host=localhost; Database=trojadbv2; Username=postgres; Password=admin"));

    var app = builder.Build();

    app.UseCors(MyAllowSpecificOrigins);
// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();
    app.UseCors();
    app.MapControllers();

    static async Task SendSms()
    {

    }


    app.Run();
