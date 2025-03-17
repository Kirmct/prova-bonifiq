using Bogus;
using Castle.Core.Resource;
using FluentAssertions;
using NSubstitute;
using ProvaPub.Application.Services;
using ProvaPub.Domain.Erros;
using ProvaPub.Domain.Models;
using ProvaPub.Domain.Repositories;
using ProvaPub.UnitTests.Setup;
using System.Linq.Expressions;
using Xunit.Abstractions;

namespace ProvaPub.UnitTests.Tests.Application.Services;
[Trait("Application - Services", "CustomerService")]
public class CustomerServiceTests
{
    private readonly Faker _faker = new Faker("pt_BR");
    private readonly ITestOutputHelper _outputHelper;
    private readonly CustomerService _customerService;
    private readonly ICustomerRepository _mockCustomerRepository;

    public CustomerServiceTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        _mockCustomerRepository = Substitute.For<ICustomerRepository>();
        var autoMapperSetup = AutoMapperSetup.GetMapper();
        _customerService = new CustomerService(_mockCustomerRepository, autoMapperSetup);
    }

    [Fact]
    public async Task CanPurchase_GivenCustomerIdInvalid_ThenShouldReturnError()
    {
        var invalidCustomerId = -1;
        var validPurchaseValue = 20M;

        var result = await _customerService.CanPurchase(invalidCustomerId, validPurchaseValue);

        result.Error.Should().BeEquivalentTo(ErrorMessages.CustomerServiceErros.CustomerIdIsInvalid(invalidCustomerId));
    }

    [Fact]
    public async Task CanPurchase_GivenPurchaseValueInvalid_ThenShouldReturnError()
    {
        var validCustomerId = 1;
        var invalidPurchaseValue = -20M;

        var result = await _customerService.CanPurchase(validCustomerId, invalidPurchaseValue);

        result.Error.Should().BeEquivalentTo(ErrorMessages.CustomerServiceErros.PurchaseValueIsInvalid(invalidPurchaseValue));
    }

    [Fact]
    public async Task CanPurchase_GivenCustomerNotExist_ThenShouldReturnError()
    {
        var invalidCustomerId = 100;
        var validPurchaseValue = 20M;

        _mockCustomerRepository
            .Get(Arg.Any<Expression<Func<Customer, bool>>>())
            .Returns((Customer?)null);

        var result = await _customerService.CanPurchase(invalidCustomerId, validPurchaseValue);

        result.Error.Should().BeEquivalentTo(ErrorMessages.CustomerServiceErros.CustomerNotExists(invalidCustomerId));
    }

    [Fact]
    public async Task CanPurchase_GivenCustomerThatCannotBuyThisMonth_ThenShouldReturnError()
    {
        var validCustomerId = _faker.Random.Int(min: 1);
        var validCustomerName = _faker.Name.FirstName();
        var validPurchaseValue = 20M;

        _mockCustomerRepository
            .Get(Arg.Any<Expression<Func<Customer, bool>>>())
            .Returns((Customer?)new Customer(validCustomerName, validCustomerId));

        _mockCustomerRepository
            .GetCustomersPurchasesMonthlyCount(Arg.Any<int>())
            .Returns(1);

        var result = await _customerService.CanPurchase(validCustomerId, validPurchaseValue);

        result.Error.Should().BeEquivalentTo(ErrorMessages.CustomerServiceErros.CustomerCannotBuyThisMonth(validCustomerId));
    }

    [Fact]
    public async Task CanPurchase_GivenCustomerFirstBuyAmount_ThenShouldReturnError()
    {
        var validCustomerId = _faker.Random.Int(min: 1);
        var validCustomerName = _faker.Name.FirstName();
        var invalidPurchaseValue = 200M;


        _mockCustomerRepository
            .Get(Arg.Any<Expression<Func<Customer, bool>>>())
            .Returns((Customer?)new Customer(validCustomerName, validCustomerId));

        _mockCustomerRepository
            .GetCustomersPurchasesMonthlyCount(Arg.Any<int>())
            .Returns(0);

        _mockCustomerRepository
            .GetCustomersPurchasesCount(Arg.Any<int>())
            .Returns(0);

        var result = await _customerService.CanPurchase(validCustomerId, invalidPurchaseValue);

        result.Error.Should().BeEquivalentTo(ErrorMessages.CustomerServiceErros.CustomerFirstBuy(validCustomerId, invalidPurchaseValue));
    }

    [Fact]
    public async Task CanPurchase_OutsideBusinessHours_ShouldReturnError()
    {
        var validCustomerId = _faker.Random.Int(min: 1);
        var validCustomerName = _faker.Name.FirstName();
        var validPurchaseValue = 50M;


        _mockCustomerRepository
            .Get(Arg.Any<Expression<Func<Customer, bool>>>())
            .Returns((Customer?)new Customer(validCustomerName, validCustomerId));

        _mockCustomerRepository
            .GetCustomersPurchasesMonthlyCount(Arg.Any<int>())
            .Returns(0);

        _mockCustomerRepository
            .GetCustomersPurchasesCount(Arg.Any<int>())
            .Returns(1);

        _customerService.CurrentTime = new DateTime(2025,03,15);

        var result = await _customerService.CanPurchase(validCustomerId, validPurchaseValue);

        result.Error.Should().BeEquivalentTo(ErrorMessages.CustomerServiceErros.IsBusinessHour());
    }

    [Fact]
    public async Task CanPurchase_ShouldReturnSuccess()
    {
        var validCustomerId = _faker.Random.Int(min: 1);
        var validCustomerName = _faker.Name.FirstName();
        var validPurchaseValue = 50M;


        _mockCustomerRepository
            .Get(Arg.Any<Expression<Func<Customer, bool>>>())
            .Returns((Customer?)new Customer(validCustomerName, validCustomerId));

        _mockCustomerRepository
            .GetCustomersPurchasesMonthlyCount(Arg.Any<int>())
            .Returns(0);

        _mockCustomerRepository
            .GetCustomersPurchasesCount(Arg.Any<int>())
            .Returns(1);

        _customerService.CurrentTime = new DateTime(2025, 03, 11, 15,20, 20);

        var result = await _customerService.CanPurchase(validCustomerId, validPurchaseValue);

        result.Value.Should().Be(true);
    }
}
