using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCVProyecto2P2.Models
{
    public enum RolEnum
    {
        Administrador,
        Estudiante,
        Profesor
    }
    public class Usuario
    {
        
        public int Id { get; set; }
       
        public string Cedula { get; set; }
       
        public string Nombre { get; set; }
        
        public string NombreUsuario { get; set; }
        
        public string Contrasenia { get; set; }
      
        public int Edad { get; set; }
        
        public RolEnum Rol { get; set; }
    }
}
