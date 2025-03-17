using ProvaPub.Domain.Enums;

namespace ProvaPub.Domain.Erros;
public static class ErrorMessages
{
    public static class GeneralErros
    {
        public static Error UnkownError(string message) =>
            new(EErrorType.Unkown, $"Something got wrong: {message}");
    }

    public static class RandomServiceErros
    {
        public static Error NumberAlreadyExists =>
            new(EErrorType.Conflict, "The generated number already exists.");
    }

    public static class CustomerServiceErros
    {
        public static Error CustomerIdIsInvalid(int customerId) =>
            new(EErrorType.BadRequest, $"Customer Id is invalid: {customerId}");

        public static Error PurchaseValueIsInvalid(decimal purchaseValue) =>
            new(EErrorType.BadRequest, $"Purchase value is invalid: {purchaseValue}");

        public static Error CustomerNotExists(int customerId) =>
            new(EErrorType.NotFound, $"Customer Id {customerId} does not exists");

        public static Error CustomerCannotBuyThisMonth(int customerId) =>
            new(EErrorType.BadRequest, $"Customer Id {customerId}, cannot buy this month");

        public static Error CustomerFirstBuy(int customerId, decimal purchaseValue) =>
            new(EErrorType.BadRequest, $"Customer Id {customerId}, cannot buy this amount: {purchaseValue}.");

        public static Error IsBusinessHour() =>
            new(EErrorType.BadRequest, $"We cannot sell on business hour.");
    }

    public static class OrderServiceErrors
    {
        public static Error InvalidCustomer(int customerId) =>
            new(EErrorType.NotFound, $"Customer doesn't exist: {customerId}");

        public static Error ErrorSaveChanges() =>
            new(EErrorType.NotFound, $"An error ocurred during saving proccess.");
    }
}
