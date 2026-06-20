using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryEntidades
{
    public class ClsEstudiantes
    {
        //Atributos de la clase estudiantes
        private string idEstudiante;
        private string nombEstudiante;
        private string apellEstudiante;
        private string programa;
        private string telefono;
        private string beca;
        private DateTime fechaRegistro;
        //Atributos para el manejo de la base de datos
        private string mensajeError, valorScalar;
        private DataTable dtResultados;

        //constructor vacio
        public ClsEstudiantes() { }

        //Constructor clase Estudiantes
        public ClsEstudiantes(string idEstudiante, string nombEstudiante, string apellEstudiante, string programa, string telefono, string beca, DateTime fechaRegistro, string mensajeError, string valorScalar, DataTable dtResultados)
        {
            IdEstudiante = idEstudiante;
            NombEstudiante = nombEstudiante;
            ApellEstudiante = apellEstudiante;
            Programa = programa;
            Telefono = telefono;
            Beca = beca;
            FechaRegistro = fechaRegistro;
            MensajeError = mensajeError;
            ValorScalar = valorScalar;
            DtResultados = dtResultados;
        }

        //Encapsulado de atributos con propiedad
        public string IdEstudiante { get => idEstudiante; set => idEstudiante = value; }
        public string NombEstudiante { get => nombEstudiante; set => nombEstudiante = value; }
        public string ApellEstudiante { get => apellEstudiante; set => apellEstudiante = value; }
        public string Programa { get => programa; set => programa = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Beca { get => beca; set => beca = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }
}
