using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("GeneralCost")]
    public class GeneralCost
    {
        [Key]
        public int? GeneralId{ get; set; }
        public int? WeekDayId { get; set; }
        public string? WeekDayDescription { get; set; }
        public int? CostTypeId{ get; set; }
        public string? CostTypeDescription { get; set; }
        public DateTime ValueSpentDateTime{ get; set; }
        public int? ValueSpentId{ get; set; }
        public decimal? ValueSpentDescription{ get; set; }
        public DateTime InsertUpdateDateTime { get; set; }

    }
    
}
