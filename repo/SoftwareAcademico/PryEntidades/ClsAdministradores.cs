using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryEntidades
{
    public class ClsAdministradores
    {
        //Atributos de la clase administradores
        private string idAdmin;
        private string nombAdmin;
        private string apelliAdmin;
        private string userAdmin;
        private string passAdmin;
        private DateTime fechaRegistro;
        //Atributos para el manejo de la base de datos
        private string mensajeError, valorScalar;
        private DataTable dtResultados;

        //Constructor Vacio 
        public ClsAdministradores() { }

        //Constructor Clase administradores
        public ClsAdministradores(string idAdmin, string nombAdmin, string apelliAdmin, string userAdmin, string passAdmin, DateTime fechaRegistro, string mensajeError, string valorScalar, DataTable dtResultados)
        {
            IdAdmin = idAdmin;
            NombAdmin = nombAdmin;
            ApelliAdmin = apelliAdmin;
            UserAdmin = userAdmin;
            PassAdmin = passAdmin;
            FechaRegistro = fechaRegistro;
            MensajeError = mensajeError;
            ValorScalar = valorScalar;
            DtResultados = dtResultados;
        }

        //Encapsulado de atributos con propiedad
        public string IdAdmin { get => idAdmin; set => idAdmin = value; }
        public string NombAdmin { get => nombAdmin; set => nombAdmin = value; }
        public string ApelliAdmin { get => apelliAdmin; set => apelliAdmin = value; }
        public string UserAdmin { get => userAdmin; set => userAdmin = value; }
        public string PassAdmin { get => passAdmin; set => passAdmin = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }
}
