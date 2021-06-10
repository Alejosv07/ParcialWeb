using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Pedido
    {

        [Key]
        [Display(Name = "Código de pedido")]
        public int Idpedido { set; get; }

        [Display(Name = "Fecha de pedido")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fechapedido { set; get; }

        [Display(Name = "Código de cliente")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int Idcliente { set; get; }

        [Display(Name = "Código de empleado")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int Idempleado { set; get; }

        [Display(Name = "Direccion de entrega")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Direccionentrega { set; get; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int Estado { set; get; }

        //relaciones cliente , empleado
        public Cliente Cliente { set; get; }
        public Empleado Empleado { set; get; }

        public virtual ICollection<Detallepedido> ListDetPedidos { set; get; }
    }
}