using PryEntidades;
using PryLogicaNegocio;
using PryPresentacion;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PryPresentacion1
{
    public partial class AdminPanel : Form
    {
        //Instancia de la clase Estudiantes
        private ClsEstudiantes ObjEstudiante = null;
        private readonly ClsEstudiantesLn ObjEstudianteLn = new ClsEstudiantesLn();

        //Variable para eliminar Estudiantes del datagridview
        private string idEstudianteDelete;


        //Instancia de la clase Docentes
        private ClsDocentes ObjDocente = null;
        private readonly ClsDocentesLn ObjDocenteLn = new ClsDocentesLn();

        //Variable para eliminar Docentes del datagridview
        private string idDocenteDelete;
        
        //Instancia de la clase Administradores
        private ClsAdministradores ObjAdmin = null;
        private readonly Class1 ObjAdminLn = new Class1();

        //Variable para eliminar Admins del datagridview
        private string idAdminDelete;

        //Instancia de la clase Cursos
        private ClsCursos ObjCurso = null;
        private ClsCursosLn ObjCursoLn = new ClsCursosLn();

        //Variable para eliminar Cursos del datagridview
        private int idCursoDelete;

        //Instancia de la clase Nomina
        private ClsNomina ObjNomina = null;
        private ClsNominaLn ObjNominaLn = new ClsNominaLn();

        //Variable para eliminar Nominas del datagridview
        private int idNominaDelete;

        // Enum para los paneles
        private enum PanelType
        {
            Gestionar,
            Generar
        }

        public AdminPanel()
        {
            InitializeComponent();
            // Inicializa ambos paneles como invisibles
            TogglePanel(PanelType.Gestionar, false);
            TogglePanel(PanelType.Generar, false);

            //Carga los datos de las tablas en sus respectivos datagrid
            CargarAdmins();
            CargarDocentes();
            CargarEstudiantes();
            CargarCursos();
            CargarNominas();

            //Inicializa los paneles principales en false
            pnl_Admin.Visible = false;
            pnl_Docentes.Visible = false;
            pnl_Estudiantes.Visible = false;
            pnl_Cursos.Visible = false;
            pnl_Nomina.Visible = false;
        }

        //Metodo para Cerrar Sesion y volver al Login
        private void btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("¿Quieres cerrar sesión?", "Salir(?)", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (Resultado == DialogResult.OK)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        //Boton para mostrar el panel de Gestionar (Admins, Docentes, Estudiantes, Cursos)
        private void btn_Gestionar_Click(object sender, EventArgs e)
        {
            TogglePanel(PanelType.Gestionar, !pnl_Gestionar.Visible);
        }

        //Boton para mostrar el panel de Generar (Nomina, Reporte)
        private void btn_Generar_Click(object sender, EventArgs e)
        {
            TogglePanel(PanelType.Generar, !pnl_Generar.Visible);
        }

        //Metodo para ocultar o hacer visible los paneles gestionar y generar
        private void TogglePanel(PanelType panelType, bool isVisible)
        {
            // Controla la visibilidad de los paneles
            switch (panelType)
            {
                case PanelType.Gestionar:
                    pnl_Gestionar.Visible = isVisible;
                    btn_Gestionar.Text = isVisible ? "Ocultar Gestionar" : "Gestionar";
                    break;

                case PanelType.Generar:
                    pnl_Generar.Visible = isVisible;
                    btn_Generar.Text = isVisible ? "Ocultar Generar" : "Generar";
                    break;
            }
        }

        //Metodos panel Administradores
        #region ADMINISTRADORES
        //Metodo para cargar Los Administradores 
        private void CargarAdmins()
        {
            ObjAdmin = new ClsAdministradores();
            ObjAdminLn.Index(ref ObjAdmin);
            if (ObjAdmin.MensajeError == null)
            {
                dtgv_Admin.DataSource = ObjAdmin.DtResultados;
            }
            else
            {
                MessageBox.Show(ObjAdmin.MensajeError, "Error Admins", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Boton para ver el panel de Administradores
        private void btn_Admin_Click(object sender, EventArgs e)
        {
            pnl_Admin.Visible = true;
            pnl_Docentes.Visible = false;
            pnl_Estudiantes.Visible = false;
            pnl_Cursos.Visible = false;
        }
        //Boton que me muestra el form de AñadirAdmins como un showDialog
        private void btn_AgregarAdmin_Click(object sender, EventArgs e)
        {
            AgregarAdmin agregar = new AgregarAdmin();
            agregar.ShowDialog();
        }

        //Boton para refrescar el DataGridView de Administradores
        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            CargarAdmins();
        }

        //Boton para eliminar un Administrador
        private void btn_EliminarAdmin_Click(object sender, EventArgs e)
        {
            //Condicional que valida si hay un admin seleccionado
            if (dtgv_Admin.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un Admin para eliminar", "Error Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Variable que guarda el idAdmin y valida que no sea el SuperAdministrador
            string idAdmin = idAdminDelete; 

            // Comprobar si el ID es 1 (SuperAdministrador)
            if (idAdmin == "1")
            {
                MessageBox.Show("No se puede borrar al SuperAdministrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Preguntar al usuario si está seguro de eliminar
            DialogResult respuesta = MessageBox.Show("¿Está Seguro de Eliminar este Admin?", "Eliminar(?)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Crear un objeto para la lógica de negocio
                    ClsAdministradores objAdmin = new ClsAdministradores { IdAdmin = idAdmin };
                    Class1 objAdminLn = new Class1();

                    // Llamar al método para eliminar el administrador
                    objAdminLn.DeleteAdmin(ref objAdmin);

                    // Verificar si hubo un error
                    if (objAdmin.MensajeError == null)
                    {
                        MessageBox.Show("Administrador eliminado exitosamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Metodo para refrescar el DataGridView
                        CargarAdmins(); 
                    }
                    else
                    {
                        MessageBox.Show(objAdmin.MensajeError, "Error al Eliminar Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al eliminar el administrador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Metodo para Seleccionar el ID del Admin a eliminar, haciendo click en el DataGridView
        private void dtgv_Admin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegurarse de que el clic no sea en el encabezado de la columna
            if (e.RowIndex >= 0)
            {
                // Obtén el ID del administrador de la primera columna (suponiendo que es la primera)
                string idAdmin = dtgv_Admin.Rows[e.RowIndex].Cells[0].Value.ToString();
                idAdminDelete = idAdmin;

            }
        }

        #endregion

        //Metodos panel Docentes
        #region DOCENTES
        //Metodo para cargar Los Docentes
        private void CargarDocentes()
        {
            ObjDocente = new ClsDocentes();
            ObjDocenteLn.Index(ref ObjDocente);
            if (ObjDocente.MensajeError == null)
            {
                dtgv_Docentes.DataSource = ObjDocente.DtResultados;
            }
            else
            {
                MessageBox.Show(ObjDocente.MensajeError, "Error Docentes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       

        //Boton para ver el panel de Docentes
        private void btn_Docentes_Click(object sender, EventArgs e)
        {
            pnl_Docentes.Visible = true;
            pnl_Admin.Visible=true;
            pnl_Estudiantes.Visible = false;
            pnl_Cursos.Visible = false;
        }

        private void btn_AgregarDoc_Click(object sender, EventArgs e)
        {
            AgregarDocente agregarDoc = new AgregarDocente();
            agregarDoc.ShowDialog();
        }

        private void btn_Filtrar_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado una facultad
            if (cmb_Facultad.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una facultad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string facFiltrar = null;

            // Asignar el valor según el índice seleccionado
            switch (cmb_Facultad.SelectedIndex)
            {
                case 0: // Ingenieria
                    facFiltrar = "1";
                    break;
                case 1: // Medicina
                    facFiltrar = "2";
                    break;
                case 2: // Letras
                    facFiltrar = "3";
                    break;
                case 3: // Artes
                    facFiltrar = "4";
                    break;
                default:
                    MessageBox.Show("Seleccione una facultad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            ClsDocentes ObjDocente = new ClsDocentes { Facultad = facFiltrar };
            ClsDocentesLn ObjDocenteLn = new ClsDocentesLn();

            // Llamar al método de filtrado
            ObjDocenteLn.FilterDocente(ref ObjDocente);

            // Verificar si hay un error en el objeto docente
            if (!string.IsNullOrEmpty(ObjDocente.MensajeError))
            {
                MessageBox.Show(ObjDocente.MensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //Pasar datos al datagrid
                dtgv_Docentes.DataSource = ObjDocente.DtResultados;
            }
        }

        private void btn_RecargarDoc_Click(object sender, EventArgs e)
        {
            CargarDocentes();
        }

        private void btn_EliminarDoc_Click(object sender, EventArgs e)
        {
            if(dtgv_Docentes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un Docente para eliminar", "Error Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Preguntar al usuario si está seguro de eliminar
            DialogResult respuesta = MessageBox.Show("¿Está Seguro de Eliminar este Docente?", "Eliminar(?)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Crear un objeto para la lógica de negocio
                    ClsDocentes ObjDocente = new ClsDocentes { IdDocente = idDocenteDelete };
                    ClsDocentesLn ObjDocenteLn = new ClsDocentesLn();

                    // Llamar al método para eliminar el docente
                    ObjDocenteLn.DeleteDocente(ref ObjDocente);

                    // Verificar si hubo un error
                    if (ObjDocente.MensajeError == null)
                    {
                        MessageBox.Show("Docente eliminado exitosamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Metodo para refrescar el DataGridView
                        CargarDocentes();
                    }
                    else
                    {
                        MessageBox.Show(ObjDocente.MensajeError, "Error al Eliminar Docente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al eliminar el Docente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtgv_Docentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegurarse de que el clic no sea en el encabezado de la columna
            if (e.RowIndex >= 0)
            {
                // Obtén el ID del administrador de la primera columna 
                string idDocente = dtgv_Docentes.Rows[e.RowIndex].Cells[0].Value.ToString();
                idDocenteDelete = idDocente;

            }
        }
        #endregion

        //Metodos panel Estudiantes
        #region ESTUDIANTES
        //Metodo para cargar los estudiantes en el datagridview
        private void CargarEstudiantes()
        {
            ObjEstudiante = new ClsEstudiantes();
            ObjEstudianteLn.Index(ref ObjEstudiante);
            if (ObjEstudiante.MensajeError == null)
            {
                dtgv_Estudiantes.DataSource = ObjEstudiante.DtResultados;
            }
            else
            {
                MessageBox.Show(ObjEstudiante.MensajeError, "Error Estudiantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Boton para hacer visible el panel de Estudiantes
        private void btn_Estudiantes_Click(object sender, EventArgs e)
        {
            pnl_Docentes.Visible = true;
            pnl_Admin.Visible = true;
            pnl_Estudiantes.Visible = true;
            pnl_Cursos.Visible = false;

        }

        //Boton para Recargar el Datagridview de estudiantes
        private void btn_RecargarEstu_Click(object sender, EventArgs e)
        {
            CargarEstudiantes();
        }

        //Boton (Lupa) para filtrar estudiantes en base al programa que cursan 
        private void btn_FiltrarEstu_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado un programa
            if (cmb_Programa.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un programa válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string programFiltro = null;

            // Asignar el valor según el índice seleccionado
            switch (cmb_Programa.SelectedIndex)
            {
                case 0: // Ingenieria de Software
                    programFiltro = "1";
                    break;
                case 1: // Medicina pediatra
                    programFiltro = "2";
                    break;
                case 2: // Filosofia
                    programFiltro = "3";
                    break;
                case 3: // Teatro
                    programFiltro = "4";
                    break;
                default:
                    MessageBox.Show("Seleccione un programa válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            //Objetos de la clase estudiante
            ClsEstudiantes ObjEstudiante = new ClsEstudiantes { Programa = programFiltro };
            ClsEstudiantesLn ObjEstudianteLn = new ClsEstudiantesLn();

            // Llamar al método de filtrado
            ObjEstudianteLn.FilterEstudiante(ref ObjEstudiante);

            // Verificar si hay un error en el objeto docente
            if (!string.IsNullOrEmpty(ObjEstudiante.MensajeError))
            {
                MessageBox.Show(ObjEstudiante.MensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //Pasar datos al datagrid
                dtgv_Estudiantes.DataSource = ObjEstudiante.DtResultados;
            }
        }

        //Boton que despliega el form AgregarEstudiante como showdialog
        private void btn_AgregarEstu_Click(object sender, EventArgs e)
        {
            AgregarEstudiante agregarEstudiante = new AgregarEstudiante();
            agregarEstudiante.ShowDialog();
        }

        //Boton para eliminar estudiante seleccionandolo del datagridview
        private void btn_EliminarEstu_Click(object sender, EventArgs e)
        {
            //Condicional que verifica si se selecciono una celda del datagrid
            if (dtgv_Estudiantes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un Estudiante para eliminar", "Error Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Preguntar al usuario si está seguro de eliminar
            DialogResult respuesta = MessageBox.Show("¿Está Seguro de Eliminar este Estudiante?", "Eliminar(?)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Crear un objeto para la lógica de negocio
                    ClsEstudiantes ObjEstudiante = new ClsEstudiantes { IdEstudiante = idEstudianteDelete };
                    ClsEstudiantesLn ObjEstudianateLn = new ClsEstudiantesLn();

                    // Llamar al método para eliminar el estudiante
                    ObjEstudianteLn.DeleteEstudiante(ref ObjEstudiante);

                    // Verificar si hubo un error
                    if (ObjEstudiante.MensajeError == null)
                    {
                        MessageBox.Show("Estudiante eliminado exitosamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Metodo para refrescar el DataGridView
                        CargarEstudiantes();
                    }
                    else
                    {
                        MessageBox.Show(ObjEstudiante.MensajeError, "Error al Eliminar Estudiante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al eliminar el Estudiante: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Metodo que concatena la variable idEstudianteDelete con la fila que se selecciono para eliminar
        private void dtgv_Estudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegurarse de que el clic no sea en el encabezado de la columna
            if (e.RowIndex >= 0)
            {
                string idEstudiante = dtgv_Estudiantes.Rows[e.RowIndex].Cells[0].Value.ToString();
                idEstudianteDelete = idEstudiante;

            }
        }
        #endregion

        //Metodos panel Cursos
        #region CURSOS  
        private void btn_Cursos_Click(object sender, EventArgs e)
        {
            pnl_Cursos.Visible = true;
            pnl_Admin.Visible = true;
            pnl_Docentes.Visible = true;
            pnl_Estudiantes.Visible = true;
            pnl_Nomina.Visible = false;
        }

        private void CargarCursos()
        {
            ObjCurso = new ClsCursos();
            ObjCursoLn.Index(ref ObjCurso);
            if (ObjCurso.MensajeError == null)
            {
                dtgv_Cursos.DataSource = ObjCurso.DtResultados;
            }
            else
            {
                MessageBox.Show(ObjCurso.MensajeError, "Error Cursos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_BuscarIdDoc_Click(object sender, EventArgs e)
        {
            string idDocente = txt_IdDocenteCur.Text;
            string nombre, apellido, facultad;

            try
            {
                ClsCursosLn cursosLn = new ClsCursosLn();
                cursosLn.ObtenerDatosDocente(idDocente, out nombre, out apellido, out facultad);

                txt_NombDCur.Text = nombre;
                txt_ApellDCur.Text = apellido;

                //Ver a que Facultad pertenece el Docente en base al ID de la Facultad
                switch (facultad)
                {
                    case "1":
                        facultad = "Ingenieria";
                        break;
                    case "2":
                        facultad = "Medicina";
                        break;
                    case "3":
                        facultad = "Letras";
                        break;
                    case "4":
                        facultad = "Artes";
                        break;
                }
                txt_FaculDCur.Text = facultad;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_AgregarCur_Click(object sender, EventArgs e)
        {
            
            //Variables para evitar campos vacios
            string idDocente = txt_IdDocenteCur.Text;
            string nombreDocente = txt_NombDCur.Text;
            string apellidoDocente = txt_ApellDCur.Text;
            string facultadDocente = txt_FaculDCur.Text;
            string nombreCurso = txt_NombCur.Text;
            string cantCreditos = txt_CantCur.Text;
            string cantAlumnos = txt_CantACur.Text;

            if (string.IsNullOrEmpty(idDocente)|string.IsNullOrEmpty(nombreDocente)|string.IsNullOrEmpty(apellidoDocente)|string.IsNullOrEmpty(facultadDocente)|string.IsNullOrEmpty(nombreCurso)|string.IsNullOrEmpty(cantCreditos)|string.IsNullOrEmpty(cantAlumnos))
            {
                MessageBox.Show("Hay campos vacíos, por favor llénalos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //Regresar la variable facultad al tipo de dato ID
                switch (facultadDocente)
                {
                    case "Ingenieria":
                        facultadDocente = "1";
                        break;
                    case "Medicina":
                        facultadDocente = "2";
                        break;
                    case "Letras":
                        facultadDocente = "3";
                        break;
                    case "Artes":
                        facultadDocente = "4";
                        break;
                }
                txt_FaculDCur.Text = facultadDocente;
                //Insertar nuevo curso
                ObjCurso = new ClsCursos()
                {
                    Nombcurso = nombreCurso,
                    CantCreditos = Convert.ToInt32(cantCreditos),
                    NumEstudiantes = Convert.ToInt32(cantAlumnos),
                    IdDocente = idDocente,
                    Facultad = facultadDocente,
                    FechaRegistro = DateTime.Now,
                };
                ObjCursoLn.CreateCurso(ref ObjCurso);
                if (ObjCurso.MensajeError == null)
                {
                    MessageBox.Show("Curso creado exitosamente", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(ObjCurso.MensajeError, "Error al Agregar Curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Limpiar Campos
                txt_IdDocenteCur.Text = "";
                txt_NombDCur.Text = "";
                txt_ApellDCur.Text = "";
                txt_FaculDCur.Text = "";
                txt_NombCur.Text = "";
                txt_CantCur.Text = "";
                txt_CantACur.Text = "";

                CargarCursos();
            }
        }

        private void btn_EliminarCur_Click(object sender, EventArgs e)
        {
            //Condicional que verifica si se selecciono una celda del datagrid
            if (dtgv_Cursos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un Curso para eliminar", "Error Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Preguntar al usuario si está seguro de eliminar
            DialogResult respuesta = MessageBox.Show("¿Está Seguro de Eliminar este Curso?", "Eliminar(?)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Crear un objeto para la lógica de negocio
                    ClsCursos ObjCurso = new ClsCursos { IdCurso = idCursoDelete };
                    ClsCursosLn ObjCursoLn = new ClsCursosLn();

                    // Llamar al método para eliminar el curso
                    ObjCursoLn.DeleteCurso(ref ObjCurso);

                    // Verificar si hubo un error
                    if (ObjCurso.MensajeError == null)
                    {
                        MessageBox.Show("Curso eliminado exitosamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Metodo para refrescar el DataGridView
                        CargarCursos();
                    }
                    else
                    {
                        MessageBox.Show(ObjCurso.MensajeError, "Error al Eliminar Curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al eliminar el Curso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtgv_Cursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegurarse de que el clic no sea en el encabezado de la columna
            if (e.RowIndex >= 0)
            {
                // Obtén el ID del administrador de la primera columna 
                int idCurso = Convert.ToInt32(dtgv_Cursos.Rows[e.RowIndex].Cells[0].Value.ToString());
                idCursoDelete = idCurso;

            }
        }
        #endregion

        //Metodos panel Nomina
        #region NOMINAS
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

        //Metodo para la Fecha usando un timer
        private void fecha_Tick(object sender, EventArgs e)
        {
            lbl_Fecha.Text = DateTime.Now.ToString("f");
        }

        //Boton que hace visible el panel de nomina
        private void btn_Nomina_Click(object sender, EventArgs e)
        {
            pnl_Admin.Visible = true;
            pnl_Docentes.Visible = true;
            pnl_Estudiantes.Visible = true;
            pnl_Cursos.Visible = true;
            pnl_Nomina.Visible = true;
        }

        //Boton para traer los datos del docente a los textbox (Nombre, Apellido, Salario)
        private void btn_BuscarDocNomi_Click(object sender, EventArgs e)
        {
            string idDocente = txt_idDocNom.Text;
            string nombre, apellido, facultad;
            int salario;
            try
            {
                //Objeto de la clase nomina
                ClsNominaLn ObjNominaLn = new ClsNominaLn();
                ObjNominaLn.ObtenerDatosDocente(idDocente, out nombre, out apellido, out facultad, out salario);

                //Asignando valores a los campos
                txt_NombDocNomi.Text = nombre;
                txt_ApellDocNomi.Text = apellido;
                txt_SalarioDoc.Text = salario.ToString();

                //Poner la facultad en terminos de letras y no solo el ID
                switch (facultad)
                {
                    case "1":
                        facultad = "Ingenieria";
                        break;
                    case "2":
                        facultad = "Medicina";
                        break;
                    case "3":
                        facultad = "Letras";
                        break;
                    case "4":
                        facultad = "Artes";
                        break;
                }
                txt_FacultadDocNom.Text = facultad;

                //Manejo de Error al no haber encontrado al docente
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido))
                {
                    MessageBox.Show("No se Encontro el Docente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Metodo para limpiar campos
        private void LimpiarCampos()
        {
            txt_idDocNom.Text = "";
            txt_NombDocNomi.Text = "";
            txt_ApellDocNomi.Text = "";
            txt_FacultadDocNom.Text = "";
            txt_SalarioDoc.Text = "";
            txt_Pago_HE.Text = "";
            txt_HoraExtra.Text = "";
            txt_TotalHE.Text = "";
            txt_SalarioNeto.Text = "";
        }

        //Boton para limpiar campos
        private void btn_LimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        //Boton para agregar una nomina a la tabla
        private void btn_AgregarNomi_Click(object sender, EventArgs e)
        {
            //Variables que validan si hay campos nulos
            string idDocente = txt_idDocNom.Text;
            string nombreDocente = txt_NombDocNomi.Text;
            string apellidoDocente = txt_ApellDocNomi.Text;
            string facultadDocente = txt_FacultadDocNom.Text;
            string salarioDocente = txt_SalarioDoc.Text;
            string horaExtra = txt_HoraExtra.Text;
            string pagoHE = txt_Pago_HE.Text;
            string totalHE = txt_TotalHE.Text;
            string salarioNeto = txt_SalarioNeto.Text;

            //Condicional para validar campos vacios
            if (string.IsNullOrEmpty(idDocente) || string.IsNullOrEmpty(nombreDocente) || string.IsNullOrEmpty(apellidoDocente)
                    || string.IsNullOrEmpty(salarioDocente)|| string.IsNullOrEmpty(horaExtra)|| string.IsNullOrEmpty(pagoHE)||
                    string.IsNullOrEmpty(totalHE)||string.IsNullOrEmpty(salarioNeto))
            {
                MessageBox.Show("Hay campos vacíos, por favor llénalos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //Regresar la facultad a su valor de ID para poder agregar la nomina a la tabla
                switch (facultadDocente)
                {
                    case "Ingenieria":
                        facultadDocente = "1";
                        break;
                    case "Medicina":
                        facultadDocente = "2";
                        break;
                    case "Letras":
                        facultadDocente = "3";
                        break;
                    case "Artes":
                        facultadDocente = "4";
                        break;
                }
                txt_FacultadDocNom.Text = facultadDocente;

                ObjNomina = new ClsNomina()
                {
                    Nombre = nombreDocente,
                    Apellido = apellidoDocente,
                    Facultad = facultadDocente,
                    SalarioContrato = Convert.ToInt32(salarioDocente),
                    SalarioNeto = Convert.ToInt32(salarioNeto),
                    HoraExtra = Convert.ToInt32(horaExtra),
                    PagoHoraExtra = Convert.ToInt32(pagoHE),
                    TotalHoraExtra = Convert.ToInt32(totalHE),
                    FechaRegistro = DateTime.Now,
                };
                ObjNominaLn.CreateNomina(ref ObjNomina);
                if (ObjNomina.MensajeError == null)
                {
                    MessageBox.Show("Nomina Generada exitosamente", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarNominas();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(ObjNomina.MensajeError, "Error al Generar Nomina", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Boton para calcular el total de horas extra y el salario neto
        private void btn_CalcularNom_Click(object sender, EventArgs e)
        {
            // Validar y convertir los valores de los TextBox
            if (int.TryParse(txt_SalarioDoc.Text, out int salarioDocente) &&
                int.TryParse(txt_HoraExtra.Text, out int horaExtra) &&
                int.TryParse(txt_Pago_HE.Text, out int pagoHE))
            {
                // Calcular el total de horas extra
                int totalHorasExtra = horaExtra * pagoHE;

                // Mostrar el total de horas extra en el TextBox correspondiente
                txt_TotalHE.Text = totalHorasExtra.ToString();

                // Calcular el salario neto (total horas extra + salario contrato)
                int salarioNeto = totalHorasExtra + salarioDocente;

                // Mostrar el salario neto en el TextBox correspondiente
                txt_SalarioNeto.Text = salarioNeto.ToString();
            }
            else
            {
                // Mostrar un mensaje de error si alguno de los campos tiene valores no numéricos
                MessageBox.Show("Por favor, ingresa valores numéricos válidos en todos los campos.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_EliminarNomi_Click(object sender, EventArgs e)
        {
            //Condicional que verifica si se selecciono una celda del datagrid
            if (dtgv_Nominas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una Nomina para eliminar", "Error Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Preguntar al usuario si está seguro de eliminar
            DialogResult respuesta = MessageBox.Show("¿Está Seguro de Eliminar esta Nomina?", "Eliminar(?)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Crear un objeto para la lógica de negocio
                    ClsNomina ObjNomina = new ClsNomina { IdNomina = idNominaDelete };
                    ClsNominaLn ObjNominaLn = new ClsNominaLn();

                    // Llamar al método para eliminar el curso
                    ObjNominaLn.DeleteNomina(ref ObjNomina);

                    // Verificar si hubo un error
                    if (ObjNomina.MensajeError == null)
                    {
                        MessageBox.Show("Nomina eliminada exitosamente.", "Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Metodo para refrescar el DataGridView
                        CargarNominas();
                    }
                    else
                    {
                        MessageBox.Show(ObjNomina.MensajeError, "Error al Eliminar Nomina", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al eliminar la nomina: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtgv_Nominas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegurarse de que el clic no sea en el encabezado de la columna
            if (e.RowIndex >= 0)
            {
                // Obtén el ID del administrador de la primera columna 
                int idNomina = Convert.ToInt32(dtgv_Nominas.Rows[e.RowIndex].Cells[0].Value.ToString());
                idNominaDelete = idNomina;

            }
        }
        #endregion

        //Metodo para llamar al form Reporte como ShowDialog
        #region REPORTE
        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            ReporteNomina reporteNomina = new ReporteNomina();
            reporteNomina.ShowDialog(); 
        }
        #endregion
    }
}
