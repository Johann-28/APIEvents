using APIEventos.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APIEventos.Services
{
    public class CommentServices
    {
        private readonly ApplicationDbContext dbContext;

        public CommentServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CommentDTO>> GetDto()
        {
            return await dbContext.Comments.Select(c => new CommentDTO { 
                Name = c.User.Name,
                Type = c.Type == 1 ? "Pregunta" : "Comentario",
                Comment = c.Comment
            }).ToListAsync();
        }
    }
}
