using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DrogNet.Models;

namespace DrogNet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DrogNet.Models.Cliente> Cliente { get; set; }
        public DbSet<DrogNet.Models.Vendedor> Vendedor { get; set; }
        public DbSet<DrogNet.Models.TipoMedicamento> TipoMedicamento { get; set; }
        public DbSet<DrogNet.Models.Producto> Producto { get; set; }
        public DbSet<DrogNet.Models.TipoPago> TipoPago { get; set; }
        public DbSet<DrogNet.Models.Factura> Factura { get; set; }
        public DbSet<DrogNet.Models.VentaProducto> VentaProducto { get; set; }
        public DbSet<DrogNet.Models.QuejaSugerencia> QuejaSugerencia { get; set; }
    }
}
