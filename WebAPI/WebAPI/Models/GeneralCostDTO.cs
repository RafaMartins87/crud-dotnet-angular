namespace WebAPI.Models
{
    public class GeneralCostDTO
    {
        public int? WeekDayId { get; set; }
        public string? WeekDayDescription { get; set; }
        public int? CostTypeId { get; set; }
        public string? CostTypeDescription { get; set; }
        public DateTime ValueSpentDateTime { get; set; }
        public int? ValueSpentId { get; set; }
        public decimal? ValueSpentDescription { get; set; }
        public DateTime InsertUpdateDateTime { get; set; }

    }
}
