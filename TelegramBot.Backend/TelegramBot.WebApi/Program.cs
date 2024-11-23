using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog.Events;
using Serilog;
using TelegramSink;
using System;
using System.Reflection;
using TelegramBot.Application.src.Common.Dependencies;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Interfaces;
using TelegramBot.Persistence;
using TelegramBot.Persistence.src.Data;
using TelegramBot.WebApi.src.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(ITelegramBotDbContext).Assembly));
});
builder.Services.AddSerilog();
builder.Services.AddAplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .WriteTo.TeleSink(
                telegramApiKey: "8084897678:AAHpLHbqeCkZbFmJwe4LD50n5bvmZY4q36k",
                telegramChatId: "1271362249")
                .CreateLogger();

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<TelegramBotDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "An error occurred while app anitialization");
    }
}

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.RoutePrefix = string.Empty;
    config.SwaggerEndpoint("swagger/v1/swagger.json", "TelegramBot.Backend");
});
app.UseCustomExceptionHandler();
app.UseRouting();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
