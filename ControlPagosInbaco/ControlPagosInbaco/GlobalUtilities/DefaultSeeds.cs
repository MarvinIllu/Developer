using ControlPagosInbaco.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ControlPagosInbaco.GlobalUtilities
{
    /// <summary>
    /// Creado por @MaxPinto, para carga original de administrador
    /// </summary>
    public class DefaultSeeds
    {
        /// <summary>
        /// Retorna usuario por defecto a crear
        /// </summary>
        /// <returns></returns>
        public static TMPUser getDefaultUserToCreate()
        {
            TMPUser defaultUser;
            string json = exitsConfigFile("defaultusercreate.json");
            try
            {
                defaultUser = JsonConvert.DeserializeObject<TMPUser>(json);
            }
            catch
            {
                defaultUser = null;
            }

            if (defaultUser == null)
            {
                throw new Exception("Archivo defaultusercreate.json no Existe o no ha sido llenado");
            }

            return defaultUser;
        }

        /// <summary>
        /// Obtiene listado de usuarios a crear en Seed
        /// </summary>
        /// <returns></returns>
        public static TMPTipoUsuarioList getTipoUsuariosConfig()
        {
            TMPTipoUsuarioList tipoUsuarioList = new TMPTipoUsuarioList();
            string json = exitsConfigFile("typeusers.json");
            try
            {
                tipoUsuarioList.types = JsonConvert.DeserializeObject< List<TipoUsuario>>(json);
            }
            catch
            {
                tipoUsuarioList = null;
            }

            if (tipoUsuarioList == null)
            {
                throw new Exception("Archivo typeusers.json no Existe o no ha sido llenado");
            }

            return tipoUsuarioList;
        }

        /// <summary>
        /// Lee y retorna información de archivo que contiene informacion de usuario
        /// </summary>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        private static string exitsConfigFile(string _fileName)
        {
            try
            {
                string rootDir = HttpContext.Current.Server.MapPath("~/");
                string file = Path.Combine(rootDir, _fileName);
                return File.ReadAllText(@file);
            }
            catch
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Clase utilizada para serializar objetos desde archivo json
    /// </summary>
    public class TMPUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string IdTipoUsuario { get; set; }
    }


    public class TMPTipoUsuarioList
    {
        public List<TipoUsuario> types { get; set; }
    }
}