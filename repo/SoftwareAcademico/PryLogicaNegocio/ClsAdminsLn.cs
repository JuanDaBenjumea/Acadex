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
    public class Class1
    {
        //Acceso a la clase AccesoDatos
        #region Variables privadas
        private ClsAccesoDatos ObjDataBase = null;
        #endregion

        //Metodo index y ejecutar
        #region Index/Ejecutar
        public void Index(ref ClsAdministradores objAdmin)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Administradores",
                NombreSP = "SP_Index_Admin",
                Scalar = false
            };
            Ejecutar(ref objAdmin);
        }
        public void Ejecutar(ref ClsAdministradores objAdmin)
        {
            try
            {
                ObjDataBase.CRUD(ObjDataBase);
                if (ObjDataBase.MensajeErrorOS == null)
                {
                    if (ObjDataBase.Scalar)
                    {
                        objAdmin.ValorScalar = ObjDataBase.ValorScalar;
                    }
                    else
                    {
                        objAdmin.DtResultados = ObjDataBase.DsResultados.Tables[0];


                        if (objAdmin.DtResultados.Rows.Count == 1)
                        {
                            DataRow row = objAdmin.DtResultados.Rows[0];

                            // Verificamos si las columnas existen antes de acceder a ellas
                            objAdmin.IdAdmin = row.Table.Columns.Contains("IdAdmin") ? row["IdAdmin"].ToString() : string.Empty;
                            objAdmin.NombAdmin = row.Table.Columns.Contains("NombreAdmin") ? row["NombreAdmin"].ToString() : string.Empty;
                            objAdmin.ApelliAdmin = row.Table.Columns.Contains("ApellidoAdmin") ? row["ApellidoAdmin"].ToString() : string.Empty;
                            objAdmin.UserAdmin = row.Table.Columns.Contains("Usuario") ? row["Usuario"].ToString() : string.Empty;
                            objAdmin.PassAdmin = row.Table.Columns.Contains("Contra") ? row["Contra"].ToString() : string.Empty;
                            objAdmin.FechaRegistro = row.Table.Columns.Contains("FechaRegistro") ? Convert.ToDateTime(row["FechaRegistro"]) : DateTime.MinValue;
                        }
                    }
                }
                else
                {
                    objAdmin.MensajeError = ObjDataBase.MensajeErrorOS;
                }
            }
            catch (Exception ex)
            {
                objAdmin.MensajeError = "Error al ejecutar el procedimiento almacenado: " + ex.Message;
            }
        }




        #endregion

        #region CRUD Administradores

        //Metodo Crear Administrador
        public void CreateAdmin(ref ClsAdministradores objAdmin)
        {
            //Crea una nueva conexion con la clase acceso a datos
            ObjDataBase = new ClsAccesoDatos()
            {
                //Nombre de la tabla de la base de datos
                NombreTabla = "Administradores",
                //Nombre del Procedimiento Almacenado
                NombreSP = "SP_Admin_Create",
                Scalar = false
            };
            //Se le pasan los parametros para que ejecute la consulta,
            //@variable + tipo de dato + atributo de la clase
            ObjDataBase.DtParametros.Rows.Add(@"@IdAdmin", "16", objAdmin.IdAdmin);
            ObjDataBase.DtParametros.Rows.Add(@"@NombreAdmin", "16", objAdmin.NombAdmin);
            ObjDataBase.DtParametros.Rows.Add(@"@ApellidoAdmin", "16", objAdmin.ApelliAdmin);
            ObjDataBase.DtParametros.Rows.Add(@"@Usuario", "16", objAdmin.UserAdmin);
            ObjDataBase.DtParametros.Rows.Add(@"Contra", "16", objAdmin.PassAdmin);
            ObjDataBase.DtParametros.Rows.Add(@"@FechaRegistro", "11", objAdmin.FechaRegistro);
            Ejecutar(ref objAdmin);
        }

        //Metodo Eliminar Administrador
        public void DeleteAdmin(ref ClsAdministradores objAdmin)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Administradores",
                NombreSP = "[dbo].SP_Admin_Delete",
                Scalar = false
            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdAdmin", "16", objAdmin.IdAdmin);
            Ejecutar(ref objAdmin);
        }
        #endregion


        //Metodo que valida si el administrador creado tiene de usuario/id uno ya existente
        #region Usuario/ID Existente
        public string UsuarioExiste(string usuario)
        {
            ClsAccesoDatos accesoDatos = new ClsAccesoDatos();
            return accesoDatos.UsuarioExiste(usuario);
        }
        public bool IdAdminExiste(string idAdmin)
        {
            // Crear una nueva conexión con la clase de acceso a datos
            ObjDataBase = new ClsAccesoDatos()
            {
                // Nombre del procedimiento almacenado que deberías crear
                NombreSP = "SP_CheckIdAdminExists",
                Scalar = true  // Dado que esperamos un valor escalar
            };

            // Agregar el parámetro para el ID del administrador
            ObjDataBase.DtParametros.Rows.Add(@"@IdAdmin", "16", idAdmin);

            // Ejecuta la consulta para comprobar si el ID existe
            ObjDataBase.CRUD(ObjDataBase);

            // Verificar si hay error
            if (ObjDataBase.MensajeErrorOS == null)
            {
                // Si el resultado es 1, el ID existe; de lo contrario, no existe
                return ObjDataBase.ValorScalar.ToString() == "1"; // Supone que el SP retorna 1 si existe
            }
            else
            {
                // Manejo de errores si hay un problema al ejecutar
                throw new Exception(ObjDataBase.MensajeErrorOS);
            }
        }

        #endregion

    }
}
