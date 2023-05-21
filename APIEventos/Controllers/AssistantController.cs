using APIEventos.Entidades;
using APIEventos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIEventos.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AssistantController : ControllerBase
    {

        private readonly EventService eventService;
        private readonly UserService userService;
        private readonly AsistantsService asistantsService;
        private readonly ApplicationDbContext dbContext;

        public AssistantController(EventService eventService, UserService userService, AsistantsService asistantsService, ApplicationDbContext dbContext)
        {
            this.eventService = eventService;   
            this.userService = userService;
            this.asistantsService = asistantsService;
            this.dbContext = dbContext;
        }
        [HttpGet("get")]
        public async Task<ActionResult<List<Asistants>>> Get()
        {
            return await dbContext.Asistants.Include(a => a.Event)
                .Include(a => a.User)
                .ToListAsync();
        
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(int userId , int eventId)
        {
            string result = await asistantsService.Validate(userId, eventId);
            if (result != "Valid") {
                return BadRequest(result);
            }

            var asistant = await asistantsService.Create(userId, eventId);

            return Accepted(new { message = $"Registro actualizado con exito" });

        }


        



    }
}
