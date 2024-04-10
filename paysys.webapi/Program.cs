using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using paysys.webapi.Application.Services.TransfersService;
using paysys.webapi.Application.Services.UsersService;
using paysys.webapi.Application.Strategies.Cryptography;
using paysys.webapi.Application.Strategies.Token;
using paysys.webapi.Configuration;
using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Infra.Data;
using paysys.webapi.Infra.Data.DAOs.Implementation;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
using paysys.webapi.Infra.Data.Repositories;
using paysys.webapi.Infra.Data.UnityOfWork;
using paysys.webapi.Infra.Mail;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers().AddNewtonsoftJson();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Configurations
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

    builder.Services.Configure<TokenSettings>(options => configuration.GetSection("SecurityToken").Bind(options));
    builder.Services.Configure<UserTypeNamesSettings>(options => configuration.GetSection("UserTypeNames").Bind(options));
    builder.Services.Configure<ConnectionStringSettings>(options => configuration.GetSection("ConnectionStrings").Bind(options));
    builder.Services.Configure<SmtpSettings>(options => configuration.GetSection("Smtp").Bind(options));

    // DbContext Injection
    builder.Services.AddDbContext<DataContext>();

    // Infra Service Injection
    builder.Services.AddTransient<IMailService, MailService>();

    // UnityOfWork Injection
    builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();

    // Repository Injections
    builder.Services.AddScoped<IUserTypesRepository, UserTypesRepository>();
    builder.Services.AddScoped<IUsersRepository, UsersRepository>();
    builder.Services.AddScoped<ITransfersRepository, TransfersRepository>();

    // DAOs Injections
    builder.Services.AddScoped<ICommonUserDAO, CommonUserDAO>();
    builder.Services.AddScoped<IShopkeeperDAO, ShopkeeperDAO>();
    builder.Services.AddScoped<IAdministratorDAO, AdministratorDAO>();
    builder.Services.AddScoped<IUserDAO, UserDAO>();
    builder.Services.AddScoped<ITransferDAO, TransferDAO>();

    // Strategies Injections
    builder.Services.AddSingleton<ICryptographyStrategy, CryptographyStrategy>();
    builder.Services.AddSingleton<ITokenStrategy, TokenStrategy>();

    // Application Services Injection
    builder.Services.AddScoped<IUsersService, UsersService>();
    builder.Services.AddScoped<ITransfersService, TransfersService>();

    // Authentication
    var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecurityToken:SecurityKey")!);

    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
}

var app = builder.Build();
{
    // Swagger Config
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
}

app.Run();
