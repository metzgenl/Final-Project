using Microsoft.EntityFrameworkCore;
using NSwag.AspNetCore;
using Final_Project.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Final_Project API";
    config.Version = "v1";
});

var app = builder.Build();


app.UseOpenApi();
app.UseSwaggerUi();


app.UseHttpsRedirection();
app.UseAuthorization();


app.MapControllers();

app.Run();
