using Ct.Interview.Application;
using Ct.Interview.Infrastructure;
using Ct.Interview.Web.Api;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    // Add services to the container.

    builder.Services.AddControllers();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.

    app.UseHttpsRedirection();

    //app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
