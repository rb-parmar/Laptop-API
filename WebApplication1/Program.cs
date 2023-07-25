var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/Laptops", () =>
{
    return Results.Ok(WebApplication1.Models.Database.Laptops);
});




app.Run();

