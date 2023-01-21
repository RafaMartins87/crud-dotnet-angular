using WebAPI.Models;

namespace WebAPI.Repositorys
{
    public interface IGeneralCostRepository
    {
        Task<IEnumerable<GeneralCost>> GetGeneralCost();
        Task<GeneralCost> GetGeneralCostByID(int? ID);
        Task<GeneralCost> InsertGeneralCost(GeneralCost objGeneralCost);
        Task<GeneralCost> UpdateGeneralCost(GeneralCost objGeneralCost);
        bool DeleteGeneralCost(int? ID);
    }
}
