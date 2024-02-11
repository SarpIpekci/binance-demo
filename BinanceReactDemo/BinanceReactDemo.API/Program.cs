using BinanceReactDemo.API.Hubs;
using BinanceReactDemo.API.Models.BinanceHub;
using BinanceReactDemo.API.Test;
using BinanceReactDemo.Business.Abstract;
using BinanceReactDemo.Business.Abstract.CustomerCoinTable;
using BinanceReactDemo.Business.Abstract.SellCoin;
using BinanceReactDemo.Business.Abstract.SignIn;
using BinanceReactDemo.Business.Abstract.SignUp;
using BinanceReactDemo.Business.Concrete;
using BinanceReactDemo.Business.Concrete.CustomerCoinTable;
using BinanceReactDemo.Business.Concrete.SellCoin;
using BinanceReactDemo.Business.Concrete.SignIn;
using BinanceReactDemo.Business.Concrete.SignUp;
using BinanceReactDemo.CacheManager.Abstract;
using BinanceReactDemo.CacheManager.Concrete;
using BinanceReactDemo.Common.LogHelper;
using BinanceReactDemo.Core.Extensions;
using BinanceReactDemo.DataAccessLayer.Abstract.UnitOfWork;
using BinanceReactDemo.DataAccessLayer.Concrete.UnitOfWork;
using BinanceReactDemo.Validation;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationExtension.SetConfiguration(builder.Configuration);

builder.Services.TryAddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();

builder.Services.AddValidationServices();

builder.Services.TryAddScoped(typeof(IBuyCoinService), typeof(BuyCoinService));
builder.Services.TryAddScoped(typeof(ISellCoinService), typeof(SellCoinService));
builder.Services.TryAddScoped(typeof(ISignInService), typeof(SignInService));
builder.Services.TryAddScoped(typeof(ISignUpService), typeof(SignUpService));
builder.Services.TryAddScoped(typeof(ICustomerCoinTableService), typeof(CustomerCoinTableService));
builder.Services.TryAddScoped(typeof(ICacheManager), typeof(RedisCacheManager));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddHttpClient<BinanceHub>();

builder.Services.AddStackExchangeRedisCache(options => options.Configuration = "localhost:56379");

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:3000").WithOrigins("https://localhost:7159").AllowAnyHeader().AllowAnyHeader().AllowCredentials()));

builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom.Configuration(hostingContext.Configuration)
        .WriteTo.MSSqlServer(
            connectionString: hostingContext.Configuration.GetConnectionString("SqlConnection"),
            sinkOptions: new MSSqlServerSinkOptions
            {
                TableName = "Logs",
                AutoCreateSqlTable = true
            },
            columnOptions: ColumnOptionsProvider.GetColumnOptions()
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseRouting();

app.ConfigureExceptionHandler();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<BinanceHub>("/BinanceHub");
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
