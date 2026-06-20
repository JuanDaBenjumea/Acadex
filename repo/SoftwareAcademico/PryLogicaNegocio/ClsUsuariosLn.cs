using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PryAccesoDatos;
using PryEntidades;
namespace PryLogicaNegocio
{
    public class ClsUsuariosLn
    {
        #region Variables Publicas
        private ClsAccesoDatos ObjDataBase = null;
        #endregion

        #region VALIDAR DATOS
        private ClsAccesoDatos accesoDatos;

        public ClsUsuariosLn()
        {
            accesoDatos = new ClsAccesoDatos();
        }

        public string ValidarUsuario(string usuario, string contraseña)
        {
            // Llamar al método de validación de la clase de acceso a datos
            return accesoDatos.ValidarUsuario(usuario, contraseña);
        }

       

        #endregion
    }
}
