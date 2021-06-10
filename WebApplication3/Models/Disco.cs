using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Disco
    {
        [Key]
        [Display(Name = "Código de disco")]
        public int Iddiscos { set; get; }

        [Display(Name = "Código de categoria")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int Idcategoria { set; get; }

        [Display(Name = "Código de artista")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int Idartista { set; get; }

        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Titulo { set; get; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { set; get; }

        [Display(Name = "Formato")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Formato { set; get; }

        [Display(Name = "Número de canciones")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int Numerocanciones { set; get; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public double Precio { set; get; }

        [Display(Name = "Observaciones")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Observaciones { set; get; }

        [Display(Name = "Imagen")]
        public string Imagen { set; get; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public virtual ICollection<Detallepedido> ListaDetPedidos { set; get; }

        public Categoria Categoria { set; get; }

        public virtual ICollection<Cancion> ListCanciones { set; get; }

        public Artista Artista { set; get; }
    }
}