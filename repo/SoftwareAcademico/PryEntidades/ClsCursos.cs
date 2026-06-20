using System;
using System.Data;

namespace PryEntidades
{
    public class ClsCursos
    {
        // Atributos de la clase Cursos
        private int idCurso; // Cambiado a int
        private string nombcurso;
        private int cantCreditos;
        private int numEstudiantes;
        private string idDocente;
        private string facultad;
        private DateTime fechaRegistro;

        // Atributos para el manejo de la base de datos
        private string mensajeError, valorScalar;
        private DataTable dtResultados;

        // Constructor Vacio
        public ClsCursos() { }

        // Constructor de la clase Cursos
        public ClsCursos(int idCurso, string nombcurso, int cantCreditos, int numEstudiantes, string idDocente, string facultad, DateTime fechaRegistro, string mensajeError, string valorScalar, DataTable dtResultados)
        {
            IdCurso = idCurso; // Este valor será autogenerado por SQL Server
            Nombcurso = nombcurso;
            CantCreditos = cantCreditos;
            NumEstudiantes = numEstudiantes;
            IdDocente = idDocente;
            Facultad = facultad;
            FechaRegistro = fechaRegistro;
            MensajeError = mensajeError;
            ValorScalar = valorScalar;
            DtResultados = dtResultados;
        }

        // Encapsulado de atributos con propiedad
        public int IdCurso { get => idCurso; set => idCurso = value; } // Cambiado a int
        public string Nombcurso { get => nombcurso; set => nombcurso = value; }
        public int CantCreditos { get => cantCreditos; set => cantCreditos = value; }
        public int NumEstudiantes { get => numEstudiantes; set => numEstudiantes = value; }
        public string IdDocente { get => idDocente; set => idDocente = value; }
        public string Facultad { get => facultad; set => facultad = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public string ValorScalar { get => valorScalar; set => valorScalar = value; }
        public DataTable DtResultados { get => dtResultados; set => dtResultados = value; }
    }
}
