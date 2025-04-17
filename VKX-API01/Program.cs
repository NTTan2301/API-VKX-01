using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using VKX_API01.Application;
using VKX_API01.Help.BaseSerivce;
using VKX_API01.Help.Reponse;
using VKX_API01.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStr"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200")  
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddExpressionMapping();
    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
});

builder.Services.AddScoped<IReponsitory, Repository>();
builder.Services.AddScoped<IBaseService, BaseService>();

builder.Services.AddScoped<CompanyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowLocalhost");

app.UseAuthorization();

app.MapControllers();

app.Run();
