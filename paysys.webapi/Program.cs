using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Infra.Data;
using paysys.webapi.Infra.Data.Repositories;
using paysys.webapi.Infra.Data.UnityOfWork;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // DbContext Injection
    builder.Services.AddDbContext<DataContext>();

    // UnityOfWork Injectioj
    builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();

    // Repository Injections
    builder.Services.AddScoped<IUserTypesRepository, UserTypesRepository>();
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
