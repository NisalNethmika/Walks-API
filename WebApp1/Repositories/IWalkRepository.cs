using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Domain;

namespace WebApp1.Repositories
{
    public interface IWalkRepository
    {
            Task<Walk> CreateAsync(Walk walk);
            Task<List<Walk>> GetAllAsync(string? filterOn=null, string? filterQuery=null, string? sortBy=null, bool isAsc=true, int pageNumber = 1, int pageSize = 100);
            Task<Walk> GetByIDAsync(Guid id);
            Task<Walk> UpdateAsync(Guid ID, Walk walk);
            Task<Walk> DeleteAsync(Guid ID);
    }
}
