using Modelo;
using Controladores;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Linq;

namespace AdminCursos.Controles
{
    public partial class Curso : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ObtenerModalidades();
                ObtenerCursos();
                this.lblMensaje.Visible = false;
                this.lblMensaje.Text = string.Empty;
            }

            this.txtFechaInicio.Attributes.Add("readonly", "readonly");
            this.txtFechaFin.Attributes.Add("readonly", "readonly");
            this.txtFechaLimite.Attributes.Add("readonly", "readonly");
        }

        private void ObtenerModalidades()
        {
            List<Modelo.Modalidad> modalidades = new List<Modelo.Modalidad>();
            Modelo.Modalidad modalidad = new Modelo.Modalidad();
            ModalidadController controladorModalidad = new ModalidadController();
            modalidad.Id = 0;
            modalidades = (List<Modelo.Modalidad>)controladorModalidad.Consultar(modalidad);
            this.ddlModalidad.DataSource = modalidades;
            this.ddlModalidad.DataTextField = "Nombre";
            this.ddlModalidad.DataValueField = "Id";
            this.ddlModalidad.DataBind();
            this.ddlModalidad.Items.Insert(0, new ListItem("Seleccione", "-1"));
            this.ddlModalidad.SelectedIndex = 0;
        }

        private void ObtenerCursos()
        {
            List<Modelo.Curso> cursos = new List<Modelo.Curso>();
            Modelo.Curso curso = new Modelo.Curso();
            CursoController controladorCurso= new CursoController();
            curso.Id = 0;
            cursos = (List< Modelo.Curso>)controladorCurso.Consultar(curso);
            this.gvCurso.DataSource = cursos;
            this.gvCurso.DataBind();
        }

        protected void gvCurso_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            int idCurso = Convert.ToInt32(this.gvCurso.DataKeys[index]["Id"]);
            if (e.CommandName == "EditarCurso")
            {
                Modelo.Curso curso = new Modelo.Curso();
                List<Modelo.Curso> cursos = new List<Modelo.Curso>();
                CursoController controladorCurso = new CursoController();
                curso.Id = idCurso;
                cursos = (List<Modelo.Curso>)controladorCurso.Consultar(curso);
                ObtenerCurso(cursos.FirstOrDefault());
            }
        }

        private void ObtenerCurso(Modelo.Curso curso)
        {
            this.hfIdCurso.Value = curso.Id.ToString();
            this.txtNombreCurso.Text = curso.Nombre;
            this.txtDescripcionCurso.Text = curso.Descripcion;
            this.ddlModalidad.SelectedValue = curso.Modalidad.Id.ToString();
            this.txtFechaInicio.Text = curso.FechaInicio.ToShortDateString();
            this.txtFechaFin.Text = curso.FechaFin.ToShortDateString();
            if (curso.FechaLimiteInscripcion.HasValue == true)
            {
                this.txtFechaLimite.Text = curso.FechaLimiteInscripcion.Value.ToShortDateString();
            }
            else
            {
                this.txtFechaLimite.Text = string.Empty;
            }

            this.txtHoras.Text = curso.Horas.ToString();
            this.txtCupos.Text = curso.TotalCupos.ToString();
            this.chkCerrado.Checked = curso.Cerrado;
        }

        private void GuardarCurso()
        {
            Modelo.Curso curso = new Modelo.Curso();
            Resultado resultado = new Resultado();
            CursoController controladorCurso = new CursoController();
            string mensaje = string.Empty;

            if (string.IsNullOrEmpty(this.hfIdCurso.Value) == true)
            {
                curso.Id = 0;
            }
            else
            {
                curso.Id = Convert.ToInt32(this.hfIdCurso.Value);
            }

            curso.Nombre = this.txtNombreCurso.Text;
            curso.Descripcion = this.txtDescripcionCurso.Text;
            curso.Modalidad = new Modelo.Modalidad(int.Parse(this.ddlModalidad.SelectedValue), string.Empty);
            curso.FechaInicio = Convert.ToDateTime(this.txtFechaInicio.Text);
            curso.FechaFin = Convert.ToDateTime(this.txtFechaFin.Text);
            curso.FechaLimiteInscripcion = Convert.ToDateTime(this.txtFechaLimite.Text);
            curso.Horas = int.Parse(this.txtHoras.Text);
            curso.TotalCupos = int.Parse(this.txtCupos.Text);
            curso.Cerrado = this.chkCerrado.Checked;

            if (curso.Id == 0)
            {
                resultado = (Resultado)controladorCurso.Guardar(curso);
                mensaje = "Registro insertado correctamente";
            }
            else
            {
                resultado = (Resultado)controladorCurso.Actualizar(curso);
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
                ObtenerCursos();
            }
        }

        private void LimpiarFormulario()
        {
            this.txtNombreCurso.Text = string.Empty;
            this.hfIdCurso.Value = string.Empty;
            this.ddlModalidad.SelectedIndex = 0;
            this.txtDescripcionCurso.Text = string.Empty;
            this.txtFechaInicio.Text = string.Empty;
            this.txtFechaFin.Text = string.Empty;
            this.txtFechaLimite.Text = string.Empty;
            this.txtHoras.Text = string.Empty;
            this.txtCupos.Text = string.Empty;
            this.chkCerrado.Checked = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCurso();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}