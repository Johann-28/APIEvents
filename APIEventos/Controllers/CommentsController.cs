using Microsoft.AspNetCore.Mvc;
using APIEventos.Entidades;
using Microsoft.EntityFrameworkCore;
using APIEventos.Services;
using APIEventos.DTOs;

namespace APIEventos.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;
        private readonly CommentServices services;

        public CommentsController(ApplicationDbContext dbContext, CommentServices services)
        {
            this.dbContext = dbContext;
            this.services = services;
        }

        [HttpGet("get")]
        public async Task<IEnumerable<CommentDTO>> Get()
        {

            return await services.GetDto();
        }
        [HttpGet("getall")]
        public async Task<List<Comments>> GetAll()
        {
            return await dbContext.Comments.ToListAsync();
        }
    }
}
