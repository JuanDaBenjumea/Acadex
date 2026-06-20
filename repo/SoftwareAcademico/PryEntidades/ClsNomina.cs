using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryEntidades
{
    public class ClsNomina
    {
        //Atributos de la clase nomina
        private int idNomina;
        private string nombre;
        private string apellido;
        private string facultad;
        private int salarioContrato;
        private int horaExtra;
        private int pagoHoraExtra;
        private int totalHoraExtra;
        private int salarioNeto;
        private DateTime fechaRegistro;
        //Atributos para el manejo de la base de datos
        private string mensajeError, valorScalar;
        private DataTable dtResultados;


        //Constructor vacio
        public ClsNomina() { }

        //constructor de la clase nomina
        public ClsNomina(int idNomina, string nombre, string apellido, string facultad, int salarioContrato, int horaExtra, int pagoHoraExtra, int totalHoraExtra, int salarioNeto, DateTime fechaRegistro, string mensajeError, string valorScalar, DataTable dtResultados)
        {
            IdNomina = idNomina;
            Nombre = nombre;
            Apellido = apellido;
            Facultad = facultad;
            SalarioContrato = salarioContrato;
            HoraExtra = horaExtra;
            PagoHoraExtra = pagoHoraExtra;
            TotalHoraExtra = totalHoraExtra;
            SalarioNeto = salarioNeto;
            FechaRegistro = fechaRegistro;
            MensajeError = mensajeError;
            ValorScalar = valorScalar;
            DtResultados = dtResultados;
        }


        //Encapsulado de atributos con propiedad
        public int IdNomina { get => idNomina; set => idNomina = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Facultad { get => facultad; set => facultad = value; }
        public int SalarioContrato { get => salarioContrato; set => salarioContrato = value; }
        public int HoraExtra { get => horaExtra; set => horaExtra = value; }
        public int PagoHoraExtra { get => pagoHoraExtra; set => pagoHoraExtra = value; }
        public int TotalHoraExtra { get => totalHoraExtra; set => totalHoraExtra = value; }
        public int SalarioNeto { get => salarioNeto; set => salarioNeto = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }
}
