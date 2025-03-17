using Bogus;
using FluentAssertions;
using ProvaPub.Domain.Models;
using Xunit.Abstractions;

namespace ProvaPub.UnitTests.Tests.Domain.Models;

[Trait("Domain - Models", "Category")]
public class ProductTests
{
    private readonly Faker _faker = new Faker("pt_BR");
    private readonly ITestOutputHelper _outputHelper;

    public ProductTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact]    
    public void Constructor_GivenAllParameters_ThenShouldSetThPropertiesCorrectly()
    {
        var expectedId = _faker.Random.Int(min:1);
        var expectedName = _faker.Person.FirstName;

        var product = new Product(expectedName, expectedId);
        _outputHelper.WriteLine($"{product.Id} - {product.Name}");

        product.Id.Should().Be(expectedId, "should be equal");
        product.Name.Should().Be(expectedName, "should be equal");
    }

    [Fact]    
    public void Constructor_GivenNameParameter_ThenShouldSetThPropertiesCorrectly()
    {
        var expectedName = _faker.Person.FirstName;

        var product = new Product(expectedName);

        Assert.Equal(expectedName, product.Name);
    }
}
