using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControlPagosInbaco.Models;
using MyApplication.DAL;
using ControlPagosInbaco.Constants;
using Microsoft.AspNet.Identity;
using System.Security.Principal;

namespace ControlPagosInbaco.GlobalUtilities
{
    /// <summary>
    /// Created By @MaxPinto 23-08-2017
    /// Funciones globales a reutilizar desde cualquier instancia
    /// </summary>
    public class GlobalFunctions
    {
        /// <summary>
        /// Retorna la fecha actual para almacenar en base de datos
        /// </summary>
        /// <returns></returns>
        public static string currentDateTime()
        {
            string retCurrrDateTime;

            try
            {
                DateTime currentDatetime = DateTime.Now;
                retCurrrDateTime = currentDatetime.ToString("yyyy-MM-dd HH:mm");
            }
            catch
            {
                retCurrrDateTime = DateTime.MinValue.ToString();
            }
            
            return retCurrrDateTime;
        }

        /// <summary>
        /// Retorna el usuario actual logueado, invocado desde un controller
        /// </summary>
        /// <param name="_controller"></param>
        /// <returns></returns>
        public static string currentUserId(Controller _controller)
        {
            string currentUserId = _controller.User.Identity.GetUserId();
            if (currentUserId == null)
            {
                currentUserId = "";
            }
            return currentUserId;
        }
    }
}