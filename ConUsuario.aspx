<%@ Page Title="Usuário" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConUsuario.aspx.cs" Inherits="ConUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function EditarUsuario(id) {
            var hf = $('#ContentPlaceHolder1_hfEditarUsuario');

            hf.val(id);
            __doPostBack(hf.attr('name'), '');

            return false;
        }
    </script>
    <asp:UpdatePanel runat="server" ID="upUsuarios" UpdateMode="Conditional">
        <ContentTemplate>
            <ul class="list-group">
                <li class="list-group-item active">
                    <div class="row">
                        <div class="col-md-2">Codigo</div>
                        <div class="col-md-3">Nome</div>
                        <div class="col-md-4">E-mail</div>
                        <div class="col-md-3 text-right">
                            <asp:UpdatePanel runat="server" ID="upAbrirModalCadastro" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:LinkButton runat="server" ID="lbtAdd" CssClass="btn btn-default btn-xs" OnClick="lbtAdd_Click">
                                <span class="glyphicon glyphicon-plus"></span>
                                    </asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </li>
                <asp:Repeater runat="server" ID="rptUsuarios" OnItemDataBound="rptUsuarios_ItemDataBound">
                    <ItemTemplate>
                        <li class="list-group-item" runat="server" id="liUsuario">
                            <div class="row">
                                <div class="col-md-2"><%# Eval("Codigo") %></div>
                                <div class="col-md-3">
                                    <%# Eval("Nome") %>
                                </div>
                                <div class="col-md-4"><%# Eval("Email") %></div>
                                <div class="col-md-3 text-right">
                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:LinkButton runat="server" ID="btnEditar" CssClass="btn btn-default btn-xs">
                                        <span class="glyphicon glyphicon-pencil"></span>
                                            </asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="btnExcluir" CssClass="btn btn-default btn-xs" CommandArgument='<%# Eval("Codigo") %>' OnClick="btnExcluir_Click">
                                                <span class="glyphicon glyphicon-trash"></span>
                                            </asp:LinkButton>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSalvarExclusao" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSalvar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server" ID="upModalCadastro" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="modal fade" tabindex="-1" role="dialog" id="modalCadastroUsuario">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title">Usuário</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12">
                                        <label>CPF</label>
                                        <asp:TextBox runat="server" ID="tbCPF" CssClass="form-control" MaxLength="14" onkeyup="MascaraCpf(this, event);"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12">
                                        <label>Nome</label>
                                        <asp:TextBox runat="server" ID="tbUsuario" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12">
                                        <label>E-mail</label>
                                        <asp:TextBox runat="server" ID="tbEmail" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12">
                                        <label>Data de Nascimento</label>
                                        <asp:TextBox runat="server" ID="tbDataNascimento" CssClass="form-control" MaxLength="10" onkeyup="MascaraData(this, event)"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12">
                                        <label>Função</label>
                                        <asp:DropDownList runat="server" ID="ddlFuncao" CssClass="form-control">
                                            <asp:ListItem Value="Administrador"></asp:ListItem>
                                            <asp:ListItem Value="Master"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-12" runat="server" id="divSenha">
                                        <label>Senha</label>
                                        <asp:TextBox runat="server" ID="tbSenha" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12" runat="server" id="divConfirmarSenha">
                                        <label>Confirmar Senha</label>
                                        <asp:TextBox runat="server" ID="tbConfirmarSenha" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">

                            <asp:LinkButton runat="server" ID="btnSalvar" CssClass="btn btn-success" OnClick="btnSalvar_Click">
                                <span class="glyphicon glyphicon-ok"></span> Salvar
                            </asp:LinkButton>
                            <button id="btnCancelar" class="btn btn-danger" data-dismiss="modal">
                                <span class="glyphicon glyphicon-remove"></span>Cancelar
                            </button>

                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lbtAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="hfEditarUsuario" EventName="ValueChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <!-- /.modal -->

    <!-- pop up exclusão de usuário -->
    <asp:UpdatePanel runat="server" ID="upExclusao" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="modal fade" tabindex="-1" role="dialog" id="modalExclusao">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title">Excluir usuário</h4>
                        </div>
                        <div class="modal-body">
                            <p>Deseja excluir o usuário selecionado?</p>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton runat="server" ID="btnSalvarExclusao" CssClass="btn btn-success" OnClick="btnSalvarExclusao_Click">
                                        <span class="glyphicon glyphicon-ok"></span> Salvar
                            </asp:LinkButton>
                            <button id="btnCancelarExclusao" class="btn btn-danger" data-dismiss="modal">
                                <span class="glyphicon glyphicon-remove"></span>Cancelar
                            </button>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
        </ContentTemplate>

    </asp:UpdatePanel>
    <!-- /.modal -->

    <asp:UpdatePanel runat="server" ID="upHiddenFields" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField runat="server" ID="hfEditarUsuario" Value="0" OnValueChanged="hfEditarUsuario_ValueChanged" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

