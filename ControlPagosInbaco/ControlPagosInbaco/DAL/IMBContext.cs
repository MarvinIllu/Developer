using ControlPagosInbaco;
using ControlPagosInbaco.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyApplication.DAL
{
    public class IMBContext : IdentityDbContext<ApplicationUser>
    {

        public IMBContext() : base("MyDbContextConnectionString")
        {
            Database.SetInitializer(new MySqlInitializer()); //(we do not want to seed) so just do not initialize database
        }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Seccion> Secciones { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<CicloEscolar> Ciclos { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<Establecimiento> Establecimientos { get; set; }
        public DbSet<TipoUsuario>TiposUsuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!

            modelBuilder.Entity<ApplicationUser>().ToTable("users");
            modelBuilder.Entity<IdentityRole>().ToTable("roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("userroles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("userclaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("userlogins");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static IMBContext Create()
        {
            return new IMBContext();
        }
    }
}