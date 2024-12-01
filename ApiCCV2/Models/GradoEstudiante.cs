namespace ApiCCV2.Models
{
    public class GradoEstudiante
    {
        public int GradoId { get; set; }
        public Grado Grado { get; set; }
        public int EstudianteId { get; set; }   
        public Estudiante Estudiante { get; set; }
    }
}
