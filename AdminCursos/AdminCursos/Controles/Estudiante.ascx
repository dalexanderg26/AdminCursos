<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Estudiante.ascx.cs" Inherits="AdminCursos.Controles.Estudiante" %>

<div class="contenedor">
<div class="tituloEncabezadoAzul">ESTUDIANTES</div>
<table style="width: 98%;" class="filtroBusqueda">
    <tr>
        <td>
            Tipo Documento:
        </td>
        <td colspan="1">
            <asp:DropDownList ID="ddlTipoDocumento" runat="server" Height="18px" Width="238px">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvTipoDocumento" runat="server" 
            ControlToValidate="ddlTipoDocumento" 
            ErrorMessage="La modalidad es requerida"
            InitialValue="-1" ValidationGroup="GuardarEstudiante">*</asp:RequiredFieldValidator>
        </td>
    </tr>
      <tr>
        <td>
           Número Documento: </td>
        <td colspan="1">
            <asp:TextBox ID="txtNumeroDocumento" runat="server" Width="493px" MaxLength="500">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNumeroDocumento" runat="server" 
            ControlToValidate="txtNumeroDocumento"
                ErrorMessage="El número de documento es requerido" ValidationGroup="GuardarEstudiante">*</asp:RequiredFieldValidator>
        </td>
    </tr>
      <tr>
        <td>
            Primer Nombre:
        </td>
        <td colspan="1">
            <asp:TextBox ID="txtPrimerNombre" runat="server" Width="493px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPrimerNombre" runat="server" ControlToValidate="txtPrimerNombre"
                ErrorMessage="El Primer Nombre es requerido" ValidationGroup="GuardarEstudiante">*</asp:RequiredFieldValidator>
        </td>
    </tr>
     <tr>
        <td>
            Segundo Nombre:
        </td>
        <td colspan="1">
            <asp:TextBox ID="txtSegundoNombre" Width="493px" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Primer Apellido:
        </td>
        <td colspan="1">
            <asp:TextBox ID="txtPrimerApellido" Width="493px" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvPrimerApellido" runat="server" ControlToValidate="txtPrimerApellido"
                ErrorMessage="El primer apellido es requerido" ValidationGroup="GuardarEstudiante">*</asp:RequiredFieldValidator>
        </td>
    </tr>
        <tr>
        <td>
            Segundo Apellido:
        </td>
        <td colspan="1">
            <asp:TextBox ID="txtSegundoApellido" Width="493px" runat="server"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td>
            Correo Electronico<br />
            :
        </td>
        <td colspan="1">
            <asp:TextBox ID="txtCorreoElectronico" runat="server" Width="493px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCorreoElectronico" runat="server" ControlToValidate="txtCorreoElectronico"
                ErrorMessage="El correo es requerido" ValidationGroup="GuardarEstudiante">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revCorreo" 
                ErrorMessage="Correo electrónico inválido" 
                ControlToValidate="txtCorreoElectronico" Runat="server" 
                ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ValidationGroup="GuardarEstudiante">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td colspan="2">
        </td>
    </tr>
     <tr>
        <td colspan="2">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true"
                ValidationGroup="GuardarEstudiante" CssClass="validation" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button runat="server" ID="btnGuardar" Text="Guardar"  CssClass="boton75" CausesValidation="true"
            ValidationGroup="GuardarEstudiante" OnClick="btnGuardar_Click"/>
                <asp:Button runat="server" ID="btnRegresar" Text="Limpiar"  
                CssClass="boton75" OnClick="btnRegresar_Click"/>
    </tr>
   
    <tr>
        <td colspan="2">
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
   
    <tr>
        <td colspan="2">
            &nbsp;</td>
    </tr>
   
    <tr>
        <td colspan="2">
            <asp:GridView ID="gvEstudiante"
            runat="server" AutoGenerateColumns="False" 
            EnableModelValidation="True" OnRowCommand="gvEstudiante_RowCommand"
                DataKeyNames="Id" EmptyDataText="No hay registros" Width="97%">
                <Columns>
                    <asp:TemplateField HeaderText="Tipo Documento">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("TipoDocumento.Nombre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                    <asp:BoundField HeaderText="Documento" DataField="NumeroDocumento">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Primer Nombre" DataField="PrimerNombre">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Segundo Nombre" DataField="SegundoNombre">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                                        <asp:BoundField HeaderText="Primer Apellido" DataField="PrimerApellido">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                                        <asp:BoundField HeaderText="Segundo Apellido" DataField="SegundoApellido">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                                                            <asp:BoundField HeaderText="Correo" DataField="CorreoElectronico">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <a runat="server" id="lnkEditarM" title='Editar'>
                                <asp:ImageButton ID="imgEditar" runat="server" CommandName="EditarEstudiante" 
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
<asp:HiddenField ID="hfIdEstudiante" runat="server" />
