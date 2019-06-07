<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Estudiante.aspx.cs" 
    MasterPageFile="~/Site.Master"
    Inherits="AdminCursos.Formularios.Estudiante" %>
<%@ Register Src="~/Controles/Estudiante.ascx" TagPrefix="uc1" TagName="UCEstudiante" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<uc1:UCEstudiante runat="server" ID="UCEstudiantes"></uc1:UCEstudiante>
</asp:Content>
