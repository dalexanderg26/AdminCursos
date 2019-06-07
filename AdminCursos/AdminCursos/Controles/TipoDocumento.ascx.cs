using Modelo;
using Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;


namespace AdminCursos.Controles
{
    public partial class TipoDocumento : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ObtenerTiposDocumento();
                this.hfIdTD.Value = string.Empty;
                this.lblMensaje.Text = string.Empty;
                this.lblMensaje.Visible = false;
            }
        }

        protected void gvTipoDocumento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            int idTipoDocumento = Convert.ToInt32(this.gvTipoDocumento.DataKeys[index]["Id"]);
            if (e.CommandName == "EditarTD")
            {
                Modelo.TipoDocumento tipoDocumento = new Modelo.TipoDocumento();
                List<Modelo.TipoDocumento> tiposDocumento = new List<Modelo.TipoDocumento>();
                TipoDocumentoController controladorTipoDocumento = new TipoDocumentoController();
                tipoDocumento.Id = idTipoDocumento;
                tiposDocumento = (List<Modelo.TipoDocumento>)controladorTipoDocumento.Consultar(tipoDocumento);
                ObtenerTipoDocumento(tiposDocumento.FirstOrDefault());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                GuardarTipoDocumento();
            }
        }


        private void ObtenerTiposDocumento()
        {
            List<Modelo.TipoDocumento> tiposDocumento = new List<Modelo.TipoDocumento>();
            Modelo.TipoDocumento tipoDocumento = new Modelo.TipoDocumento();
            TipoDocumentoController controladorTipoDocumento = new TipoDocumentoController();
            tipoDocumento.Id = 0;
            tiposDocumento = (List<Modelo.TipoDocumento>)controladorTipoDocumento.Consultar(tipoDocumento);
            this.gvTipoDocumento.DataSource = tiposDocumento;
            this.gvTipoDocumento.DataBind();
        }

        private void ObtenerTipoDocumento(Modelo.TipoDocumento tipoDocumento)
        {
            this.txtTipoDocumento.Text = tipoDocumento.Nombre;
            this.hfIdTD.Value = tipoDocumento.Id.ToString();
        }


        private void LimpiarFormulario()
        {
            this.txtTipoDocumento.Text = string.Empty;
            this.hfIdTD.Value = string.Empty;
        }

        private void GuardarTipoDocumento()
        {
            Modelo.TipoDocumento tipoDocumento = new Modelo.TipoDocumento();
            Resultado resultado = new Resultado();
            TipoDocumentoController controladorTipoDocumento = new TipoDocumentoController();
            string mensaje = string.Empty;

            if (string.IsNullOrEmpty(this.hfIdTD.Value) == true)
            {
                tipoDocumento.Id = 0;
            }
            else
            {
                tipoDocumento.Id = Convert.ToInt32(this.hfIdTD.Value);
            }

            tipoDocumento.Nombre = this.txtTipoDocumento.Text;

            if (tipoDocumento.Id == 0)
            {
                resultado = (Resultado)controladorTipoDocumento.Guardar(tipoDocumento);
                mensaje = "Registro insertado correctamente";
            }
            else
            {
                resultado = (Resultado)controladorTipoDocumento.Actualizar(tipoDocumento);
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
                ObtenerTiposDocumento();
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