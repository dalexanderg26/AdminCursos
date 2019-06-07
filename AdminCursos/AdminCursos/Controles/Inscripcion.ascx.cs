using Modelo;
using Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;


namespace AdminCursos.Controles
{
    public partial class Inscripcion : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ObtenerCursos();
                ObtenerEstudiantes();
                ObtenerInscripciones();
                this.lblMensaje.Visible = false;
                this.lblMensaje.Text = string.Empty;
            }

            this.txtFechaInscripcion.Attributes.Add("readonly", "readonly");
        }

        private void ObtenerCursos()
        {
            List<Modelo.Curso> cursos = new List<Modelo.Curso>();
            Modelo.Curso curso = new Modelo.Curso();
            CursoController controladorCurso = new CursoController();
            curso.Id = 0;
            cursos = (List<Modelo.Curso>)controladorCurso.Consultar(curso);
             var cursosFiltrados = cursos.Where(x => x.Cerrado == false);
            this.ddlCurso.DataSource = cursosFiltrados;
            this.ddlCurso.DataTextField = "Nombre";
            this.ddlCurso.DataValueField = "Id";
            this.ddlCurso.DataBind();
            this.ddlCurso.Items.Insert(0, new ListItem("Seleccione", "-1"));
            this.ddlCurso.SelectedIndex = 0;
        }

        private void ObtenerEstudiantes()
        {
            List<Modelo.Estudiante> estudiantes = new List<Modelo.Estudiante>();
           Modelo.Estudiante estudiante = new Modelo.Estudiante();
            EstudianteController controladorEstudiante = new EstudianteController();
            estudiante.Id = 0;
            estudiantes = (List<Modelo.Estudiante>)controladorEstudiante.Consultar(estudiante);
            this.ddlEstudiante.DataSource = estudiantes;
            this.ddlEstudiante.DataTextField = "NombresCompletos";
            this.ddlEstudiante.DataValueField = "Id";
            this.ddlEstudiante.DataBind();
            this.ddlEstudiante.Items.Insert(0, new ListItem("Seleccione", "-1"));
            this.ddlEstudiante.SelectedIndex = 0;
        }

        private void ObtenerInscripciones()
        {
            List<Modelo.Inscripcion> inscripciones = new List<Modelo.Inscripcion>();
            Modelo.Inscripcion inscripcion = new Modelo.Inscripcion();
            InscripcionController controladorInscripcion = new InscripcionController();
            inscripcion.Id = 0;
            inscripciones = (List<Modelo.Inscripcion>)controladorInscripcion.Consultar(inscripcion);
            this.gvInscripcion.DataSource = inscripciones;
            this.gvInscripcion.DataBind();
        }

        private void ObtenerInscripcion(Modelo.Inscripcion inscripcion)
        {
            this.hfIdInscripcion.Value = inscripcion.Id.ToString();
            this.ddlCurso.SelectedValue = inscripcion.Curso.Id.ToString();
            this.ddlEstudiante.SelectedValue = inscripcion.Estudiante.Id.ToString();
            this.txtFechaInscripcion.Text = inscripcion.FechaInscripcion.Value.ToShortDateString();
            this.txtNota.Text = inscripcion.NotaFinal.ToString();
        }

        private void GuardarInscripcion()
        {
            this.lblMensaje.Visible = false;
            this.lblMensaje.Text = string.Empty;
            InscripcionController controladorInscripcion = new InscripcionController();
            int idCurso = int.Parse(this.ddlCurso.SelectedValue);
            DateTime fechaInscripcion = Convert.ToDateTime(this.txtFechaInscripcion.Text);
            int idEstudiante = int.Parse(this.ddlEstudiante.SelectedValue);
            double nota = 0.0;

            if (string.IsNullOrEmpty(this.txtNota.Text) == false)
            {
                nota = double.Parse(this.txtNota.Text.Replace('.',','));
            }

            if (nota < 0.0 || nota > 5.0)
            {
                this.lblMensaje.Visible = true;
                this.lblMensaje.Text = "Nota inválida";
                return;
            }

            if (controladorInscripcion.ValidarCuposDisponibles(idCurso) == false)
            {
                this.lblMensaje.Visible = true;
                this.lblMensaje.Text = "No hay cupos disponibles para este curso";
                return;
            }

            if (controladorInscripcion.ValidarFechaInscripcion(idCurso, fechaInscripcion) == false)
            {
                this.lblMensaje.Visible = true;
                this.lblMensaje.Text = "No se puede inscribir al curso por fecha de inscripción";
                return;
            }

            Modelo.Inscripcion inscripcion = new Modelo.Inscripcion();
            Resultado resultado = new Resultado();
            string mensaje = string.Empty;

            if (string.IsNullOrEmpty(this.hfIdInscripcion.Value) == true)
            {
                inscripcion.Id = 0;
            }
            else
            {
                inscripcion.Id = Convert.ToInt32(this.hfIdInscripcion.Value);
            }

            inscripcion.Curso = new Modelo.Curso(idCurso, string.Empty);
            inscripcion.Estudiante = new Modelo.Estudiante(idEstudiante);
            inscripcion.FechaInscripcion = fechaInscripcion;
            inscripcion.NotaFinal = nota;

            if (inscripcion.Id == 0)
            {
                resultado = (Resultado)controladorInscripcion.Guardar(inscripcion);
                mensaje = "Registro insertado correctamente";
            }
            else
            {
                resultado = (Resultado)controladorInscripcion.Actualizar(inscripcion);
                mensaje = "Registro actualizado correctamente";
            }

            if (resultado.Error == true)
            {
                this.lblMensaje.Text = resultado.Mensaje;
                this.lblMensaje.Visible = true;
                return;
            }
            else
            {
                this.lblMensaje.Visible = true;
                this.lblMensaje.Text = mensaje;
                LimpiarFormulario();
                ObtenerInscripciones();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                GuardarInscripcion();
            }
        }

        private void LimpiarFormulario()
        {
            this.hfIdInscripcion.Value = string.Empty;
            this.ddlCurso.SelectedIndex = 0;
            this.ddlEstudiante.SelectedIndex = 0;
            this.txtNota.Text = string.Empty;
            this.txtFechaInscripcion.Text = string.Empty;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        protected void gvInscripcion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            int idInscripcion = Convert.ToInt32(this.gvInscripcion.DataKeys[index]["Id"]);
            if (e.CommandName == "EditarInscripcion")
            {
                Modelo.Inscripcion inscripcion = new Modelo.Inscripcion();
                List<Modelo.Inscripcion> inscripciones = new List<Modelo.Inscripcion>();
                InscripcionController controladorInscripcion = new InscripcionController();
                inscripcion.Id = idInscripcion;
                inscripciones = (List<Modelo.Inscripcion>)controladorInscripcion.Consultar(inscripcion);
                ObtenerInscripcion(inscripciones.FirstOrDefault());
            }
        }
    }
}