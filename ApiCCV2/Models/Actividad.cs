namespace ApiCCV2.Models
{
    public class Actividad
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaEntrega { get; set; }
        public ICollection<ClaseActividad> ClaseActividades { get; set; }
        public ICollection<ActividadEstudiante> ActividadEstudiantes { get; set; }
        public ICollection<ActividadProfesor> ActividadProfesores { get; set; }
    }

}
