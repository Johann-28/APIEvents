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

        public async Task Update(int id, Events evento)
        {
            var existingEvent = await GetById(id);

            if(existingEvent is not null)
            {
                existingEvent.Name = evento.Name;
                existingEvent.Descripcion = evento.Descripcion; 
                existingEvent.Date = evento.Date;
                existingEvent.Ubicacion = evento.Ubicacion;
                existingEvent.Capacidad = evento.Capacidad;

                await dbcontext.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var eventToDelete = await GetById(id);

            if(eventToDelete is not null)
            {
                dbcontext.Events.Remove(eventToDelete);
                await dbcontext.SaveChangesAsync();
            }
        }
    }
}
