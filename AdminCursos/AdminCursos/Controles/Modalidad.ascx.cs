using Modelo;
using Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;


namespace AdminCursos.Controles
{
    public partial class Modalidad : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ObtenerModalidades();
                this.hfIdM.Value = string.Empty;
                this.lblMensaje.Text = string.Empty;
                this.lblMensaje.Visible = false;
            }
        }

        protected void gvModalidad_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            int idTipoDocumento = Convert.ToInt32(this.gvModalidad.DataKeys[index]["Id"]);
            if (e.CommandName == "EditarM")
            {
                Modelo.Modalidad modalidad = new Modelo.Modalidad();
                List< Modelo.Modalidad> modalidades = new List<Modelo.Modalidad>();
                ModalidadController controladorModalidad= new ModalidadController();
                modalidad.Id = idTipoDocumento;
                modalidades = (List< Modelo.Modalidad>)controladorModalidad.Consultar(modalidad);
                ObtenerModalidad(modalidades.FirstOrDefault());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                GuardarModalidad();
            }
        }

        private void ObtenerModalidades()
        {
            List< Modelo.Modalidad> modalidades = new List<Modelo.Modalidad>();
            Modelo.Modalidad modalidad = new Modelo.Modalidad();
            ModalidadController controladorModalidad = new ModalidadController();
            modalidad.Id = 0;
            modalidades = (List<Modelo.Modalidad>)controladorModalidad.Consultar(modalidad);
            this.gvModalidad.DataSource = modalidades;
            this.gvModalidad.DataBind();
        }

        private void ObtenerModalidad(Modelo.Modalidad modalidad)
        {
            this.txtModalidad.Text = modalidad.Nombre;
            this.hfIdM.Value = modalidad.Id.ToString();
        }


        private void LimpiarFormulario()
        {
            this.txtModalidad.Text = string.Empty;
            this.hfIdM.Value = string.Empty;
        }

        private void GuardarModalidad()
        {
            Modelo.Modalidad modalidad = new Modelo.Modalidad();
            Resultado resultado = new Resultado();
            ModalidadController controladorModalidad = new ModalidadController();
            string mensaje = string.Empty;

            if (string.IsNullOrEmpty(this.hfIdM.Value) == true)
            {
                modalidad.Id = 0;
            }
            else
            {
                modalidad.Id = Convert.ToInt32(this.hfIdM.Value);
            }

            modalidad.Nombre = this.txtModalidad.Text;

            if (modalidad.Id == 0)
            {
                resultado = (Resultado)controladorModalidad.Guardar(modalidad);
                mensaje = "Registro insertado correctamente";
            }
            else
            {
                resultado = (Resultado)controladorModalidad.Actualizar(modalidad);
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
                ObtenerModalidades();
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            this.lblMensaje.Text = string.Empty;
            this.lblMensaje.Visible = false;
        }
    }
}