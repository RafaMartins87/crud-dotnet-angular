using WebAPI.Models;
using WebAPI.Utils;

namespace WebAPI.UseCases
{
    public class GeneralCostUseCase
    {
        public GeneralCostUseCase() { }

        public GeneralCost Execute(GeneralCost objGeneralCost)
        {
            var response = new BuilderGeneralCost().BuildEntity(objGeneralCost.CostTypeId, objGeneralCost?.ValueSpentDescription);

            return response;

        }
    }
}
