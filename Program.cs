using MyBGList;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.SetDBContext(builder.Configuration);
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
    app.UseSwagger();
    app.UseSwaggerUI();
}
if(useDeveloperExceptionPage)
    app.UseDeveloperExceptionPage();
else
    app.UseExceptionHandler("/error");

app.MapGet("/error/throw", () =>
{
    throw new NotImplementedException("test");
});
app.MapGet("/error", () => Results.Problem());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
