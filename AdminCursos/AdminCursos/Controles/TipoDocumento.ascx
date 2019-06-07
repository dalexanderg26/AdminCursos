<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TipoDocumento.ascx.cs" Inherits="AdminCursos.Controles.TipoDocumento" %>

<div>
<div>TIPO DOCUMENTO</div>
<div>
<table style="width: 98%;">
    <tr>
        <td>
           Tipo Documento:
        </td>
        <td colspan="3">
            <asp:TextBox ID="txtTipoDocumento" runat="server" Width="491px" 
                MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTipoDocumento" runat="server" ControlToValidate="txtTipoDocumento"
                ErrorMessage="El Nombre del Tipo de documento es requerido" ValidationGroup="GuardarTD">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revTipoDocumento" 
                ErrorMessage="El nombre del tipo de documento debe contener caracteres alfanuméricos" 
                ControlToValidate="txtTipoDocumento" Runat="server" 
                ValidationExpression="[A-Za-z0-9ÑñÁáÉéÍíÓóÚúÄäËëÏïÖöÜü´ ]+" ValidationGroup="GuardarTD">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td colspan="3">
        </td>
    </tr>
     <tr>
        <td colspan="3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true"
                ValidationGroup="GuardarTD" CssClass="validation" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button runat="server" ID="btnGuardar" Text="Guardar"  CssClass="boton75" CausesValidation="true"
            ValidationGroup="GuardarTD" onclick="btnGuardar_Click"/>
        </td>
        <td colspan="2">
            <asp:Button runat="server" ID="btnLimpiar" Text="Limpiar" OnClick="btnLimpiar_Click" />  
        </td>
    </tr>
   
    <tr>
        <td colspan="3">
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:GridView ID="gvTipoDocumento"
            runat="server" AutoGenerateColumns="False" 
            EnableModelValidation="True"
                DataKeyNames="Id" EmptyDataText="No hay registros" Width="97%"
                OnRowCommand="gvTipoDocumento_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Tipo Documento" DataField="nombre">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <a runat="server" id="lnkEditarTD" title='Editar'>
                                <asp:ImageButton ID="imgEditar" runat="server" CommandName="EditarTD" 
                                    CommandArgument='<%# Container.DataItemIndex %>' CausesValidation="false" 
                                    ImageUrl="~/Imagenes/editar32.png">
                                </asp:ImageButton>
                            </a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
</div>
</div>
<asp:HiddenField ID="hfIdTD" runat="server" />
