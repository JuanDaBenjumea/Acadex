using PryEntidades;
using PryLogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryPresentacion1
{
    public partial class AgregarDocente : Form
    {
        //Objetos de la clase Docentes y DocentesLn
        private ClsDocentes ObjDocente = null;
        private ClsDocentesLn ObjDocenteLn = new ClsDocentesLn();
        public AgregarDocente()
        {
            InitializeComponent();
        }

        //Boton que Cierra el Form
        private void btn_Cancelar_Doc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Boton para agregar un nuevo docente
        private void btn_AgregarBD_Doc_Click(object sender, EventArgs e)
        {
            // Variables para validar campos vacíos
            string id = txt_IdDoc.Text;
            string nombre = txt_NombDoc.Text;
            string apellido = txt_ApellDoc.Text;
            string telefono = txt_TelefonoDoc.Text;
            string salario = txt_SalarioDoc.Text;

            // Validar que hay un elemento seleccionado en el ComboBox
            string facultad = cmb_FacultadBD.SelectedItem != null ? cmb_FacultadBD.SelectedItem.ToString() : string.Empty;
            // Asignar el valor según el índice seleccionado
            switch (cmb_FacultadBD.SelectedIndex)
            {
                case 0: // Ingenieria
                    facultad = "1";
                    break;
                case 1: // Medicina
                    facultad = "2";
                    break;
                case 2: // Letras
                    facultad = "3";
                    break;
                case 3: // Artes
                    facultad = "4";
                    break;
                default:
                    MessageBox.Show("Seleccione una facultad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            // Condicional para validar que no hayan campos vacíos
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(facultad)||string.IsNullOrEmpty(salario))
            {
                MessageBox.Show("Hay campos vacíos, por favor llénalos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Condicional para validar que no se repita el mismo ID
            if (ObjDocenteLn.IdDocenteExiste(id))
            {
                MessageBox.Show("El ID ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //Insertar nuevo docente
                ObjDocente = new ClsDocentes()
                {
                    IdDocente = id,
                    NombDocente = nombre,
                    ApellDocente = apellido,
                    Telefono = telefono,
                    Facultad = facultad,
                    Salario = Convert.ToInt32(salario),
                    FechaRegistro = DateTime.Now,
                };
                ObjDocenteLn.CreateDocente(ref ObjDocente);
                if (ObjDocente.MensajeError==null)
                {
                    MessageBox.Show("Docente creado exitosamente", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(ObjDocente.MensajeError, "Error al Agregar Docente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Limpiar Campos
                txt_IdDoc.Text = "";
                txt_NombDoc.Text = "";
                txt_ApellDoc.Text = "";
                txt_TelefonoDoc.Text = "";
                txt_SalarioDoc.Text = "";
                cmb_FacultadBD.SelectedIndex = -1;
            }

            


        }

        //Solo perimite que se escriban numeros en el campo salario
        private void txt_SalarioDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada no es un número ni la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número o control (como Backspace), cancelar el evento KeyPress
                e.Handled = true;
            }
        }
    }
}
