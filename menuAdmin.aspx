<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="menuAdmin.aspx.cs" Inherits="menuAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class=" " style="position:absolute; height:90%; width:95%; display:flex; justify-content:center; align-items:center">
        <asp:LinkButton runat="server" ID="CadUsuario" CssClass="btn btn-lg btn-default" Style="width:10%" OnClick="CadUsuario_Click">
          <span class="glyphicon glyphicon-user"></span> Usuario
        </asp:LinkButton>
        <asp:LinkButton runat="server" ID="CadItem" CssClass="btn btn-lg btn-default" Style="width:10%">
            <span class="glyphicon glyphicon-tasks"></span> Item 
        </asp:LinkButton>
        <asp:LinkButton runat="server" ID="CadChamado" CssClass="btn btn-lg btn-default" Style="width:10%">
            <span class="glyphicon glyphicon-bullhorn"></span> Chamado
        </asp:LinkButton>
    </div>
    
    
    
  
</asp:Content>

