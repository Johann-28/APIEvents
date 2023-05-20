namespace APIEventos.Entidades
{
    public class Events
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public string Descripcion { get; set; }

        public DateTime Date { get; set; }  
        
        public string Ubicacion { get; set; }

        public int Capacidad { get; set; }

        public ICollection<Asistants> Assistans { get; set; }
        
    }
}
