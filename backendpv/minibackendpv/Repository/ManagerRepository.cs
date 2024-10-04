using backendpv.Data;
using backendpv.Models;
using Microsoft.EntityFrameworkCore;

namespace backendpv.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        //get update delete

        private readonly ResContext _context;//this is your db
        public ManagerRepository(ResContext context)
        {
            _context = context;
        }

        public async Task<Manager> Create(Manager admin)
        {
            _context.Managers.Add(admin);
            await _context.SaveChangesAsync();

            return admin;
        }

        public async Task<Manager> Get(int id)
        {
            return await _context.Managers.FindAsync(id);
        }

        public async Task Update(Manager admin)
        {
            _context.Entry(admin).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            //var ToDelete = await _context.Reservation.FindAsync(id);
            //make sure the Reservation to delete exists?
           // _context.Reservation.Remove(ToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
