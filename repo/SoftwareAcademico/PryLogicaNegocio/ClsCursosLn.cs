using System;
using System.Data;
using PryAccesoDatos;
using PryEntidades;

namespace PryLogicaNegocio
{
    public class ClsCursosLn
    {
        #region Variables privadas
        private ClsAccesoDatos ObjDataBase = null;
        #endregion

        #region Métodos Index/Ejecutar
        public void Index(ref ClsCursos objCurso)
        {
            ObjDataBase = new ClsAccesoDatos
            {
                NombreTabla = "Cursos",
                NombreSP = "[dbo].SP_Index_Cursos",
                Scalar = false
            };
            Ejecutar(ref objCurso);
        }

        public void Ejecutar(ref ClsCursos objCurso)
        {
            try
            {
                ObjDataBase.CRUD(ObjDataBase);
                if (ObjDataBase.MensajeErrorOS == null)
                {
                    if (ObjDataBase.Scalar)
                    {
                        objCurso.ValorScalar = ObjDataBase.ValorScalar;
                    }
                    else if (ObjDataBase.DsResultados.Tables.Count > 0 && ObjDataBase.DsResultados.Tables[0].Rows.Count > 0)
                    {
                        objCurso.DtResultados = ObjDataBase.DsResultados.Tables[0];
                        // Procesar resultados si es necesario
                    }
                    else
                    {
                        objCurso.MensajeError = "No se encontraron resultados.";
                    }
                }
                else
                {
                    objCurso.MensajeError = ObjDataBase.MensajeErrorOS;
                }
            }
            catch (Exception ex)
            {
                objCurso.MensajeError = "Ocurrió un error al ejecutar la consulta: " + ex.Message;
            }
            finally
            {
                ObjDataBase = null; // Liberar el objeto
            }
        }
        #endregion

        #region CRUD CURSOS
        public void CreateCurso(ref ClsCursos objCurso)
        {
            ObjDataBase = new ClsAccesoDatos
            {
                NombreTabla = "Cursos",
                NombreSP = "[dbo].SP_Curso_Create",
                Scalar = false
            };

            // No se pasa el IdCurso ya que es autoincremental
            ObjDataBase.DtParametros.Rows.Add(@"@NombreCurso", "16", objCurso.Nombcurso);
            ObjDataBase.DtParametros.Rows.Add(@"@CantCreditos", "4", objCurso.CantCreditos);
            ObjDataBase.DtParametros.Rows.Add(@"@NumEstudiantes", "4", objCurso.NumEstudiantes);
            ObjDataBase.DtParametros.Rows.Add(@"@IdDocente", "16", objCurso.IdDocente);
            ObjDataBase.DtParametros.Rows.Add(@"@Facultad", "16", objCurso.Facultad);
            ObjDataBase.DtParametros.Rows.Add(@"@FechaRegistro", "11", objCurso.FechaRegistro);

            Ejecutar(ref objCurso);
        }

        public void DeleteCurso(ref ClsCursos objCurso)
        {
            ObjDataBase = new ClsAccesoDatos
            {
                NombreTabla = "Cursos",
                NombreSP = "[dbo].SP_Curso_Delete",
                Scalar = false
            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdCurso", "4", objCurso.IdCurso);
            Ejecutar(ref objCurso);
        }
        #endregion

        #region Obtener Datos Docente
        public void ObtenerDatosDocente(string idDocente, out string nombre, out string apellido, out string facultad)
        {
            nombre = string.Empty;
            apellido = string.Empty;
            facultad = string.Empty;

            ObjDataBase = new ClsAccesoDatos
            {
                NombreTabla = "Docentes",
                NombreSP = "[dbo].SP_GetDocenteById",
                Scalar = false
            };

            ObjDataBase.DtParametros.Rows.Add(@"@IdDocente", "16", idDocente);

            try
            {
                ObjDataBase.CRUD(ObjDataBase);

                if (ObjDataBase.MensajeErrorOS == null)
                {
                    if (ObjDataBase.DsResultados.Tables.Count > 0 && ObjDataBase.DsResultados.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = ObjDataBase.DsResultados.Tables[0].Rows[0];
                        nombre = row["NombreDocente"].ToString();
                        apellido = row["ApellidoDocente"].ToString();
                        facultad = row["Facultad"].ToString();
                    }
                    else
                    {
                        throw new Exception("No se encontraron datos del docente.");
                    }
                }
                else
                {
                    throw new Exception(ObjDataBase.MensajeErrorOS);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener los datos del docente: " + ex.Message);
            }
            finally
            {
                ObjDataBase = null; // Liberar el objeto
            }
        }
        #endregion
    }
}
