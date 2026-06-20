using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryEntidades
{
    public class ClsDocentes
    {
        //Atributos de la clase Docentes
        private string idDocente;
        private string nombDocente;
        private string apellDocente;
        private string telefono;
        private string facultad;
        private int salario;
        private DateTime fechaRegistro;
        //Atributos para el manejo de la base de datos
        private string mensajeError, valorScalar;
        private DataTable dtResultados;

        //Constructor vacio
        public ClsDocentes() { }

        //Constructor clase Docentes
        public ClsDocentes(string idDocente, string nombDocente, string apellDocente, string telefono, string facultad, int salario, DateTime fechaRegistro, string mensajeError, string valorScalar, DataTable dtResultados)
        {
            IdDocente = idDocente;
            NombDocente = nombDocente;
            ApellDocente = apellDocente;
            Telefono = telefono;
            Facultad = facultad;
            Salario  = salario;
            FechaRegistro = fechaRegistro;
            MensajeError = mensajeError;
            ValorScalar = valorScalar;
            DtResultados = dtResultados;
        }

        //Encapsulado de atributos con proepiedad
        public string IdDocente { get => idDocente; set => idDocente = value; }
        public string NombDocente { get => nombDocente; set => nombDocente = value; }
        public string ApellDocente { get => apellDocente; set => apellDocente = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Facultad { get => facultad; set => facultad = value; }
        public int Salario { get => salario; set => salario = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }
}
