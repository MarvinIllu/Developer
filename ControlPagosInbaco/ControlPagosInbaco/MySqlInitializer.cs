using ControlPagosInbaco.Models;
using MyApplication.DAL;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ControlPagosInbaco.GlobalUtilities;

namespace ControlPagosInbaco
{
    public class MySqlInitializer : CreateDatabaseIfNotExists<IMBContext>
    {
        protected override void Seed(IMBContext context)
        {
            //we must create tipo usuario records.
            TMPTipoUsuarioList tipoUsuarioList =  DefaultSeeds.getTipoUsuariosConfig();
            foreach(TipoUsuario tipoUsuario in tipoUsuarioList.types)
            {
                context.TiposUsuario.Add(tipoUsuario);
                context.SaveChanges();
            }


            TMPUser defaultUser = DefaultSeeds.getDefaultUserToCreate();
            ///create at Least one user
            if (!(context.Users.Any(u => u.UserName == defaultUser.Email)))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = defaultUser.Email, Email = defaultUser.Email, IdTipoUsuario = defaultUser.IdTipoUsuario };
                userManager.Create(userToInsert, defaultUser.Password);
            }

            base.Seed(context);
        }
    }
}