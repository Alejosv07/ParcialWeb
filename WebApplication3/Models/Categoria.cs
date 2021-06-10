using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Categoria
    {
        [Key]
        [Display(Name = "Código de categoria")]
        public int Idcategoria { set; get; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Ccategoria { set; get; }

        //relaciones
        public virtual ICollection<Disco> ListDiscos { set; get; }
    }
}