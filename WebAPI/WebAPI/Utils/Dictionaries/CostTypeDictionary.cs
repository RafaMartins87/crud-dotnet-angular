namespace WebAPI.Utils.Dictionaries
{
    public class CostTypeDictionary
    {
        public string SetCostType(int? costTypeId)
        {
            GenerateCostTypeArray array = new GenerateCostTypeArray(){};

            var arrayValue = array.GetCostTypeArray();

            return arrayValue[(int)costTypeId.GetValueOrDefault()];


        }
    }
}
