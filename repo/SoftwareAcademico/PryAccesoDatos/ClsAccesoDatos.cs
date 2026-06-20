using System.Data.SqlClient;
using System.Data;
using System;

namespace PryAccesoDatos
{
    public class ClsAccesoDatos
    {
        #region VariablesPrivadas
        private SqlConnection _ObjSqlConnection; //Cadena de conexion
        private SqlDataAdapter _ObjSqlDataAdapter; //Consultas Select
        private SqlCommand _ObjSqlCommand; //Consultas tipo Actualización
        private DataSet _dsResultados; //Resultados una varias tablas
        private DataTable _dtParametros;  //Parametros de las tablas-procedimientos
        private string _nombreTabla, _nombreSP, _mensajeErrorOS, _valorScalar, _nombreBD;
        private bool _scalar;


        #endregion

        #region VariablesPublicas
        public SqlConnection ObjSqlConnection { get => _ObjSqlConnection; set => _ObjSqlConnection = value; }
        public SqlDataAdapter ObjSqlDataAdapter { get => _ObjSqlDataAdapter; set => _ObjSqlDataAdapter = value; }
        public SqlCommand ObjSqlCommand { get => _ObjSqlCommand; set => _ObjSqlCommand = value; }
        public DataSet DsResultados { get => _dsResultados; set => _dsResultados = value; }
        public DataTable DtParametros { get => _dtParametros; set => _dtParametros = value; }
        public string NombreTabla { get => _nombreTabla; set => _nombreTabla = value; }
        public string NombreSP { get => _nombreSP; set => _nombreSP = value; }
        public string MensajeErrorOS { get => _mensajeErrorOS; set => _mensajeErrorOS = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public string NombreBD { get => _nombreBD; set => _nombreBD = value; }
        public bool Scalar { get => _scalar; set => _scalar = value; }

        #endregion

        #region Constructores

        public ClsAccesoDatos()
        {
            DtParametros = new DataTable();
            DtParametros.Columns.Add("Nombre");
            DtParametros.Columns.Add("TipoDato");
            DtParametros.Columns.Add("Valor");
            NombreBD = "BD_Academia";
        }



        #endregion

        #region MetodosPrivados

        private void CrearConexionBaseDatos(ref ClsAccesoDatos ObjDataBase)
        {
            switch (ObjDataBase.NombreBD)
            {
                case "BD_Academia":
                    ObjDataBase.ObjSqlConnection = new SqlConnection(PryAccesoDatos.Properties.Settings.Default.Valor);
                    break;
            }

        }

        private void ValidarConexionBaseDatos(ref ClsAccesoDatos ObjDataBase)
        {
            if (ObjDataBase.ObjSqlConnection.State == ConnectionState.Closed)
            {
                ObjDataBase.ObjSqlConnection.Open();
            }
            else
            {
                ObjDataBase.ObjSqlConnection.Close();
                ObjDataBase.ObjSqlConnection.Dispose(); //Desocupa memoria
            }
        }

        private void AgregarParametros(ref ClsAccesoDatos objDataBase)
        {
            if (objDataBase.DtParametros != null)
            {
                SqlDbType TipoDatoSQL = new SqlDbType();
                foreach (DataRow item in objDataBase.DtParametros.Rows)
                {
                    switch (item[1])
                    {
                        case "1":
                            TipoDatoSQL = SqlDbType.Bit;
                            break;
                        case "2":
                            TipoDatoSQL = SqlDbType.TinyInt;
                            break;
                        case "3":
                            TipoDatoSQL = SqlDbType.SmallInt;
                            break;
                        case "4":
                            TipoDatoSQL = SqlDbType.Int;
                            break;
                        case "5":
                            TipoDatoSQL = SqlDbType.BigInt;
                            break;
                        case "6":
                            TipoDatoSQL = SqlDbType.Decimal;
                            break;
                        case "7":
                            TipoDatoSQL = SqlDbType.SmallMoney;
                            break;
                        case "8":
                            TipoDatoSQL = SqlDbType.Money;
                            break;
                        case "9":
                            TipoDatoSQL = SqlDbType.Float;
                            break;
                        case "10":
                            TipoDatoSQL = SqlDbType.Real;
                            break;
                        case "11":
                            TipoDatoSQL = SqlDbType.Date;
                            break;
                        case "12":
                            TipoDatoSQL = SqlDbType.Time;
                            break;
                        case "13":
                            TipoDatoSQL = SqlDbType.SmallDateTime;
                            break;
                        case "14":
                            TipoDatoSQL = SqlDbType.Char;
                            break;
                        case "15":
                            TipoDatoSQL = SqlDbType.VarChar;
                            break;
                        case "16":
                            TipoDatoSQL = SqlDbType.NVarChar;
                            break;
                        default:
                            break;
                    }
                    if (objDataBase.Scalar)
                    {
                        if (item[2].ToString().Equals(string.Empty))
                        {
                            objDataBase.ObjSqlCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = DBNull.Value;
                        }
                        else
                        {
                            objDataBase.ObjSqlCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = item[2].ToString();
                        }

                    }
                    else
                    {
                        if (item[2].ToString().Equals(string.Empty))
                        {
                            objDataBase.ObjSqlDataAdapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = DBNull.Value;
                        }
                        else
                        {
                            objDataBase.ObjSqlDataAdapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = item[2].ToString();
                        }
                    }
                }
            }
        }

        private void PrepararConexionBaseDatos(ref ClsAccesoDatos objDataBase)
        {
            CrearConexionBaseDatos(ref objDataBase);
            ValidarConexionBaseDatos(ref objDataBase);
        }

        private void EjecutarDataAdapter(ref ClsAccesoDatos objDataBase)
        {
            try
            {
                PrepararConexionBaseDatos(ref objDataBase);
                objDataBase.ObjSqlDataAdapter = new SqlDataAdapter(objDataBase.NombreSP, objDataBase.ObjSqlConnection);
                objDataBase.ObjSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                AgregarParametros(ref objDataBase);
                objDataBase.DsResultados = new DataSet();
                objDataBase.ObjSqlDataAdapter.Fill(objDataBase.DsResultados, objDataBase.NombreTabla);

            }
            catch (Exception ex)
            {
                objDataBase.MensajeErrorOS = ex.Message.ToString();
            }
            finally
            {
                if (objDataBase.ObjSqlConnection.State == ConnectionState.Open)
                {
                    ValidarConexionBaseDatos(ref objDataBase);
                }
            }

        }

        private void EjecutarCommand(ref ClsAccesoDatos ObjDataBase)
        {
            try
            {
                PrepararConexionBaseDatos(ref ObjDataBase);
                ObjDataBase.ObjSqlCommand = new SqlCommand(ObjDataBase.NombreSP, ObjDataBase.ObjSqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                AgregarParametros(ref ObjDataBase);
                if (ObjDataBase.Scalar)
                {
                    ObjDataBase.ValorScalar = ObjDataBase.ObjSqlCommand.ExecuteScalar().ToString().Trim();
                }
                else
                {
                    ObjDataBase.ObjSqlCommand.ExecuteNonQuery().ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                ObjDataBase.MensajeErrorOS = ex.Message.ToString();
            }
            finally
            {
                if (ObjDataBase.ObjSqlConnection.State == ConnectionState.Open)
                {
                    ValidarConexionBaseDatos(ref ObjDataBase);
                }
            }
        }

        public void CRUD(ClsAccesoDatos ObjDataBase)
        {
            if (ObjDataBase.Scalar)
            {
                EjecutarCommand(ref ObjDataBase);
            }
            else
            {
                EjecutarDataAdapter(ref ObjDataBase);
            }
        }
        #endregion

        #region VALIDAR DATOS
        public string ValidarUsuario(string usuario, string contraseña)
        {
            
            // Nombre del procedimiento almacenado
            NombreSP = "SP_Validar_Usuario";

            // Limpiamos los parámetros antes de añadir los nuevos
            DtParametros.Rows.Clear();

            // Añadimos los parámetros necesarios
            DtParametros.Rows.Add("@Usuario", "16", usuario);  // Usuario: nombre + apellido + últimos 3 dígitos del ID
            DtParametros.Rows.Add("@Contraseña", "16", contraseña);  // Contraseña: ID completo

            // Establecemos que el tipo de usuario devuelto será escalar (un valor)
            Scalar = true;

            // Ejecutamos el procedimiento y asignamos el valor devuelto
            CRUD(this); // Usa 'this' para referenciar la instancia actual

            // Devolvemos el tipo de usuario como valor escalar (Administrador, Docente, Estudiante, o Invalido)
            return ValorScalar;
        }

        #endregion

        //Metodo que valida si hay un admin que ya exista en base al usuario
        #region Usuario Existe
        public string UsuarioExiste(string usuario)
        {
                NombreTabla = "Administradores";
                NombreSP = "SP_Usuario_Existente";
                Scalar = true;
            
            // Limpiamos los parámetros antes de añadir los nuevos
            DtParametros.Rows.Clear();

            // Añadimos los parámetros necesarios
            DtParametros.Rows.Add("@Usuario", "16", usuario);

            CRUD(this);

            return ValorScalar;
        }
        #endregion
    }


}

