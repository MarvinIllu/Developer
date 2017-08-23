namespace ControlPagosInbaco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articulo",
                c => new
                    {
                        IdArticulo = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.IdArticulo);
            
            CreateTable(
                "dbo.CicloEscolar",
                c => new
                    {
                        IdCiclo = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, unicode: false),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.String(unicode: false),
                        FechaModificacion = c.String(unicode: false),
                        IdUsuario = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.IdCiclo);
            
            CreateTable(
                "dbo.Establecimiento",
                c => new
                    {
                        IdEstablecimiento = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, unicode: false),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.String(unicode: false),
                        FechaModificacion = c.String(unicode: false),
                        IdUsuario = c.String(unicode: false),
                        Nombre = c.String(nullable: false, unicode: false),
                        Logo = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.IdEstablecimiento);
            
            CreateTable(
                "dbo.Grado",
                c => new
                    {
                        IdGrado = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, unicode: false),
                        estado = c.Boolean(nullable: false),
                        IdEstablecimiento = c.Long(nullable: false),
                        FechaCreacion = c.String(unicode: false),
                        FechaModificacion = c.String(unicode: false),
                        IdUsuario = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.IdGrado)
                .ForeignKey("dbo.Establecimiento", t => t.IdEstablecimiento, cascadeDelete: true)
                .Index(t => t.IdEstablecimiento);
            
            CreateTable(
                "dbo.Seccion",
                c => new
                    {
                        IdSeccion = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, unicode: false),
                        Estado = c.Boolean(nullable: false),
                        IdGrado = c.Long(nullable: false),
                        FechaCreacion = c.String(unicode: false),
                        FechaModificacion = c.String(unicode: false),
                        IdUsuario = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.IdSeccion)
                .ForeignKey("dbo.Grado", t => t.IdGrado, cascadeDelete: true)
                .Index(t => t.IdGrado);
            
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        IdPerfil = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, unicode: false),
                        Usuario = c.String(unicode: false),
                        NombreCompleto = c.String(nullable: false, unicode: false),
                        Codigo = c.String(unicode: false),
                        Telefono = c.String(unicode: false),
                        Direccion = c.String(unicode: false),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.String(unicode: false),
                        FechaModificacion = c.String(unicode: false),
                        IdUsuario = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.IdPerfil);
            
            CreateTable(
                "dbo.TipoUsuario",
                c => new
                    {
                        IdTipoUsuario = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Descripcion = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.IdTipoUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seccion", "IdGrado", "dbo.Grado");
            DropForeignKey("dbo.Grado", "IdEstablecimiento", "dbo.Establecimiento");
            DropIndex("dbo.Seccion", new[] { "IdGrado" });
            DropIndex("dbo.Grado", new[] { "IdEstablecimiento" });
            DropTable("dbo.TipoUsuario");
            DropTable("dbo.Perfil");
            DropTable("dbo.Seccion");
            DropTable("dbo.Grado");
            DropTable("dbo.Establecimiento");
            DropTable("dbo.CicloEscolar");
            DropTable("dbo.Articulo");
        }
    }
}
