using WebAPI.Models;

namespace WebAPI.UseCases
{
    public interface IUseCase<T>
    {
        Task<GeneralCost> Execute(GeneralCost objGeneralCost);
    }
}
