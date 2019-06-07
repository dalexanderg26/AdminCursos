<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Modalidad.ascx.cs" Inherits="AdminCursos.Controles.Modalidad" %>
<div>
<div>MODALIDAD</div>
<div>
<table style="width: 98%;">
    <tr>
        <td>
           Modalidad:
        </td>
        <td colspan="3">
            <asp:TextBox ID="txtModalidad" runat="server" Width="491px" 
                MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvModalidad" runat="server" ControlToValidate="txtModalidad"
                ErrorMessage="El Nombre de la modalidad es requerida" ValidationGroup="GuardarM">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revModalidad" 
                ErrorMessage="El nombre de la modalidad debe contener caracteres alfanuméricos" 
                ControlToValidate="txtModalidad" Runat="server" 
                ValidationExpression="[A-Za-z0-9ÑñÁáÉéÍíÓóÚúÄäËëÏïÖöÜü´ ]+" ValidationGroup="GuardarM">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td colspan="3">
        </td>
    </tr>
     <tr>
        <td colspan="3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true"
                ValidationGroup="GuardarM" CssClass="validation" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button runat="server" ID="btnGuardar" Text="Guardar"  CssClass="boton75" CausesValidation="true"
            ValidationGroup="GuardarM" onclick="btnGuardar_Click"/>
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
            <asp:GridView ID="gvModalidad"
            runat="server" AutoGenerateColumns="False" 
            EnableModelValidation="True"
                DataKeyNames="Id" EmptyDataText="No hay registros" Width="97%"
                OnRowCommand="gvModalidad_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Modalidad" DataField="nombre">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <a runat="server" id="lnkEditarM" title='Editar'>
                                <asp:ImageButton ID="imgEditar" runat="server" CommandName="EditarM" 
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
<asp:HiddenField ID="hfIdM" runat="server" />

