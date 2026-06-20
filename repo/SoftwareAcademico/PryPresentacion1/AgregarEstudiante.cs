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
    public partial class AgregarEstudiante : Form
    {
        //Objetos de la clase Estudiantes y EstudiantesLn
        private ClsEstudiantes ObjEstudiante = null;
        private ClsEstudiantesLn ObjEstudianteLn = new ClsEstudiantesLn();
        public AgregarEstudiante()
        {
            InitializeComponent();
        }

        //Boton que cierra el Form
        private void btn_Cancelar_Estu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Boton para agregar un nuevo Estudiante
        private void btn_AgregarBD_Estu_Click(object sender, EventArgs e)
        {
            // Variables para validar campos vacíos
            string id = txt_IdEstu.Text;
            string nombre = txt_NombEstu.Text;
            string apellido = txt_ApellEstu.Text;
            string telefono = txt_TelefonoEstu.Text;

            // Validar que hay un elemento seleccionado en el ComboBox
            string programa = cmb_ProgramaBD.SelectedItem != null ? cmb_ProgramaBD.SelectedItem.ToString() : string.Empty;
            // Asignar el valor según el índice seleccionado
            switch (cmb_ProgramaBD.SelectedIndex)
            {
                case 0: // Ingenieria de Software
                    programa = "1";
                    break;
                case 1: // Medicina Pediatra
                    programa = "2";
                    break;
                case 2: // Filosofia
                    programa = "3";
                    break;
                case 3: // Teatro
                    programa = "4";
                    break;
                default:
                    MessageBox.Show("Seleccione un programa válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            //Asignar el valor según el índice seleccionado
            string beca = cmb_Beca.SelectedItem !=null ? cmb_Beca.SelectedItem.ToString() : string.Empty;
            switch (cmb_Beca.SelectedIndex)
            {
                case 0://Si
                    beca = "Si"; //Estudiante con Beca
                        break;
                case 1://No
                    beca = "No"; //Estudiante sin Beca
                    break;
            }

            // Condicional para validar que no hayan campos vacíos
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(programa)|string.IsNullOrEmpty(beca))
            {
                MessageBox.Show("Hay campos vacíos, por favor llénalos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Condicional para validar que no se repita el mismo ID
            if (ObjEstudianteLn.IdEstudianteExiste(id))
            {
                MessageBox.Show("El ID ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //Insertar nuevo estudiante
                ObjEstudiante = new ClsEstudiantes()
                {
                    IdEstudiante = id,
                    NombEstudiante = nombre,
                    ApellEstudiante = apellido,
                    Telefono = telefono,
                    Programa = programa,
                    Beca = beca,
                    FechaRegistro = DateTime.Now,
                };
                ObjEstudianteLn.CreateEstudiante(ref ObjEstudiante);
                if (ObjEstudiante.MensajeError == null)
                {
                    MessageBox.Show("Estudiante creado exitosamente", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(ObjEstudiante.MensajeError, "Error al Agregar Estudiante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Limpiar Campos
                txt_IdEstu.Text = "";
                txt_NombEstu.Text = "";
                txt_ApellEstu.Text = "";
                txt_TelefonoEstu.Text = "";
                cmb_ProgramaBD.SelectedIndex = -1;
                cmb_Beca.SelectedIndex = -1;
            }
        }
    }
}
