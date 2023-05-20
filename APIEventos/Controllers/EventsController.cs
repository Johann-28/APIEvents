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

        public EventsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }


        //Regresa todos los registros de la tabla eventos
        [HttpGet("getall")]
        public async Task<ActionResult<List<Events>>> GetAll()
        {
            return await dbContext.Events.ToListAsync();
        }


    }
}
