using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Detallepedido
    {
        [Key]
        [Display(Name = "Código de detalle pedido")]
        public int Iddetalle { set; get; }

        [Display(Name = "Código de pedido")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int Idpedido { set; get; }

        [Display(Name = "Código de disco")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int Iddiscos { set; get; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int Cantidad { set; get; }

        [Display(Name = "Precio de venta")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public double Precioventa { set; get; }

        //relaciones
        public Pedido Pedido { set; get; }

        public Disco Disco { set; get; }
    }
}