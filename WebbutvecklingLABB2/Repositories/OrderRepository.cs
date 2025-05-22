using WebbutvecklingLABB2.Models;
using WebbutvecklingLABB2.Data;
using Microsoft.EntityFrameworkCore;

namespace WebbutvecklingLABB2.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync() =>
      await _context.Orders
          .Include(o => o.Customer)
          .Include(o => o.OrderItems)
              .ThenInclude(oi => oi.Product)
          .ToListAsync();

        public async Task<Order?> GetByIdAsync(int id) => await _context.Orders.FindAsync(id);

        public async Task AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
