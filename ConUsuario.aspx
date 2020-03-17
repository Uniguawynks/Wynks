<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConUsuario.aspx.cs" Inherits="ConUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="list-group">
        <li class="list-group-item active">
            <div class="row">
                <div class="col-md-2">Codigo</div>
                <div class="col-md-7">Nome</div>
                <div class="col-md-3 text-right">
                    <asp:LinkButton runat="server" ID="add" CssClass="btn btn-default btn-xs">
                  <span class="glyphicon glyphicon-plus"></span>
                    </asp:LinkButton>
                </div>
            </div>
        </li>
        <asp:Repeater runat="server" ID="usuarios">
            <ItemTemplate>
                <li class="list-group-item">
                    <div class="row">
                        <div class="col-md-2">Codigo</div>
                        <div class="col-md-7">
                            <%# Container.DataItem %>
                        </div>
                        <div class="col-md-3 text-right">
                            <asp:LinkButton runat="server" ID="editar" CssClass="btn btn-default btn-xs">
                  <span class="glyphicon glyphicon-pencil"></span>
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" ID="excluir" CssClass="btn btn-default btn-xs">
                    <span class="glyphicon glyphicon-trash"></span>
                            </asp:LinkButton>
                        </div>
                    </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</asp:Content>

