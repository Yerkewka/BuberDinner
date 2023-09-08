using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastucture;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddPesentation();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
