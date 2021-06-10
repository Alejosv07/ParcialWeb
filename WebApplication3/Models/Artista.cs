using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebApplication3.Models
{
    public class Artista
    {
        [Key]
        [Display(Name = "Código del artista")]
        public int Idartista { set; get; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Nombre { set; get; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Apellido { set; get; }

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fechanacimiento { set; get; }

        [Display(Name = "Lugar de nacimiento")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Lugarnacimiento { set; get; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Email { set; get; }

        public virtual ICollection<Disco> ListDiscos { set; get; }

    }
}