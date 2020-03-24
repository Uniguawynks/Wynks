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
                            <asp:LinkButton runat="server" ID="btnEditar" CssClass="btn btn-default btn-xs">
                  <span class="glyphicon glyphicon-pencil"></span>
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnExcluir" CssClass="btn btn-default btn-xs">
                    <span class="glyphicon glyphicon-trash"></span>
                            </asp:LinkButton>
                        </div>
                    </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Usuário</h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:TextBox runat="server" ID="tbUsuario" CssClass="form-control"></asp:TextBox>
                        <asp:TextBox runat="server" ID="tbSenha" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" ID="btnSalvar" CssClass="btn btn-success">
                            <span class="glyphicon glyphicon-ok"></span> Salvar
                    </asp:LinkButton>
                    <asp:LinkButton runat="server" ID="btnCancelar" CssClass="btn btn-danger">
                            <span class="glyphicon glyphicon-remove"></span> Cancelar
                    </asp:LinkButton>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
</asp:Content>

