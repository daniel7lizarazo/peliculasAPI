using Peliculas.API.Configurations;
using Peliculas.Application.Utils;

string _Cors = "_Cors";
var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;
// Add services to the container.

AppVariables.WebRootPath = environment.WebRootPath;

builder.Services.AddCors(options => {
    options.AddPolicy(name: _Cors,
                      builder =>
                      {
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                          builder.SetIsOriginAllowed((Host) => true);
                          builder.AllowCredentials();
                      });
});


builder.Services
    .AddConfigureService()
    .AddCorsConfiguration()
    .AddConnectionProvider(configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();


app.UseCors(_Cors);

app.MapControllers();

app.Run();
