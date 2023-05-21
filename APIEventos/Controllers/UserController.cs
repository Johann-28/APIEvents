using APIEventos.Entidades;
using APIEventos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIEventos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;


        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

    
        //Regresa todos los registros de la tabla eventos
        [HttpGet("getall")]
        public async Task<ActionResult<List<Users>>> GetAll()
        {
            return await dbContext.Users.Include(a => a.Asistants).ToListAsync();
        
        }

        //Añade un parametro a la base de datos
        [HttpPost("create")]
        public async Task<IActionResult> Create(Users user)
        {

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
