using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using paysys.webapi.Application.Services.TransferServices.Categories;
using paysys.webapi.Application.Services.TransferServices.Statuses;
using paysys.webapi.Application.Services.TransferServices.Transfers;
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
using paysys.webapi.Infra.Mail.Service;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers().AddNewtonsoftJson();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(s =>
    {
        s.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1.0",
            Title = "PaySys API",
            Description = "Sistema de pagamentos no qual se concentram usuários comuns, lojistas e administradores. Em resumo, os administradores gerenciam os usuários, os lojistas somente recebem pagamentos e os usuários comuns efetuam tranferências para usuários do mesmo tipo ou lojistas.",
            Contact = new OpenApiContact()
            {
                Name = "Matheus Macedo Santos",
                Email = "contact@matheus.macedo.dev.br",
            },
            License = new OpenApiLicense() { Name = "MIT License", Url = new Uri("https://opensource.org/licenses/MIT") }
        });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        s.IncludeXmlComments(xmlPath);
    });

    // Configurations
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

    ConfigureConnectionString(builder, configuration);

    builder.Services.Configure<TokenSettings>(options => configuration.GetSection("SecurityToken").Bind(options));
    builder.Services.Configure<UserTypeNamesSettings>(options => configuration.GetSection("UserTypeNames").Bind(options));
    builder.Services.Configure<SmtpSettings>(options => configuration.GetSection("Smtp").Bind(options));

    // DbContext Injection
    builder.Services.AddDbContext<DataContext>();

    // Infra Service Injection
    builder.Services.AddTransient<IMailInfraService, MailInfraService>();

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
    builder.Services.AddScoped<ITransferCategoriesService, TransferCategoriesService>();
    builder.Services.AddScoped<ITransferStatusesService, TransferStatusesService>();

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
    ApplyMigrations(app);

    // Swagger Config
    app.UseSwagger();
    app.UseSwaggerUI(ui =>
    {
        ui.SwaggerEndpoint("/swagger/v1/swagger.json", "PaySys API");
        ui.RoutePrefix = string.Empty;
    });

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
}

void ConfigureConnectionString(WebApplicationBuilder builder, IConfigurationRoot configuration)
{
    DotNetEnv.Env.Load();


    if (DotNetEnv.Env.GetBool("IS_PRODUCTION"))
    {
        string deployedConnectionString = DotNetEnv.Env.GetString("DEPLOYED_CONNECTION_STRING");

        builder.Services.Configure<ConnectionStringSettings>(options =>
        {
            options.LocalConnection = deployedConnectionString;
        });

        return;
    }

    builder.Services.Configure<ConnectionStringSettings>(options => configuration.GetSection("ConnectionStrings").Bind(options));
}

void ApplyMigrations(WebApplication app)
{
    Console.WriteLine("Task: Update database");

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

        var pendingMigrations = dbContext.Database.GetPendingMigrations();

        if (pendingMigrations.Any())
        {
            Console.WriteLine("Applying pending migrations...");

            dbContext.Database.Migrate();

            Console.WriteLine("Migrations applied successfully.");

            return;
        }

        Console.WriteLine("No pending migrations found.");
    }
}

app.Run();
