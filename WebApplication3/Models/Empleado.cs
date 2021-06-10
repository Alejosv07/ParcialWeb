using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Empleado
    {
        [Key]
        [Display(Name = "Código de empleado")]
        public int Idempleado { set; get; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Nombres { set; get; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Apellidos { set; get; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Direccion { set; get; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Login { set; get; }

        [Display(Name = "Clave")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Clave { set; get; }

        public virtual ICollection<Pedido> ListPedidos { set; get; }
    }
}