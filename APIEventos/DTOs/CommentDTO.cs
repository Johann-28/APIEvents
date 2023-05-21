using APIEventos.Entidades;

namespace APIEventos.DTOs
{
    public class CommentDTO
    {
        public string Name { get; set; }
        public string Type { get; set; } //1: Pregunta , 2: Comentario
        public string Comment { get; set; }

    }
}
