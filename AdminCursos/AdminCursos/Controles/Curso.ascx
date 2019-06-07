<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Curso.ascx.cs" Inherits="AdminCursos.Controles.Curso" %>

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

         $("#<%=txtFechaInicio.ClientID %>").datepicker({
             showOn: "button",
             buttonImage: "../../Imagenes/calendario.png",
             buttonImageOnly: true,
             buttonText: "Seleccione la fecha de inicio",
             changeMonth: true,
             changeYear: true
         }); 

         $("#<%=txtFechaFin.ClientID %>").datepicker({
             showOn: "button",
             buttonImage: "../../Imagenes/calendario.png",
             buttonImageOnly: true,
             buttonText: "Seleccione la fecha de inicio",
             changeMonth: true,
             changeYear: true
         });

         $("#<%=txtFechaLimite.ClientID %>").datepicker({
             showOn: "button",
             buttonImage: "../../Imagenes/calendario.png",
             buttonImageOnly: true,
             buttonText: "Seleccione la fecha limite",
             changeMonth: true,
             changeYear: true
         });

         // $("#<%=txtFechaInicio.ClientID %>").datepicker();
     });
</script>
<div class="contenedor">
<div class="tituloEncabezadoAzul">CURSOS</div>
<table style="width: 98%;" class="filtroBusqueda">
      <tr>
        <td>
           Nombre Curso:
        </td>
        <td colspan="1">
            <asp:TextBox ID="txtNombreCurso" runat="server" Width="493px" 
            TextMode="MultiLine" Height="57px" MaxLength="500"
            CssClass="cajaTexto"
            onKeyUp="return TextBoxMultilineMaximalongitud(this,500)"
            onkeypress="return soloValoresValidos(event)"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombreCurso" runat="server" 
            ControlToValidate="txtNombreCurso"
                ErrorMessage="El nombre del Curso es requerido" ValidationGroup="GuardarCurso">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revNombreCurso" 
                ErrorMessage="El nombre del curso debe contener caracteres alfanuméricos" 
                ControlToValidate="txtNombreCurso" Runat="server" 
                ValidationExpression="[A-Za-z0-9ÑñÁáÉéÍíÓóÚúÄäËëÏïÖöÜü´ ]+" ValidationGroup="GuardarCurso">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td>
            Modalidad:
        </td>
        <td colspan="1">
            <asp:DropDownList ID="ddlModalidad" runat="server" Height="18px" Width="238px">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvModalidad" runat="server" 
            ControlToValidate="ddlModalidad" 
            ErrorMessage="La modalidad es requerida"
            InitialValue="-1" ValidationGroup="GuardarCurso">*</asp:RequiredFieldValidator>
        </td>
    </tr>
      <tr>
        <td>
            Descripcion del Curso:
        </td>
        <td colspan="1">
            <asp:TextBox ID="txtDescripcionCurso" runat="server" Width="493px" TextMode="MultiLine" Height="57px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDescripcionCurso" runat="server" ControlToValidate="txtDescripcionCurso"
                ErrorMessage="La Descripción del Curso es requerida" ValidationGroup="GuardarCurso">*</asp:RequiredFieldValidator>
        </td>
    </tr>
     <tr>
        <td>
           Fecha Inicio:
        </td>
        <td colspan="1">
            <asp:TextBox ID="txtFechaInicio" Width="110px" runat="server" MaxLength="10"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvFechaInicio" runat="server" ControlToValidate="txtFechaInicio"
                ErrorMessage="La Fecha de Inicio es requerida" ValidationGroup="GuardarCurso">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
           Fecha Fin:
        </td>
        <td colspan="1">
            <asp:TextBox ID="txtFechaFin" Width="110px" runat="server" MaxLength="10"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvFechaFin" runat="server" ControlToValidate="txtFechaFin"
                ErrorMessage="La Fecha de Fin es requerida" ValidationGroup="GuardarCurso">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvFechaFin" runat="server" ErrorMessage="La fecha de fin no puede ser menor o igual a la fecha de inicio"
             ControlToValidate="txtFechaFin" ControlToCompare="txtFechaInicio" Type="Date" Operator="GreaterThanEqual"
               ValidationGroup="GuardarCurso">*</asp:CompareValidator>
        </td>
    </tr>
        <tr>
        <td>
           Fecha Límite Inscripcion:
        </td>
        <td colspan="1">
            <asp:TextBox ID="txtFechaLimite" Width="110px" runat="server" MaxLength="10"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvFechaLimite" runat="server" ControlToValidate="txtFechaLimite"
                ErrorMessage="La Fecha límite es requerida" ValidationGroup="GuardarCurso">*</asp:RequiredFieldValidator>
        </td>
    </tr>
     <tr>
        <td>
          No de horas certificadas del curso:
        </td>
        <td colspan="1">
            <asp:TextBox ID="txtHoras" runat="server" Width="231px" 
                MaxLength="4"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvHoras" runat="server" ControlToValidate="txtHoras"
                ErrorMessage="La intensidad horaria es requerida" ValidationGroup="GuardarCurso">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revHoras" 
                ErrorMessage="La intensidad horaria debe contener sólo números" 
                ControlToValidate="txtHoras" Runat="server" 
                ValidationExpression="\d+" ValidationGroup="GuardarCurso">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
          Total cupos:
        </td>
        <td colspan="1" class="auto-style1">
            <asp:TextBox ID="txtCupos" runat="server" Width="231px" 
                MaxLength="4"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCupos" runat="server" ControlToValidate="txtCupos"
                ErrorMessage="El número de cupos es requerido" ValidationGroup="GuardarCurso">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revCupos" 
                ErrorMessage="El número de cupos debe contener sólo números" 
                ControlToValidate="txtCupos" Runat="server" 
                ValidationExpression="\d+" ValidationGroup="GuardarCurso">*</asp:RegularExpressionValidator>
        </td>
    </tr>   
     <tr>
        <td>
            Cerrado:
        </td>
        <td colspan="1">
            <asp:CheckBox ID="chkCerrado" runat="server" />
        </td>
    </tr>   
    <tr>
        <td colspan="2">
        </td>
    </tr>
     <tr>
        <td colspan="2">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true"
                ValidationGroup="GuardarCurso" CssClass="validation" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button runat="server" ID="btnGuardar" Text="Guardar"  CssClass="boton75" CausesValidation="true"
            ValidationGroup="GuardarCurso" OnClick="btnGuardar_Click"/>
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
            <asp:GridView ID="gvCurso"
            runat="server" AutoGenerateColumns="False" 
            EnableModelValidation="True" OnRowCommand="gvCurso_RowCommand"
                DataKeyNames="Id" EmptyDataText="No hay registros" Width="97%">
                <Columns>
                    <asp:BoundField HeaderText="Nombre Curso" DataField="nombre">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                          <asp:BoundField HeaderText="Descripcion Curso" DataField="descripcion">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Modalidad">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Modalidad.Nombre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                    <asp:BoundField HeaderText="Fecha Inicio" DataField="FechaInicio"
                DataFormatString="{0:dd-MM-yyyy}">
                <HeaderStyle Width="80px" />
            </asp:BoundField>
                    <asp:BoundField HeaderText="Fecha Fin" DataField="FechaFin"
                DataFormatString="{0:dd-MM-yyyy}">
                <HeaderStyle Width="80px" />
            </asp:BoundField>
                    <asp:BoundField HeaderText="Horas" DataField="horas">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <a runat="server" id="lnkEditarM" title='Editar'>
                                <asp:ImageButton ID="imgEditar" runat="server" CommandName="EditarCurso" 
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
<asp:HiddenField ID="hfIdCurso" runat="server" />
<asp:HiddenField ID="hfEliminado" runat="server" />
