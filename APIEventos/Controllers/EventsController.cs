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
            var evento = await eventService.GetById(id);

            if (evento is null)
                return BadRequest("El evento no existe");
            return evento;

        }

        //Añade un parametro a la base de datos
        [HttpPost("create")]
        public async Task<IActionResult> Create(Events evento)
        {

            var newEvent = await eventService.Create(evento);
           
            return Ok();
        }

        //Actualiza un registro dado un evento y un id
        [HttpPut("udpate/{id}")]
        public async Task<ActionResult> Update( int id , Events evento )
        {
            if (evento.Id != id)
            {
                return BadRequest(new { message = $"El ID({id}) de la URL no coincide con el ID({evento.Id}) del cuerpo de la solicitud."});
            }

            var eventToUpdate = await eventService.GetById(id);

            if(eventToUpdate is not null)
            {
                await eventService.Update(id, evento);
                return Accepted( new { message = $"Registro actualizado con exito"});
            }

            dbContext.Update(evento);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
       
            var eventToDelete = await eventService.GetById(id);

            if (eventToDelete is not null)
            {
                await eventService.Delete(id);
                return Accepted(new { message = $"Registro borrado con exito" });
            }
            else
            {
                return BadRequest("No existe el evento");
            }

        }

   

    }
}
