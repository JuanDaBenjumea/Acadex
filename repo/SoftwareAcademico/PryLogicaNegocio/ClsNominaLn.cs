using System;
using System.Data;
using PryAccesoDatos;
using PryEntidades;

namespace PryLogicaNegocio
{
    public class ClsNominaLn
    {
        #region Variables privadas
        private ClsAccesoDatos ObjDataBase = null;
        #endregion

        #region Index/Ejecutar
        public void Index(ref ClsNomina objNomina)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Nominas",
                NombreSP = "SP_Index_Nominas",
                Scalar = false
            };
            Ejecutar(ref objNomina);
        }

        public void Ejecutar(ref ClsNomina objNomina)
        {
            try
            {
                ObjDataBase.CRUD(ObjDataBase);
                if (ObjDataBase.MensajeErrorOS == null)
                {
                    if (ObjDataBase.Scalar)
                    {
                        objNomina.ValorScalar = ObjDataBase.ValorScalar;
                    }
                    else
                    {
                        objNomina.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    }
                }
                else
                {
                    objNomina.MensajeError = ObjDataBase.MensajeErrorOS;
                }
            }
            catch (Exception ex)
            {
                objNomina.MensajeError = "Ocurrió un error al ejecutar la consulta: " + ex.Message;
            }
        }

        #endregion

        #region CRUD NOMINA
        public void CreateNomina(ref ClsNomina objNomina)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Nominas",
                NombreSP = "[dbo].SP_Nomina_Create",
                Scalar = false
            };
            ObjDataBase.DtParametros.Rows.Add(@"@Nombre", "16", objNomina.Nombre);
            ObjDataBase.DtParametros.Rows.Add(@"@Apellido", "16", objNomina.Apellido);
            ObjDataBase.DtParametros.Rows.Add(@"@Facultad", "16", objNomina.Facultad);
            ObjDataBase.DtParametros.Rows.Add(@"@SalarioContrato", "4", objNomina.SalarioContrato);
            ObjDataBase.DtParametros.Rows.Add(@"@HoraExtra", "4", objNomina.HoraExtra);
            ObjDataBase.DtParametros.Rows.Add(@"@PagoXHoraExtra", "4", objNomina.PagoHoraExtra);
            ObjDataBase.DtParametros.Rows.Add(@"@TotalHoraExtra", "4", objNomina.TotalHoraExtra);
            ObjDataBase.DtParametros.Rows.Add(@"@SalarioNeto", "4", objNomina.SalarioNeto);
            ObjDataBase.DtParametros.Rows.Add(@"@FechaRegistro", "11", objNomina.FechaRegistro);
            Ejecutar(ref objNomina);
        }

        public void DeleteNomina(ref ClsNomina objNomina)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Nominas",
                NombreSP = "[dbo].SP_Nomina_Delete",
                Scalar = false
            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdNomina", "4", objNomina.IdNomina);
            Ejecutar(ref objNomina);
        }

        public void FilterNomina(ref ClsNomina objNomina)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Nominas",
                NombreSP = "[dbo].SP_Nomina_Filter",
                Scalar = false
            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdNomina", "4", objNomina.IdNomina);
            Ejecutar(ref objNomina);
        }
        #endregion

        #region Obtener Datos del docente
        public void ObtenerDatosDocente(string idDocente, out string nombre, out string apellido, out string facultad, out int salario)
        {
            nombre = string.Empty; apellido = string.Empty; facultad = string.Empty; salario = 0;
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Docentes",
                NombreSP = "[dbo].[SP_DatosDocenteById]",
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
                        salario = Convert.ToInt32(row["Salario"]);
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
        }
        #endregion

    }
}
