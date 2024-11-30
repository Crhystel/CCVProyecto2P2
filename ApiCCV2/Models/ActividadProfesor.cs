namespace ApiCCV2.Models
{
    public class ActividadProfesor
    {
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
        public int ActividadId { get; set; }
        public Actividad Actividad { get; set; }
    }
}
