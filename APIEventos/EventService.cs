using System.Runtime.CompilerServices;
using APIEventos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace APIEventos
{
    public class EventService
    {

        private ApplicationDbContext dbcontext;

        public EventService(ApplicationDbContext dbContext)
        {
            this.dbcontext = dbContext;
        }

        public async Task<Events?> GetDtoById(int id)
        {
            return await dbcontext.Events.FindAsync(id);
        }

    }
}
