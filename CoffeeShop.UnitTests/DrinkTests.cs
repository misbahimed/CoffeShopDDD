using AutoFixture;
using CoffeShop.Domain.Aggregates.ValueObjects;
using CoffeShop.Domain.Repositories;
using CoffeShop.Infrastructure.Repositories;
using FluentAssertions;

namespace CoffeeShop.UnitTests;

public class DrinkTests
{
    private readonly Fixture _fixture;
    private readonly IDrinkRepository _dringRepository;


    public DrinkTests()
    {
        _fixture = new Fixture();

        _dringRepository = _fixture.Freeze<DrinkRepository>();
    }

    [Fact]
    public async Task CalculateDrinkPrice_Should_Return_52_When_Drink_Is_Espresso()
    {
        string name = "Espresso";

        var drink = _dringRepository.Get(DrinkName.NameFor(name));

        var result = drink.GetPrice();

        result.Should().Be(0.52m);
    }

    [Fact]
    public async Task CalculateDrinkPrice_Should_Return_325_When_Drink_Is_Milk()
    {
        string name = "Milk";

        var drink = _dringRepository.Get(DrinkName.NameFor(name));

        var result = drink.GetPrice();
        result.Should().Be(0.325m);
    }

    [Fact]
    public async Task CalculateDrinkPrice_Should_Return_1235_When_Drink_Is_Cappuccino()
    {
        string name = "Cappuccino";

        var drink = _dringRepository.Get(DrinkName.NameFor(name));

        var result = drink.GetPrice();
        result.Should().Be(1.235m);
    }

    [Fact]
    public async Task CalculateDrinkPrice_Should_Return_1235_When_Drink_Is_HotChocolate()
    {
        string name = "HotChocolate";

        var drink = _dringRepository.Get(DrinkName.NameFor(name));

        var result = drink.GetPrice();
        result.Should().Be(1.2350m);
    }

    [Fact]
    public async Task CalculateDrinkPrice_Should_Return_65_When_Drink_Is_CoffeeWithMilk()
    {
        string name = "CoffeeWithMilk";

        var drink = _dringRepository.Get(DrinkName.NameFor(name));

        var result = drink.GetPrice();
        result.Should().Be(0.65m);
    }

    [Fact]
    public async Task CalculateDrinkPrice_Should_Return_169_When_Drink_Is_Mokaccino()
    {
        string name = "Mokaccino";

        var drink = _dringRepository.Get(DrinkName.NameFor(name));

        var result = drink.GetPrice();
        result.Should().Be(1.690m);
    }

    [Fact]
    public async Task CalculateDrinkPrice_Should_Return_52_When_Drink_Is_Tea()
    {
        string name = "Tea";

        var drink = _dringRepository.Get(DrinkName.NameFor(name));

        var result = drink.GetPrice();
        result.Should().Be(0.52m);
    }
}
