using CoffeShop.Domain.Aggregates.ValueObjects;
using CoffeShop.Domain.Repositories;
using CoffeShop.Domain.Services;
using CoffeShop.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DrinksController(IDrinkRepository _dringRepository, IDrinkService drinkService) : ControllerBase
{

    [HttpGet("names")]
    public IResult GetAllDrinks()
    {
        return Results.Ok(drinkService.GetAllDrinkNames());
    }

    [HttpGet("{name}/price")]
    public IResult GetDrinkPrice(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Results.BadRequest();
        }

        try
        {
            var drink = _dringRepository.Get(DrinkName.NameFor(name));
            return Results.Ok(drink.GetPrice());
        }
        catch (EntityNotFoundException)
        {
            return Results.NotFound();
        }
    }
}
