using paysys.webapi.Infra.Data;
using paysys.webapi.Infra.Data.UnityOfWork;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // DbContext Injection
    builder.Services.AddDbContext<DataContext>();

    // UnityOfWork Injection
    builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();
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
