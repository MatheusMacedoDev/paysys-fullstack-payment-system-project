using paysys.webapi.Application.Services.UsersService;
using paysys.webapi.Application.Strategies.Cryptography;
using paysys.webapi.Application.Strategies.Token;
using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Infra.Data;
using paysys.webapi.Infra.Data.DAOs.Implementation;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
using paysys.webapi.Infra.Data.Repositories;
using paysys.webapi.Infra.Data.UnityOfWork;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers().AddNewtonsoftJson();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // DbContext Injection
    builder.Services.AddDbContext<DataContext>();

    // UnityOfWork Injectioj
    builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();

    // Repository Injections
    builder.Services.AddScoped<IUserTypesRepository, UserTypesRepository>();
    builder.Services.AddScoped<IUsersRepository, UsersRepository>();

    // DAOs Injections
    builder.Services.AddScoped<ICommonUserDAO, CommonUserDAO>();
    builder.Services.AddScoped<IShopkeeperDAO, ShopkeeperDAO>();
    builder.Services.AddScoped<IAdministratorDAO, AdministratorDAO>();

    // Strategies Injections
    builder.Services.AddSingleton<ICryptographyStrategy, CryptographyStrategy>();
    builder.Services.AddSingleton<ITokenStrategy, TokenStrategy>();

    // Application Services Injection
    builder.Services.AddScoped<IUsersService, UsersService>();
}

var app = builder.Build();
{
    // Swagger Config
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}

app.Run();
