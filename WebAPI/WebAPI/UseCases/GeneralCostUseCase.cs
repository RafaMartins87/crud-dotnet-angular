using WebAPI.Models;
using WebAPI.Utils;

namespace WebAPI.UseCases
{
    public class GeneralCostUseCase:IUseCase<GeneralCost>
    {
        public GeneralCostUseCase() { }
        public Task<GeneralCost> Execute(GeneralCost objGeneralCost)
        {
            //var response = new BuilderGeneralCost().BuildEntity(objGeneralCost.CostTypeId, objGeneralCost?.ValueSpentDescription);

            var response = objGeneralCost;

            return Task.FromResult(response);

        }
    }
}
