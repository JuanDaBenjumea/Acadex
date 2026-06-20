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
    public class ClsDocentesLn
    {
        #region Variables privadas
        private ClsAccesoDatos ObjDataBase = null;
        #endregion


        #region Metodos Index/Ejecutar
        public void Index(ref ClsDocentes objDocente)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Docentes",
                NombreSP = "[dbo].SP_Index_Docentes",
                Scalar = false
            };
            Ejecutar(ref objDocente);
        }
        public void Ejecutar(ref ClsDocentes objDocente)
        {
            try
            {
                ObjDataBase.CRUD(ObjDataBase);
                if (ObjDataBase.MensajeErrorOS == null)
                {
                    if (ObjDataBase.Scalar)
                    {
                        objDocente.ValorScalar = ObjDataBase.ValorScalar;
                    }
                    else
                    {
                        objDocente.DtResultados = ObjDataBase.DsResultados.Tables[0];
                        // Procesar resultados
                    }
                }
                else
                {
                    objDocente.MensajeError = ObjDataBase.MensajeErrorOS; 
                }
            }
            catch (Exception ex)
            {
                objDocente.MensajeError = "Ocurrió un error al ejecutar la consulta: " + ex.Message;
            }
        }

        #endregion


        #region CRUD Docentes
        public void CreateDocente(ref ClsDocentes objDocente)
        {
            //Crea una nueva conexion con la clase acceso a datos
            ObjDataBase = new ClsAccesoDatos()
            {
                //Nombre de la tabla de la base de datos
                NombreTabla = "Docentes",
                //Nombre del Procedimiento Almacenado
                NombreSP = "[dbo].SP_Docente_Create",
                Scalar = false
            };
            //Se le pasan los parametros para que ejecute la consulta,
            //@variable + tipo de dato + atributo de la clase
            ObjDataBase.DtParametros.Rows.Add(@"@IdDocente", "16", objDocente.IdDocente);
            ObjDataBase.DtParametros.Rows.Add(@"@NombreDocente", "16", objDocente.NombDocente);
            ObjDataBase.DtParametros.Rows.Add(@"@ApellidoDocente", "16", objDocente.ApellDocente);
            ObjDataBase.DtParametros.Rows.Add(@"@Telefono", "16", objDocente.Telefono);
            ObjDataBase.DtParametros.Rows.Add(@"@Facultad", "16", objDocente.Facultad);
            ObjDataBase.DtParametros.Rows.Add(@"@Salario", "4", objDocente.Salario);
            ObjDataBase.DtParametros.Rows.Add(@"@FechaRegistro", "11", objDocente.FechaRegistro);
            Ejecutar(ref objDocente);
        }

        public void DeleteDocente(ref ClsDocentes objDocente)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Docentes",
                NombreSP = "[dbo].SP_Docente_Delete",
                Scalar = false
            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdDocente", "16", objDocente.IdDocente);
            Ejecutar(ref objDocente);
        }

        public void FilterDocente(ref ClsDocentes objDocente)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Docentes",
                NombreSP = "[dbo].SP_Docente_Filter",  // Asegúrate de que el nombre sea correcto
                Scalar = false
            };

            // Añadir parámetros
            ObjDataBase.DtParametros.Rows.Add(@"@Facultad", "16", objDocente.Facultad);

            // Ejecutar la operación
            Ejecutar(ref objDocente);

            // Verificar si se recibieron resultados
            if (objDocente.DtResultados == null || objDocente.DtResultados.Rows.Count == 0)
            {
                objDocente.MensajeError = "No se encontraron docentes para la facultad seleccionada.";
            }
        }
        #endregion

        //Validar Id para controlar los docentes ya existentes
        #region VALIDAR ID  
        public bool IdDocenteExiste(string idDocente)
        {
            // Crear una nueva conexión con la clase de acceso a datos
            ObjDataBase = new ClsAccesoDatos()
            {
                // Nombre del procedimiento almacenado que deberías crear
                NombreSP = "SP_CheckIdDocenteExists",
                Scalar = true  // Dado que esperamos un valor escalar
            };

            // Agregar el parámetro para el ID del administrador
            ObjDataBase.DtParametros.Rows.Add(@"@IdDocente", "16", idDocente);

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
