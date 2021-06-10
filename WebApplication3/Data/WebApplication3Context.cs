using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Data
{
    public class WebApplication3Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebApplication3Context() : base("name=WebApplication3Context")
        {
        }

        public System.Data.Entity.DbSet<WebApplication3.Models.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<WebApplication3.Models.Artista> Artistas { get; set; }

        public System.Data.Entity.DbSet<WebApplication3.Models.Cancion> Cancions { get; set; }

        public System.Data.Entity.DbSet<WebApplication3.Models.Disco> Discoes { get; set; }

        public System.Data.Entity.DbSet<WebApplication3.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<WebApplication3.Models.Empleado> Empleadoes { get; set; }

        public System.Data.Entity.DbSet<WebApplication3.Models.Pedido> Pedidoes { get; set; }

        public System.Data.Entity.DbSet<WebApplication3.Models.Detallepedido> Detallepedidoes { get; set; }
    }
}
