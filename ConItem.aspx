<%@ Page Title="Itens" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConItem.aspx.cs" Inherits="ConItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <ul class="list-group">
        <li class="list-group-item active">
            <div class="row">
                <div class="col-md-12">
                    <div class="input-group">
                        <input type="text" class="form-control" placeholder="Procurando por...">
                        <span class="input-group-btn">
                            <button class="btn btn-default" type="button">Pesquisar</button>
                            <asp:LinkButton runat="server" ID="lbtCadastrar" CssClass="btn btn-success" OnClick="lbtCadastrar_Click">
                                <span class="glyphicon glyphicon-plus"></span>
                            </asp:LinkButton>
                        </span>
                    </div>
                </div>
            </div>
        </li>
    </ul>

    <div class="row">
        <asp:Repeater runat="server" ID="Item">
            <ItemTemplate>
                <div class="col-xs-12 col-md-2">
                    <div class="thumbnail">
                        <img src="..." alt="...">
                        <div class="caption">
                            <h5>Nome item</h5>
                            <asp:LinkButton runat="server" ID="btnReinvidicar" CssClass="btn btn-default btn-xs">
                                <span class="glyphicon glyphicon-hand-up"></span>
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnDetalhar" CssClass="btn btn-default btn-xs">
                                <span class="glyphicon glyphicon-align-justify"></span>
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnEntrega" CssClass="btn btn-default btn-xs">
                                <span class="glyphicon glyphicon-check"></span>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:UpdatePanel runat="server" ID="upCadastro" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="modal fade" tabindex="-1" role="dialog" id="modalCadastro">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">Cadastrar Novo Item</div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-xs-12">
                                    <label>Nome do Item</label>
                                    <asp:TextBox runat="server" ID="tbNomeItem" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                </div>
                                <div class="col-xs-12">
                                    <label>Descrição do Item</label>
                                    <asp:TextBox runat="server" ID="tbDescricaoItem" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="col-xs-12">
                                    <label>Data em que foi encontrado</label>
                                    <asp:TextBox runat="server" ID="tbDataEncontrado" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="col-xs-12">
                                    <label>Local em que foi encontrado</label>
                                    <asp:TextBox runat="server" ID="tbLocalEncontrado" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <label for="exampleInputFile">Escolher imagem do item</label>
                                        <asp:FileUpload runat="server" ID="fuImagem" />
                                        <p class="help-block">Selecione a imagem do item.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton runat="server" ID="lbtCadastrarOk" CssClass="btn btn-success" OnClick="lbtCadastrarOk_Click">
                                <span class="glyphicon glyphicon-ok"></span>
                                Concluir
                            </asp:LinkButton>
                            <button class="btn btn-danger" data-dismiss="modal">
                                <span class="glyphicon glyphicon-remove"></span>
                                Fechar
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lbtCadastrar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
     <!-- PopUp confirmação de reivindicação -->
        <asp:UpdatePanel runat="server" ID="upReivindicar" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="modal fade" tabindex="-1" role="dialog" id="modalReivindicar">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title">Item</h4>
                        </div>
                        <div class="modal-body">
                            <p>Deseja reivindicar esse item?</p>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton runat="server" ID="btnReinvidicar" CssClass="btn btn-success">
                                        <span class="glyphicon glyphicon-ok"></span> Salvar
                            </asp:LinkButton>
                            <button id="btnCancelarReivindicacao" class="btn btn-danger" data-dismiss="modal">
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

</asp:Content>

