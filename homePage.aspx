<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="homePage.aspx.cs" Inherits="homePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div class="col-xs-12 text-center" style= "position:absolute; width:100%; display:flex; justify-content:center; align-items:center">
         <img src="Imagem/Logo-Uniguaçu-PNG.png" style="width: 20%;" alt="Responsive image">
    </div>
   
    <div class=" " style="position:absolute; height:90%; width:95%; display:flex; justify-content:center; align-items:center">
        <asp:LinkButton runat="server" ID="CadUsuario" CssClass="btn btn-lg btn-default" Style="width:25%">
          <span class="glyphicon glyphicon-user"></span> Login
        </asp:LinkButton>
        <asp:LinkButton runat="server" ID="ConsultaItem" CssClass="btn btn-lg btn-default" Style="width:25%">
            <span class="glyphicon glyphicon-search"></span> Consultar Item 
        </asp:LinkButton>
        <asp:LinkButton runat="server" ID="CadastrarChamado" CssClass="btn btn-lg btn-default" Style="width:25%">
            <span class="glyphicon glyphicon-plus-sign"></span> Cadastrar chamado
        </asp:LinkButton>
    </div>

</asp:Content>

