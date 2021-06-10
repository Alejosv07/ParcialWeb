using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Cliente
    {
        [Key]
        [Display(Name = "Código de pedido")]
        public int Idcliente { set; get; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Nombres { set; get; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Apellidos { set; get; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Direccion { set; get; }

        public virtual ICollection<Pedido> ListPedidos { set; get; }


    }
}