using PryLogicaNegocio;
using PryPresentacion1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
           DialogResult Resultado = MessageBox.Show("¿Quieres cerrar el programa?", "Salir(?)", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (Resultado == DialogResult.OK)
            {
                Application.Exit();
            }

        }

        private void MostrarContraseña(object sender, EventArgs e)
        {
            txt_Contra.PasswordChar = '\0';
        }

        private void OcultarContraseña(object sender, EventArgs e)
        {
            txt_Contra.PasswordChar = '*';
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string usuario = txt_Usuario.Text;      // Suponiendo que tienes un TextBox para el usuario
            string contraseña = txt_Contra.Text; // Suponiendo que tienes un TextBox para la contraseña

            ClsUsuariosLn usuariosLn = new ClsUsuariosLn();

            // Validar el usuario
            string tipoUsuario = usuariosLn.ValidarUsuario(usuario, contraseña);

            // Redirigir según el tipo de usuario
            RedirigirUsuario(tipoUsuario);
        }
        public void RedirigirUsuario(string tipoUsuario)
        {
            switch (tipoUsuario)
            {
                case "Administrador":
                    // Redirigir al formulario de administrador
                    AdminPanel admin = new AdminPanel();
                    admin.Show();
                    this.Hide();
                    break;

                case "Docente":
                    // Redirigir al formulario de docente
                    MessageBox.Show("Docente");
                    break;

                case "Estudiante":
                    // Redirigir al formulario de estudiante
                    MessageBox.Show("Estudiante");
                    break;

                case "Invalido":
                    // Mostrar mensaje de error para credenciales inválidas
                    MessageBox.Show("Credenciales inválidas. Por favor, intente de nuevo.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                default:
                    MessageBox.Show("Ocurrió un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
