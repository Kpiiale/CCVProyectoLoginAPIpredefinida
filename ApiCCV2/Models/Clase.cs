﻿using System.ComponentModel.DataAnnotations;

namespace ApiCCV2.Models
{
    public class Clase
    {
        [Key]
        public int Id { get; set; }
        
        public ICollection<ClaseEstudiante> ClaseEstudiantes { get; set; }
        public ICollection<ClaseProfesor> ClaseProfesores { get; set; }
        public ICollection<ClaseActividad> ClaseActividades { get; set; }
    }
}
