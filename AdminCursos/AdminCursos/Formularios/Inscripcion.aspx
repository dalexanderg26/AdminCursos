<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscripcion.aspx.cs" MasterPageFile="~/Site.Master" Inherits="AdminCursos.Formularios.Inscripcion" %>
<%@ Register Src="~/Controles/Inscripcion.ascx" TagPrefix="uc1" TagName="UCInscripcion" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<uc1:UCInscripcion runat="server" ID="UCInscripciones"></uc1:UCInscripcion>
</asp:Content>

