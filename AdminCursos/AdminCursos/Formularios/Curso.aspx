<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Curso.aspx.cs" Inherits="AdminCursos.Formularios.Curso"
    MasterPageFile="~/Site.Master"
    %>
<%@ Register Src="~/Controles/Curso.ascx" TagPrefix="uc1" TagName="UCCurso" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:UCCurso runat="server" ID="UCCursos"></uc1:UCCurso>
</asp:Content>