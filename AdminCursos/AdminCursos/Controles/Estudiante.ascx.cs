using Controladores;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace AdminCursos.Controles
{
    public partial class Estudiante : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ObtenerTiposDocumento();
                ObtenerEstudiantes();
                this.lblMensaje.Visible = false;
                this.lblMensaje.Text = string.Empty;
            }
        }

        private void ObtenerTiposDocumento()
        {
            List<Modelo.TipoDocumento> tiposDocumento = new List<Modelo.TipoDocumento>();
            Modelo.TipoDocumento tipoDocumento = new Modelo.TipoDocumento();
            TipoDocumentoController controladorTD = new TipoDocumentoController();
            tipoDocumento.Id = 0;
            tiposDocumento = (List<Modelo.TipoDocumento>)controladorTD.Consultar(tipoDocumento);
            this.ddlTipoDocumento.DataSource = tiposDocumento;
            this.ddlTipoDocumento.DataTextField = "Nombre";
            this.ddlTipoDocumento.DataValueField = "Id";
            this.ddlTipoDocumento.DataBind();
            this.ddlTipoDocumento.Items.Insert(0, new ListItem("Seleccione", "-1"));
            this.ddlTipoDocumento.SelectedIndex = 0;
        }

        private void ObtenerEstudiantes()
        {
            List<Modelo.Estudiante> estudiantes = new List<Modelo.Estudiante>();
            Modelo.Estudiante estudiante = new Modelo.Estudiante();
            EstudianteController controladorEstudiante = new EstudianteController();
            estudiante.Id = 0;
            estudiantes = (List<Modelo.Estudiante>)controladorEstudiante.Consultar(estudiante);
            this.gvEstudiante.DataSource = estudiantes;
            this.gvEstudiante.DataBind();
        }

        protected void gvEstudiante_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            int idEstudiante = Convert.ToInt32(this.gvEstudiante.DataKeys[index]["Id"]);
            if (e.CommandName == "EditarEstudiante")
            {
                Modelo.Estudiante estudiante = new Modelo.Estudiante();
                List<Modelo.Estudiante> estudiantes = new List<Modelo.Estudiante>();
                EstudianteController controladorEstudiante = new EstudianteController();
                estudiante.Id = idEstudiante;
                estudiantes = (List<Modelo.Estudiante>)controladorEstudiante.Consultar(estudiante);
                ObtenerEstudiante(estudiantes.FirstOrDefault());
            }
        }

        private void ObtenerEstudiante(Modelo.Estudiante estudiante)
        {
            this.hfIdEstudiante.Value = estudiante.Id.ToString();
            this.ddlTipoDocumento.SelectedValue = estudiante.TipoDocumento.Id.ToString();
            this.txtNumeroDocumento.Text = estudiante.NumeroDocumento;
            this.txtPrimerNombre.Text = estudiante.PrimerNombre;
            this.txtPrimerApellido.Text = estudiante.PrimerApellido;
            this.txtSegundoNombre.Text = estudiante.SegundoNombre;
            this.txtSegundoApellido.Text = estudiante.SegundoApellido;
            this.txtCorreoElectronico.Text = estudiante.CorreoElectronico;
        }

        private void GuardarEstudiante()
        {
            Modelo.Estudiante estudiante = new Modelo.Estudiante();
            Resultado resultado = new Resultado();
            EstudianteController controladorEstudiante = new EstudianteController();
            string mensaje = string.Empty;

            if (string.IsNullOrEmpty(this.hfIdEstudiante.Value) == true)
            {
                estudiante.Id = 0;
            }
            else
            {
                estudiante.Id = Convert.ToInt32(this.hfIdEstudiante.Value);
            }

            estudiante.TipoDocumento = new Modelo.TipoDocumento(int.Parse(this.ddlTipoDocumento.SelectedValue), string.Empty);
            estudiante.NumeroDocumento = this.txtNumeroDocumento.Text;
            estudiante.PrimerNombre = this.txtPrimerNombre.Text;
            estudiante.PrimerApellido = this.txtPrimerApellido.Text;
            estudiante.SegundoNombre = this.txtSegundoNombre.Text;
            estudiante.SegundoApellido = this.txtSegundoApellido.Text;
            estudiante.CorreoElectronico = this.txtCorreoElectronico.Text;
            
            if (estudiante.Id == 0)
            {
                resultado = (Resultado)controladorEstudiante.Guardar(estudiante);
                mensaje = "Registro insertado correctamente";
            }
            else
            {
                resultado = (Resultado)controladorEstudiante.Actualizar(estudiante);
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
                ObtenerEstudiantes();
            }
        }

        private void LimpiarFormulario()
        {
            this.hfIdEstudiante.Value = string.Empty;
            this.ddlTipoDocumento.SelectedIndex = 0;
            this.txtNumeroDocumento.Text = string.Empty;
            this.txtPrimerNombre.Text = string.Empty;
            this.txtPrimerApellido.Text = string.Empty;
            this.txtSegundoNombre.Text = string.Empty;
            this.txtSegundoApellido.Text = string.Empty;
            this.txtCorreoElectronico.Text = string.Empty;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarEstudiante();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}