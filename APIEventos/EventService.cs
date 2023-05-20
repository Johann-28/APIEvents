using System.Runtime.CompilerServices;
using APIEventos.Entidades;
using Microsoft.AspNetCore.Mvc;
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


        public async Task<Events?> GetById(int id)
        {
            return await dbcontext.Events.FindAsync(id);
        }


        public async Task<Events> Create(Events newEvent)
        {
            dbcontext.Events.Add(newEvent);
            await dbcontext.SaveChangesAsync();
            return newEvent;
           
        }
    }
}
