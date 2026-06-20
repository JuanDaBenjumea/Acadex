using PryEntidades;
using PryLogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryPresentacion1
{
    public partial class ReporteNomina : Form
    {
        //Instancia de la clase Nomina
        private ClsNomina ObjNomina = null;
        private ClsNominaLn ObjNominaLn = new ClsNominaLn();

        //Variable para eliminar Nominas del datagridview
        private int idNominaImprimir;
        public ReporteNomina()
        {
            InitializeComponent();
            CargarNominas();
        }

        //Metodo para Cargar las nominas en el datagridview
        private void CargarNominas()
        {
            ObjNomina = new ClsNomina();
            ObjNominaLn.Index(ref ObjNomina);
            if (ObjNomina.MensajeError == null)
            {
                dtgv_Nominas.DataSource = ObjNomina.DtResultados;
            }
            else
            {
                MessageBox.Show(ObjNomina.MensajeError, "Error Nominas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Boton CANCELAR que cierra el formulario
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Boton que filtra las Nominas por su ID
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string idNomina = txt_IdNomina.Text;

            if(string.IsNullOrEmpty(idNomina))
            {
                MessageBox.Show("Ingrese el ID de la nomina que quiere buscar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ClsNomina ObjNomina = new ClsNomina()
                {
                    IdNomina = Convert.ToInt32(idNomina)    
                };
                ClsNominaLn ObjNominaLn = new ClsNominaLn();
                ObjNominaLn.FilterNomina(ref ObjNomina);

                if (!string.IsNullOrEmpty(ObjNomina.MensajeError))
                {
                    MessageBox.Show(ObjNomina.MensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    dtgv_Nominas.DataSource = ObjNomina.DtResultados;
                }
            }
        }

        //Boton que imprime el contenido del datagridview en un archivo txt
        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            DateTime fechaCreacion = DateTime.Now;

            if (dtgv_Nominas.SelectedRows.Count > 0)
            {
                string nombre = dtgv_Nominas.SelectedRows[0].Cells["Nombre"].Value?.ToString();
                string apellido = dtgv_Nominas.SelectedRows[0].Cells["Apellido"].Value?.ToString();
                string facultad = dtgv_Nominas.SelectedRows[0].Cells["Facultad"].Value?.ToString();
                string salarioContrato = dtgv_Nominas.SelectedRows[0].Cells["SalarioContrato"].Value?.ToString();
                string horasExtra = dtgv_Nominas.SelectedRows[0].Cells["HoraExtra"].Value?.ToString();
                string pagoXHoraExtra = dtgv_Nominas.SelectedRows[0].Cells["PagoXHoraExtra"].Value?.ToString();
                string totalHoraExtra = dtgv_Nominas.SelectedRows[0].Cells["TotalHoraExtra"].Value?.ToString();
                string salarioNeto = dtgv_Nominas.SelectedRows[0].Cells["SalarioNeto"].Value?.ToString();

                string baseNombreArchivo = $"{nombre} {apellido} - Nomina";
                string ext = ".txt";
                int contador = 1;

                // Generar nombre de archivo único
                string nombreArchivo = Path.Combine(@"C:\Users\Nal32\Documents\", $"{baseNombreArchivo}{ext}");

                while (File.Exists(nombreArchivo))
                {
                    nombreArchivo = Path.Combine(@"C:\Users\Nal32\Documents\", $"{baseNombreArchivo}({contador}){ext}");
                    contador++;
                }

                try
                {
                    // Crear archivo de nómina
                    using (StreamWriter sw = File.CreateText(nombreArchivo))
                    {
                        sw.WriteLine("-----------------------------------------------------------");
                        sw.WriteLine("|                     NÓMINA DE PAGO                     |");
                        sw.WriteLine("-----------------------------------------------------------");
                        sw.WriteLine($"| Nombre: {nombre}                                      ");
                        sw.WriteLine($"| Apellido: {apellido}                                  ");
                        sw.WriteLine($"| Facultad: {facultad}                                  ");
                        sw.WriteLine($"| Salario por Contrato: ${salarioContrato}              ");
                        sw.WriteLine($"| Horas Extra: {horasExtra}                             ");
                        sw.WriteLine($"| Pago por Hora Extra: ${pagoXHoraExtra}                ");
                        sw.WriteLine($"| Total Horas Extra: ${totalHoraExtra}                  ");
                        sw.WriteLine($"| Salario Neto: ${salarioNeto}                          ");
                        sw.WriteLine($"| Fecha de Creación: {fechaCreacion.ToLongDateString()} ");
                        sw.WriteLine("-----------------------------------------------------------");
                    }

                    MessageBox.Show("Archivo de nómina generado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna nómina para generar el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void dtgv_Nominas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegurarse de que el clic no sea en el encabezado de la columna
            if (e.RowIndex >= 0)
            {
                int idNomina = Convert.ToInt32(dtgv_Nominas.Rows[e.RowIndex].Cells[0].Value.ToString());
                idNominaImprimir = idNomina;

            }
        }
    }
}
