<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Inscripcion.ascx.cs" Inherits="AdminCursos.Controles.Inscripcion" %>
<link rel="stylesheet" href="../Content/jquery-ui.css" />

<script type="text/javascript">
     $(function () {
         $.datepicker.regional['es'] =
  {
      closeText: 'Cerrar',
      prevText: 'Previo',
      nextText: 'Próximo',
      monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
      'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
      monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
      'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
      monthStatus: 'Ver otro mes', 
      yearStatus: 'Ver otro año',
      dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
      dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sáb'],
      dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
      dateFormat: 'dd/mm/yy', 
      firstDay: 0,
      initStatus: 'Selecciona la fecha', 
      isRTL: false
  }; 
         $.datepicker.setDefaults($.datepicker.regional['es']);

         $("#<%=txtFechaInscripcion.ClientID %>").datepicker({
             showOn: "button",
             buttonImage: "../../Imagenes/calendario.png",
             buttonImageOnly: true,
             buttonText: "Seleccione la fecha de inicio",
             changeMonth: true,
             changeYear: true
         }); 
     });
</script>
<div class="contenedor">
<div class="tituloEncabezadoAzul">INSCRIPCION</div>
<table style="width: 98%;" class="filtroBusqueda">
      <tr>
        <td>
            Curso:
        </td>
        <td colspan="1">
            <asp:DropDownList ID="ddlCurso" runat="server" Width="493px">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvCurso" runat="server" 
            ControlToValidate="ddlCurso" 
            ErrorMessage="El Curso es requerido"
            InitialValue="-1" ValidationGroup="GuardarInscripcion">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Estudiante:
        </td>
        <td colspan="1">
            <asp:DropDownList ID="ddlEstudiante" runat="server" Height="18px" Width="493px">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvEstudiante" runat="server" 
            ControlToValidate="ddlEstudiante" 
            ErrorMessage="El estudiante es requerido"
            InitialValue="-1" ValidationGroup="GuardarInscripcion">*</asp:RequiredFieldValidator>
        </td>
    </tr>
     <tr>
        <td>
            Fecha Inscripción: </td>
        <td colspan="1">
            <asp:TextBox ID="txtFechaInscripcion" Width="110px" runat="server" MaxLength="10"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvFechaInscripcion" runat="server" ControlToValidate="txtFechaInscripcion"
                ErrorMessage="La Fecha de inscripción es requerida" ValidationGroup="GuardarInscripcion">*</asp:RequiredFieldValidator>
        </td>
    </tr>
     <tr>
        <td>
          Nota:
        </td>
        <td colspan="1">
            <asp:TextBox ID="txtNota" runat="server" Width="231px" 
                MaxLength="4"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revNota" 
                ErrorMessage="Las horas deben contener sólo números" 
                ControlToValidate="txtNota" Runat="server" 
                ValidationExpression="\d+" ValidationGroup="GuardarInscripcion">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td colspan="2">
        </td>
    </tr>
     <tr>
        <td colspan="2">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true"
                ValidationGroup="GuardarInscripcion" CssClass="validation" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button runat="server" ID="btnGuardar" Text="Guardar"  CssClass="boton75" CausesValidation="true"
            ValidationGroup="GuardarInscripcion" OnClick="btnGuardar_Click"/>
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
            <asp:GridView ID="gvInscripcion"
            runat="server" AutoGenerateColumns="False" 
            EnableModelValidation="True" OnRowCommand="gvInscripcion_RowCommand"
                DataKeyNames="Id" EmptyDataText="No hay registros" Width="97%">
                <Columns>
                    <asp:TemplateField HeaderText="Curso">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Curso.Nombre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                          <asp:TemplateField HeaderText="Documento">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Estudiante.NumeroDocumento") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="Primer Apellido">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Estudiante.PrimerApellido") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="Segundo Apellido">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Estudiante.SegundoApellido") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                     <asp:TemplateField HeaderText="Primer Nombre">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Estudiante.PrimerNombre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                    <asp:TemplateField HeaderText="Segundo Nombre">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Estudiante.SegundoNombre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                    <asp:BoundField HeaderText="Fecha Inscripcion" DataField="FechaInscripcion"
                DataFormatString="{0:dd-MM-yyyy}">
                <HeaderStyle Width="80px" />
            </asp:BoundField>
                     <asp:BoundField HeaderText="Nota" DataField="NotaFinal">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <a runat="server" id="lnkEditarM" title='Editar'>
                                <asp:ImageButton ID="imgEditar" runat="server" CommandName="EditarInscripcion" 
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
<asp:HiddenField ID="hfIdInscripcion" runat="server" />


