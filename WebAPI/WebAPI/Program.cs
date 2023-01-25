using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using WebAPI.Models;
using WebAPI.Repositorys;
using WebAPI.UseCases;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

//Enable CORS
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
      .AllowAnyHeader());
    
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IGeneralCostRepository, GeneralCostRepository>();
builder.Services.AddScoped<IUseCase<GeneralCost>, GeneralCostUseCase>();

builder.Services.AddDbContext<APIDbContext>(options => 
    options.UseSqlServer(configuration.GetConnectionString("GeneralCostAppCon"))
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "WEB API",
        Version = "v1"
    });
});

var app = builder.Build();
app.UseCors(options => 
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WEB API");
    c.DocumentTitle = "WEB API";
    c.DocExpansion(DocExpansion.List);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
