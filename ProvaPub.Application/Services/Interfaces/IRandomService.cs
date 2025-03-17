using ProvaPub.Domain.Results;

namespace ProvaPub.Application.Services.Interfaces
{
    public interface IRandomService
    {
        Task<Result<int>> GetRandom();
    }
}


