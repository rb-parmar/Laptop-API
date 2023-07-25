using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

/*app.MapGet("laptops", () =>
{
    return Results.Ok(WebApplication1.Models.Database.Laptops);
});
*/
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
app.MapGet("laptops/search/price-range", (double? highest, double? lowest) =>
{
    try
    {
        if (highest == null && lowest == null)
        {
            return Results.BadRequest("At least one value must be provided for highest and lowest parameters.");
        }

        if (lowest == null)
        {
            lowest = Int32.MinValue;
        }

        if (highest == null)
        {
            highest = Int32.MaxValue;
        }

        if (highest < lowest)
        {
            return Results.BadRequest("Cannot request laptops with the highest price being lower than the lowest price.");
        }

        HashSet<Laptops> filteredLaptops =
        WebApplication1.Models.Database.Laptops.Where(l => l.Price <= highest && l.Price >= lowest).ToHashSet();

        return Results.Ok(filteredLaptops);
    }
    catch (InvalidOperationException ex)
    {
        return Results.Problem(ex.Message);
    }
    catch (Exception ex) 
    {
        return Results.Problem(ex.Message);
    }
});

// list of laptops grouped by type
app.MapGet("laptops/groupbytype", () =>
{
    try
    {
        HashSet<Laptops> laptops = WebApplication1.Models.Database.Laptops;

        IEnumerable<IGrouping<string, Laptops>> groupedLaptops =
        laptops.GroupBy(l => l.Type);
        
        return Results.Ok(groupedLaptops);

    }
    catch (InvalidOperationException ex)
    {
        return Results.Problem(ex.Message);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

// single laptop with the highest price
app.MapGet("laptops/most-priced_laptop", (int price) =>
{
    try
    {
        if (price < 0)
        {
            throw new Exception("Price cannot be less than 0");
        }
        HashSet<Laptops> laptops = WebApplication1.Models.Database.Laptops;

        HashSet<Laptops> filteredLaptop = laptops.Where(l => l.Quantity > 0 && l.Price < price).ToHashSet();
        Laptops maxPricedLaptop = filteredLaptop.OrderBy(l => l.Price).LastOrDefault();

        return Results.Ok(maxPricedLaptop);
    }
    catch (InvalidOperationException ex)
    {
        return Results.Problem(ex.Message);
    }
    catch (Exception ex) 
    {
        return Results.Problem(ex.Message);
    }
});
app.Run();

