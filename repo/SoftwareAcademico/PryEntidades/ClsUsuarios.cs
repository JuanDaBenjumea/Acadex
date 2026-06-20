using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryEntidades
{
    public class ClsUsuarios
    {
        //Atributos de la clase Usuarios, para validar el logueo de Admins, Docentes y Estudiantes
        private string user, pass, tipoUsuario;
        //Atributos para el manejo de la base de datos
        private string mensajeError, valorScalar;
        private DataTable dtResultados;

        //Constructor vacio
        public ClsUsuarios() { }

        //Constructor Clase Usuarios
        public ClsUsuarios(string user, string pass, string tipoUsuario, string mensajeError, string valorScalar, DataTable dtResultados)
        {
            User = user;
            Pass = pass;
            TipoUsuario = tipoUsuario;
            MensajeError = mensajeError;
            ValorScalar = valorScalar;
            DtResultados = dtResultados;
        }

        //Encapsulado de atributos con propiedad
        public string User { get => user; set => user = value; }
        public string Pass { get => pass; set => pass = value; }
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }
}
