using WebAPI.Models;
using WebAPI.Utils.Dictionaries;

namespace WebAPI.Utils
{
    public class BuilderGeneralCost
    {
        public BuilderGeneralCost() { }
        public GeneralCost BuildEntity(int? costType, decimal? valueSpent) 
        {
            Random random= new Random();

            DateTime horaAgora = 
                DateTime.Now;

            var generalId = random.Next();
            var costTypeDescription = new CostTypeDictionary().SetCostType(costType);

            return new GeneralCost();
        
                }

        
    }
}
