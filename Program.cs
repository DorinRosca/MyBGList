using Asp.Versioning;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using MyBGList;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });
builder.Services.AddPresentationServices();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",new OpenApiInfo{Title = "MyBGList", Version = "v1.0"});
    options.SwaggerDoc("v2",new OpenApiInfo{Title = "MyBGList", Version = "v2.0"});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
var useSwagger = app.Configuration.GetValue<bool>("UseSwagger");
var useDeveloperExceptionPage = app.Configuration.GetValue<bool>("UseDeveloperExceptionPage");

if (useSwagger)
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyBGList v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "MyBGList v2");
    });
}
if(useDeveloperExceptionPage)
    app.UseDeveloperExceptionPage();
else
    app.UseExceptionHandler("/error");


app.MapGet("/v{version:ApiVersion}/error",
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ResponseCache(NoStore = true)] () =>
        Results.Problem());
 
app.MapGet("/v{version:ApiVersion}/error/test",
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ResponseCache(NoStore = true)] () =>
    { throw new Exception("test"); });

app.MapGet("/v{version:ApiVersion}/cod/test",
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
