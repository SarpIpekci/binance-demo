using BinanceReactDemo.API.Context;
using BinanceReactDemo.API.Hubs;
using BinanceReactDemo.API.Models.BinanceHub;
using BinanceReactDemo.API.Repostories.BuyCoin.Abstract;
using BinanceReactDemo.API.Repostories.BuyCoin.Interfaces;
using BinanceReactDemo.API.Repostories.CustomerCoinTable.Abstract;
using BinanceReactDemo.API.Repostories.CustomerCoinTable.Interface;
using BinanceReactDemo.API.Repostories.SellCoin.Abstract;
using BinanceReactDemo.API.Repostories.SellCoin.Interfaces;
using BinanceReactDemo.API.Repostories.SignIn_SignUp.Abstract;
using BinanceReactDemo.API.Repostories.SignIn_SignUp.Interface;
using BinanceReactDemo.API.Validation.BuyCoin;
using BinanceReactDemo.API.Validation.SellCoin;
using BinanceReactDemo.API.Validation.SignIn;
using BinanceReactDemo.API.Validation.SignUp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<ISignInRepository, SignInRepository>();
builder.Services.AddScoped<ISignUpRepository, SignUpRepository>();
builder.Services.AddScoped<IBuyCoinRepository, BuyCoinRepository>();
builder.Services.AddScoped<ISellCoinRepository, SellCoinRepository>();
builder.Services.AddScoped<ICustomerCoinTables, CustomerCoinTables>();
builder.Services.AddScoped<SignInValidation>();
builder.Services.AddScoped<SignUpValidation>();
builder.Services.AddScoped<BuyCoinValidation>();
builder.Services.AddScoped<SellCoinValidation>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddHttpClient<BinanceHub>();

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:3000").WithOrigins("https://localhost:7159").AllowAnyHeader().AllowAnyHeader().AllowCredentials()));

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

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<BinanceHub>("/BinanceHub");
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
