using ControlPagosInbaco.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyApplication.DAL
{
    public class IMBContext : DbContext
    {

        public IMBContext() : base("MyDbContextConnectionString")
        {
            //Database.SetInitializer<IMBContext>(new MyDbInitializer()); (we do not want to seed) so just do not initialize database
        }

        public DbSet<ABCModelos.Articulo> Articulos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}