using E_commerce_API.src.Application.Interfaces.Repositories;
using E_commerce_API.src.Domain.Entities;
using E_commerce_API.src.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_API.src.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _appDbContext;
        public PaymentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _appDbContext.Payments.AsNoTracking().ToListAsync();
        }
        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _appDbContext.Payments.FirstOrDefaultAsync(x => x.PaymentId == id);
        }
        public void Add(Payment payment)
        {
            _appDbContext.Payments.Add(payment);
        }
        public void Update(Payment payment)
        {
            _appDbContext.Payments.Update(payment);
        }
        public void Remove(Payment payment)
        {
            _appDbContext.Payments.Remove(payment);
        }
    }
}
