<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TipoDocumento.aspx.cs" MasterPageFile="~/Site.Master"
    Inherits="AdminCursos.Formularios.TipoDocumento" %>

<%@ Register Src="~/Controles/TipoDocumento.ascx" TagPrefix="uc1" TagName="UCTD" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:UCTD runat="server" ID="UCTipoDocumento"></uc1:UCTD>
</asp:Content>
