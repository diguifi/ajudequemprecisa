using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AjudeQuemPrecisa.Core.Models.PedidosDeAjuda;

namespace AjudeQuemPrecisa.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PedidoDeAjuda> PedidosDeAjuda { get; set; }        
    }
}
