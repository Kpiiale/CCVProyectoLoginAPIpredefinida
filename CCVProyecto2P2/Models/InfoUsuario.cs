using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCVProyecto2P2.Models
{
    public class InfoUsuario
    {

        [Key]
        public int Id { get; set; }
       
       
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Usuario")]
        [MaxLength(150)]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Contraseña")]
        [StringLength(10)]
        public string Contrasenia { get; set; }
        public int RolUsuario { get; set; }
    }
}
