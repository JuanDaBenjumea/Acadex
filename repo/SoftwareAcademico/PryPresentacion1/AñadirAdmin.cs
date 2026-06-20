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
    public partial class AgregarAdmin : Form
    {
        private ClsAdministradores objAdmin = null;
        private Class1 objAdminLn = new Class1();
        public AgregarAdmin()
        {
            InitializeComponent();
        }

        private void btn_AgregarBD_Ad_Click(object sender, EventArgs e)
        {
            //Variables para controlar los campos vacios
            string id = txt_IdAdmin.Text;
            string nombre = txt_NombAdmin.Text;
            string apellido = txt_ApellAdmin.Text;
            string usuario = txt_UsuarioAdmin.Text;
            string contra = txt_ContraAdmin.Text;
            string rContra = txt_RcontraAdmin.Text;

            //Condicional que valida que no hayan campos vacios
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contra) || string.IsNullOrEmpty(rContra))
            {
                MessageBox.Show("Hay campos vacíos, por favor llenelos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Condicional que valida que las contraseñas coincidan
            if (contra != rContra)
            {
                MessageBox.Show("Las Contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Condicional que valida que el IdAdmin no exista
            if (objAdminLn.IdAdminExiste(id))
            {
                MessageBox.Show("El ID ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Condicional que valida que el admin (usuario) no exista
            string Existe = objAdminLn.UsuarioExiste(usuario);
            if (Existe == "Si")
            {
                MessageBox.Show("El usuario ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //Si no existe lo crea
                objAdmin = new ClsAdministradores()
                {
                    IdAdmin = id,
                    NombAdmin = nombre,
                    ApelliAdmin = apellido,
                    UserAdmin = usuario,
                    PassAdmin = rContra,
                    FechaRegistro = DateTime.Now
                };
                objAdminLn.CreateAdmin(ref objAdmin);
                if (objAdmin.MensajeError == null)
                {
                    MessageBox.Show("Administrador creado exitosamente", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(objAdmin.MensajeError, "Error al Agregar Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txt_IdAdmin.Text = "";
                txt_NombAdmin.Text = "";
                txt_ApellAdmin.Text = "";
                txt_UsuarioAdmin.Text = "";
                txt_ContraAdmin.Text = "";
                txt_RcontraAdmin.Text = "";
            }

        }

        private void btn_Cancelar_Ad_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
