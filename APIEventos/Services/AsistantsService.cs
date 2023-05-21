using Microsoft.AspNetCore.Mvc;
using APIEventos.Entidades;
using APIEventos.Controllers;
using Microsoft.EntityFrameworkCore;

namespace APIEventos.Services
{
    public class AsistantsService
    {

        private ApplicationDbContext dbContext;
        private EventService eventService;
        private UserService userService;

        public AsistantsService(ApplicationDbContext dbContext, EventService eventService, UserService userService)
        {
            this.dbContext = dbContext;
            this.eventService = eventService;
            this.userService = userService;
        }
        public async Task<Asistants> Create(int userId, int eventId)
        {

            Asistants asistant = new Asistants
            {
                UserId = userId,
                EventId = eventId
            };

            var eventToRegister = await eventService.GetById(eventId);

            int newCapacity = eventToRegister.Capacidad - 1;

            eventToRegister.Capacidad = newCapacity;

             dbContext.Asistants.Add(asistant);
            await dbContext.SaveChangesAsync();


            return asistant;

        }
        public async Task<String> Validate(int userId, int eventId)
        {
            string result = "Valid";


            var eventToRegister = await eventService.GetById(eventId);

            if (eventToRegister is null)
            {
                return result = "Event doesnt exists";
            }

            var userToRegister = await userService.GetById(userId);

            if (userToRegister is null)
            {
                result = "User doesnt exists";
            }

            if (eventToRegister.Capacidad < 1)
            {
                result = "The event is already full";
            }

            bool isRegistered = await dbContext.Asistants
                .AnyAsync(a => a.UserId == userId && a.EventId == eventId);

            if(isRegistered)
            {
                result = "User is already registered for this event";
            }
       

            return result;
        }




    }
}
