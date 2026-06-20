using System;
using System.Data;
using PryAccesoDatos;
using PryEntidades;

namespace PryLogicaNegocio
{
    public class ClsEstudiantesLn
    {
        #region Variables privadas
        private ClsAccesoDatos ObjDataBase = null;
        #endregion

        #region Index/Ejecutar
        public void Index(ref ClsEstudiantes objEstudiante)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Estudiantes",
                NombreSP = "[dbo].SP_Index_Estudiantes",
                Scalar = false
            };
            Ejecutar(ref objEstudiante);
        }

        private void Ejecutar(ref ClsEstudiantes objEstudiante)
        {
            try
            {
                ObjDataBase.CRUD(ObjDataBase);
                if (ObjDataBase.MensajeErrorOS == null)
                {
                    if (ObjDataBase.Scalar)
                    {
                        objEstudiante.ValorScalar = ObjDataBase.ValorScalar;
                    }
                    else
                    {
                        objEstudiante.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    }
                }
                else
                {
                    objEstudiante.MensajeError = ObjDataBase.MensajeErrorOS;
                }
            }
            catch (Exception ex)
            {
                objEstudiante.MensajeError = "Ocurrió un error al ejecutar la consulta: " + ex.Message;
            }
        }
        #endregion

        #region CRUD Estudiantes
        public void CreateEstudiante(ref ClsEstudiantes objEstudiante)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Estudiantes",
                NombreSP = "[dbo].SP_Estudiante_Create",
                Scalar = false
            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdEstudiante", "16", objEstudiante.IdEstudiante);
            ObjDataBase.DtParametros.Rows.Add(@"@NombreEstudiante", "16", objEstudiante.NombEstudiante);
            ObjDataBase.DtParametros.Rows.Add(@"@ApellidoEstudiante", "16", objEstudiante.ApellEstudiante);
            ObjDataBase.DtParametros.Rows.Add(@"@Programa", "16", objEstudiante.Programa);
            ObjDataBase.DtParametros.Rows.Add(@"@Telefono", "16", objEstudiante.Telefono);
            ObjDataBase.DtParametros.Rows.Add(@"@Beca", "16", objEstudiante.Beca);
            ObjDataBase.DtParametros.Rows.Add(@"@FechaRegistro", "11", objEstudiante.FechaRegistro);
            Ejecutar(ref objEstudiante);
        }

        public void DeleteEstudiante(ref ClsEstudiantes objEstudiante)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Estudiantes",
                NombreSP = "[dbo].SP_Estudiante_Delete",
                Scalar = false
            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdEstudiante", "16", objEstudiante.IdEstudiante);
            Ejecutar(ref objEstudiante);
        }

        public void FilterEstudiante(ref ClsEstudiantes objEstudiante)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreTabla = "Estudiantes",
                NombreSP = "[dbo].SP_Estudiante_Filter",
                Scalar = false
            };
            ObjDataBase.DtParametros.Rows.Add(@"@Programa", "16", objEstudiante.Programa);
            Ejecutar(ref objEstudiante);
        }
        #endregion

        #region VALIDAR ID
        public bool IdEstudianteExiste(string idEstudiante)
        {
            ObjDataBase = new ClsAccesoDatos()
            {
                NombreSP = "SP_CheckIdEstudianteExists",
                Scalar = true
            };

            ObjDataBase.DtParametros.Rows.Add(@"@IdEstudiante", "16", idEstudiante);
            ObjDataBase.CRUD(ObjDataBase);

            if (ObjDataBase.MensajeErrorOS == null)
            {
                return ObjDataBase.ValorScalar.ToString() == "1";
            }
            else
            {
                throw new Exception(ObjDataBase.MensajeErrorOS);
            }
        }
        #endregion
    }
}
