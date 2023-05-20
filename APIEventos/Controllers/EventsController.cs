using Microsoft.AspNetCore.Mvc;
using APIEventos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace APIEventos.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;
        private readonly EventService eventService;

        public EventsController(ApplicationDbContext dbContext, EventService eventService)
        {
            this.dbContext = dbContext;
            this.eventService = eventService;

        }


        //Regresa todos los registros de la tabla eventos
        [HttpGet("getall")]
        public async Task<ActionResult<List<Events>>> GetAll()
        {
            return await dbContext.Events.ToListAsync();
        }

        //Regresa el evento con la id solicitada
        [HttpGet("get/{id}")]
        public async Task<ActionResult<Events>> GetById(int id)
        {
            var evento = await eventService.GetDtoById(id);

            if (evento is null)
                return BadRequest("No existe puñetassss");
            return evento;

        }


    }
}
