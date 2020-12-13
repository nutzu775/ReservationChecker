using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly StoreContext _context;
        public ReservationRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public async Task<IReadOnlyList<Reservation>> GetReservationsAsync()
        {
            return await _context.Reservations.ToListAsync();
        }
    }
}