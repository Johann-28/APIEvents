using APIEventos.Entidades;
using Microsoft.EntityFrameworkCore;
namespace APIEventos.Services
{
    public class UserService
    {

        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async Task<Users?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<Users> Create(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();  
            return user;
        }



    }
}
