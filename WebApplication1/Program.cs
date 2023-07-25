using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("laptops", () =>
{
    return Results.Ok(WebApplication1.Models.Database.Laptops);
});

// order laptops
app.MapGet("laptops/orderby", (string det) =>
{
    try
    {
        if (det == "asc" || det == "desc")
        {
            HashSet<Laptops> laptops = WebApplication1.Models.Database.Laptops;
            if (det == "asc")
            {
                return Results.Ok(laptops.OrderByDescending(laptop => laptop.Price));
            }
            else
            {
                return Results.Ok(laptops.OrderBy(laptop => laptop.Price));
            }
        } else
        {
            throw new ArgumentOutOfRangeException(nameof(det));
        }   
    }
    catch (InvalidOperationException ex)
    {
        return Results.Problem(ex.Message);
    } 
    catch (Exception ex)
    {
        return Results.NotFound(ex.Message);
    }
});

// list laptops within a range

app.Run();

