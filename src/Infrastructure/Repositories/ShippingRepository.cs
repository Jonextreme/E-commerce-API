using E_commerce_API.src.Application.Interfaces.Repositories;
using E_commerce_API.src.Domain.Entities;
using E_commerce_API.src.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_API.src.Infrastructure.Repositories
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly AppDbContext _appDbContext;
        public ShippingRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Shipping>> GetAllAsync()
        {
            return await _appDbContext.Shippings.AsNoTracking().ToListAsync();
        }
        public async Task<Shipping?> GetByIdAsync(int id)
        {
            return await _appDbContext.Shippings.FirstOrDefaultAsync(x => x.ShippingId == id);
        }
        public void Add(Shipping shipping)
        {
            _appDbContext.Shippings.Add(shipping);
        }
        public void Update(Shipping shipping)
        {
            _appDbContext.Shippings.Update(shipping);
        }
        public void Remove(Shipping shipping)
        {
            _appDbContext.Shippings.Remove(shipping);
        }
    }
}
