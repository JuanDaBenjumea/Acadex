# Software Académico

Sistema de escritorio para la gestión académica de una institución educativa, desarrollado en **C# (WinForms)** sobre **.NET Framework 4.8**, con persistencia en **SQL Server** y arquitectura en capas.

Permite administrar facultades, programas, estudiantes, docentes, cursos, matrículas y nómina desde un panel de administración centralizado, con autenticación de usuarios por rol.

## Tabla de contenido

- [Características](#características)
- [Arquitectura](#arquitectura)
- [Tecnologías](#tecnologías)
- [Estructura del proyecto](#estructura-del-proyecto)
- [Requisitos previos](#requisitos-previos)
- [Instalación y configuración](#instalación-y-configuración)
- [Uso](#uso)
- [Estado del proyecto](#estado-del-proyecto)
- [Licencia](#licencia)

## Características

- **Login con control de acceso por rol** (Administrador, Docente, Estudiante) validado contra la base de datos.
- **Panel de administración** con gestión CRUD (crear, listar, filtrar, eliminar) para:
  - Estudiantes
  - Docentes
  - Administradores
  - Cursos
  - Nómina de docentes
- **Generación de reportes de nómina** exportables a archivo de texto.
- Validaciones de duplicidad (por ejemplo, comprobación de identificadores y usuarios existentes) antes de insertar registros.
- Toda la lógica de acceso a datos se ejecuta mediante **procedimientos almacenados** de SQL Server, evitando SQL embebido en la aplicación.

## Arquitectura

El proyecto sigue una arquitectura en **4 capas**, organizadas como proyectos independientes dentro de una misma solución de Visual Studio:

```
PryPresentacion1   →  Interfaz de usuario (WinForms: Login, AdminPanel, formularios de alta, reportes)
        ↓
PryLogicaNegocio   →  Reglas de negocio y orquestación (ClsEstudiantesLn, ClsDocentesLn, ClsCursosLn, etc.)
        ↓
PryAccesoDatos     →  Acceso a datos genérico vía ADO.NET (SqlConnection, SqlCommand, SqlDataAdapter)
        ↓
PryEntidades       →  Clases de entidad / modelos de datos (POCOs)
        ↓
   SQL Server       →  Base de datos BD_Academia (tablas + procedimientos almacenados)
```

Cada capa solo conoce a la inmediatamente inferior, lo que facilita el mantenimiento y la sustitución de componentes (por ejemplo, cambiar el motor de base de datos sin tocar la lógica de negocio ni la interfaz).

## Tecnologías

| Componente         | Tecnología                          |
|---------------------|--------------------------------------|
| Lenguaje            | C#                                   |
| Framework           | .NET Framework 4.8                  |
| Interfaz de usuario | Windows Forms (WinForms)            |
| Base de datos       | Microsoft SQL Server                |
| Acceso a datos      | ADO.NET (`System.Data.SqlClient`)   |
| IDE recomendado     | Visual Studio 2022                  |

## Estructura del proyecto

```
SoftwareAcademico/
├── BD_Academia.sql              # Script de creación de la BD, tablas y procedimientos almacenados
└── SoftwareAcademico/
    ├── SoftwareAcademico.sln    # Solución de Visual Studio
    ├── PryEntidades/            # Modelos: ClsEstudiantes, ClsDocentes, ClsCursos, ClsNomina, etc.
    ├── PryAccesoDatos/          # ClsAccesoDatos: ejecución genérica de procedimientos almacenados
    ├── PryLogicaNegocio/        # Reglas de negocio por entidad (...Ln.cs)
    └── PryPresentacion1/        # Formularios WinForms (Login, AdminPanel, ReporteNomina, etc.)
```

## Requisitos previos

- [Visual Studio 2022](https://visualstudio.microsoft.com/) (o superior) con la carga de trabajo **".NET desktop development"**.
- **.NET Framework 4.8 Developer Pack**.
- **Microsoft SQL Server** (Express, Developer o LocalDB) y, opcionalmente, **SQL Server Management Studio (SSMS)** para ejecutar el script.

## Instalación y configuración

1. **Clona el repositorio**

   ```bash
   git clone https://github.com/<tu-usuario>/<tu-repositorio>.git
   ```

2. **Crea la base de datos**

   Abre `BD_Academia.sql` en SSMS (o `sqlcmd`) y ejecútalo contra tu instancia de SQL Server. El script crea la base de datos `BD_Academia`, todas las tablas y los procedimientos almacenados necesarios.

3. **Configura la cadena de conexión**

   Edita el archivo `PryAccesoDatos/app.config` (o `Properties/Settings.settings` desde Visual Studio) y ajusta `Data Source` con el nombre de tu instancia de SQL Server:

   ```xml
   <connectionStrings>
       <add name="PryAccesoDatos.Properties.Settings.Valor"
            connectionString="Data Source=TU_SERVIDOR;Initial Catalog=BD_Academia;Integrated Security=True;TrustServerCertificate=True"
            providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

   > ⚠️ El repositorio incluye por defecto el nombre de un equipo de desarrollo (`DESKTOP-PKVC4GL`). Debes reemplazarlo por el nombre de tu propia instancia o servidor.

4. **Abre la solución**

   Abre `SoftwareAcademico/SoftwareAcademico.sln` en Visual Studio, restaura los paquetes/dependencias si se solicita, y compila la solución completa.

5. **Ejecuta el proyecto de inicio**

   Asegúrate de que `PryPresentacion1` esté configurado como proyecto de inicio y presiona `F5` para ejecutar la aplicación.

## Uso

Al iniciar la aplicación se muestra la pantalla de **Login**. El script `BD_Academia.sql` inserta un administrador de ejemplo para pruebas iniciales (usuario y contraseña `Admin`); se recomienda **cambiar o eliminar estas credenciales antes de usar el sistema en un entorno real**, ya que actualmente las contraseñas se almacenan sin cifrar.

Una vez autenticado como administrador se accede al **panel de administración**, desde donde se pueden gestionar estudiantes, docentes, cursos, otros administradores y la nómina, además de generar el reporte de nómina.

## Estado del proyecto

Este es un proyecto académico en desarrollo activo. Estado actual por rol:

- ✅ **Administrador**: flujo completo (gestión CRUD de todas las entidades y reportes).
- 🚧 **Docente**: autenticación funcional, panel de funcionalidades pendiente de implementar.
- 🚧 **Estudiante**: autenticación funcional, panel de funcionalidades pendiente de implementar.

### Posibles mejoras futuras

- Cifrado de contraseñas (hashing) en lugar de almacenamiento en texto plano.
- Paneles dedicados para Docente y Estudiante (notas, asistencia, matrícula).
- Exportación de reportes a PDF/Excel.
- Externalizar la cadena de conexión fuera del control de versiones (por ejemplo, mediante variables de entorno o un archivo de configuración no versionado).

## Licencia

Este proyecto no especifica una licencia. Si deseas que el código sea reutilizable por terceros, considera añadir una licencia (por ejemplo, [MIT](https://choosealicense.com/licenses/mit/)).
