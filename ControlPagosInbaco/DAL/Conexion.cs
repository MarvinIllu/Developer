using System;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class Conexion
    {
        public MySqlConnection cn = new MySqlConnection();

        public bool AbrirConexion()
        {
            //string strConexion = "server=127.0.0.1;User Id=root;password=;database=mydb";
            string strConexion = "server=localhost;" +
                                 "user id=root;" +
                                 "Pwd=;" +
                                 "database=mydb;" +
                                 "port=3306;" +
                                 "Pooling=false;Connection Lifetime=1;" +
                                 "Max Pool Size=1;respect binary flags=false";
            bool resultado;

            try
            {
                this.cn.ConnectionString = strConexion.Trim();
                this.cn.Open();
                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                this.cn.Close();
                this.cn.Dispose();
                throw new System.Exception("Problema al abrir la conexion a la BD " + ex.Message);
            }

            return resultado;
        }

        public bool CerrarConexion()
        {
            bool resultado;

            try
            {
                if (this.cn.State == System.Data.ConnectionState.Open)
                {
                    this.cn.Close();
                    this.cn.Dispose();
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                this.cn.Close();
                this.cn.Dispose();
                throw new System.Exception("Hubo un error al cerrar la conexion " + ex.Message);
            }
            finally
            {
                this.cn.Close();
                this.cn.Dispose();
            }

            return resultado;
        }

    }
}
