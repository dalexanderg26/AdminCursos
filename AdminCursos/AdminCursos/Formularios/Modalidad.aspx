<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modalidad.aspx.cs" 
    MasterPageFile="~/Site.Master"
    Inherits="AdminCursos.Formularios.Modalidad" %>
<%@ Register Src="~/Controles/Modalidad.ascx" TagPrefix="uc1" TagName="UCM" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:UCM runat="server" ID="UCModalidad"></uc1:UCM>
</asp:Content>

