using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Cancion
    {
        [Key]
        [Display(Name = "Código de la canción")]
        public int Idcancion { set; get; }

        [Display(Name = "Código de disco")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int Iddisco { set; get; }

        [Display(Name = "Numeró de canción")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int Numero { set; get; }

        [Display(Name = "Tiempo canción")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Tiempo { set; get; }

        [Display(Name = "Canción")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Cancionn { set; get; }
        //relaciones
        public Disco Disco { set; get; }
    }
}