using ProvaPub.Application.Services.Interfaces;
using ProvaPub.Domain.Erros;
using ProvaPub.Domain.Models;
using ProvaPub.Domain.Repositories;
using ProvaPub.Domain.Results;

namespace ProvaPub.Application.Services
{
    public class RandomService : IRandomService
    {
        private readonly IRandomRepository _repository;
        private const int MAX_ATTEMPTS = 10;
        private const int NUMBER_ERROR_VALUE = -1;

        public RandomService(IRandomRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> GetRandom()
        {
            var number = await GenerateUniqueRandomNumber();

            if (number == NUMBER_ERROR_VALUE)
                return Result<int>.Failure(ErrorMessages.RandomServiceErros.NumberAlreadyExists);

            var result = _repository.Create(new RandomNumber(number));
            var success = await _repository.Save();
            if (!success)
                return Result<int>.Failure(ErrorMessages.RandomServiceErros.NumberAlreadyExists);

            return Result<int>.Success(number);
        }

        private async Task<int> GenerateUniqueRandomNumber()
        {
            for (var i = 0; i < MAX_ATTEMPTS; i++)
            {
                var number = Random.Shared.Next(100);
                if(await VerifyIfNumberIsUnique(number))
                    return number;

            }
            return NUMBER_ERROR_VALUE;
        }

        private async Task<bool> VerifyIfNumberIsUnique(int number)
            => await _repository.Get(n => n.Number == number) is null;

    }
}