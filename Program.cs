using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options => 
    options.AddDefaultPolicy(cfg =>
    {
        cfg.AllowAnyOrigin();
        cfg.AllowAnyMethod();
        cfg.AllowAnyHeader();
    })
    );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
var useSwagger = app.Configuration.GetValue<bool>("UseSwagger");
var useDeveloperExceptionPage = app.Configuration.GetValue<bool>("UseDeveloperExceptionPage");

if (useSwagger)
{
    app.UseSwaggerUI();
}
if(useDeveloperExceptionPage)
    app.UseDeveloperExceptionPage();
else
    app.UseExceptionHandler("/error");
app.MapGet("/cod/test",
    [ResponseCache(NoStore = true)] () =>
        Results.Text("<script>" +
                     "window.alert('Your client supports JavaScript!" +
                     "\\r\\n\\r\\n" +
                     $"Server time (UTC): {DateTime.UtcNow.ToString("o")}" +
                     "\\r\\n" +
                     "Client time (UTC): ' + new Date().toISOString());" +
                     "</script>" +
                     "<noscript>Your client does not support JavaScript</noscript>",
            "text/html"));
app.MapGet("/error/throw", () =>
{
    throw new NotImplementedException("test");
});
app.MapGet("/error", () => Results.Problem());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
