using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Repositorys
{
    public class GeneralCostRepository : IGeneralCostRepository
    {
        private readonly APIDbContext _appDBContext;
        public GeneralCostRepository(APIDbContext context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<GeneralCost>> GetGeneralCost()
        {
            return await _appDBContext.GeneralCost.ToListAsync();
        }
        public async Task<GeneralCost> GetGeneralCostByID(int? ID)
        {
            return await _appDBContext.GeneralCost.FindAsync(ID);
        }
        public async Task<GeneralCost> InsertGeneralCost(GeneralCost objGeneralCost)
        {
            _appDBContext.GeneralCost.Add(objGeneralCost);
            await _appDBContext.SaveChangesAsync();
            return objGeneralCost;
        }
        public async Task<GeneralCost> UpdateGeneralCost(GeneralCost objGeneralCost)
        {
            _appDBContext.Entry(objGeneralCost).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objGeneralCost;
        }
        public bool DeleteGeneralCost(int? ID)
        {
            bool result = false;
            var department = _appDBContext.GeneralCost.Find(ID);
            if (department != null)
            {
                _appDBContext.Entry(department).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
