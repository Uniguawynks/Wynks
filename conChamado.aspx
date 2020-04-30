<%@ Page Title="Chamados" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="conChamado.aspx.cs" Inherits="conChamado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function Detalhar(codigo) {
            var hf = $('#ContentPlaceHolder1_hfDetalhar');

            hf.val(codigo);
            __doPostBack(hf.attr('name'), '');

            return false;
        }
        function Atender(codigo) {
            var hf = $('#ContentPlaceHolder1_hfAtender');

            hf.val(codigo);
            __doPostBack(hf.attr('name'), '');

            return false;
        }
    </script>
    <ul class="list-group">
        <li class="list-group-item active">
            <div class="row">
                <div class="col-md-12">
                    <div class="input-group">
                        <asp:TextBox runat="server" ID="tbBusca" CssClass="form-control" placeholder="Digite aqui a sua busca..."></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:LinkButton runat="server" ID="lbtBuscar" CssClass="btn btn-default" OnClick="lbtBuscar_Click">
                                <span class="glyphicon glyphicon-search"></span>
                            </asp:LinkButton>
                        </span>
                    </div>
                </div>
            </div>
        </li>
    </ul>

    <div class="row">
        <asp:UpdatePanel runat="server" ID="upChamados" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Repeater runat="server" ID="rptChamado" OnItemDataBound="rptChamado_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-xs-12 col-md-2">
                            <div class="thumbnail">
                                <asp:Image runat="server" ID="imgChamado" CssClass="img-responsive" Height="150px" />
                                <div class="caption">
                                    <h5 runat="server" id="h5Nome"><%# Eval("NomeItem") %></h5>
                                    <asp:LinkButton runat="server" ID="lbtAtender" CssClass="btn btn-default btn-xs" ToolTip="Atender">
                                        <span class="glyphicon glyphicon-hand-up"></span>
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lbtDetalhar" CssClass="btn btn-default btn-xs">
                                        <span class="glyphicon glyphicon-align-justify"></span>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lbtBuscar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div class="modal fade" role="dialog" tabindex="-1" id="modalDetalhar">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">Detalhes do chamado</div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="upCadastro" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-12">
                                    <label class="label" title="Informe o seu nome para o cadastro do chamado" style="color: black">
                                        Nome
                                    </label>
                                    <asp:TextBox runat="server" ID="tbNomeAluno" CssClass="form-control" Enabled="false" placeholder="Digite seu nome aqui"></asp:TextBox>
                                    <label class="label" title="Informe o seu CPF">
                                        CPF
                                    </label>
                                    <asp:TextBox runat="server" ID="tbCPF" CssClass="form-control" Enabled="false" placeholder="Digite seu CPF" MaxLength="14" onkeyup="MascaraCpf(this, event);"></asp:TextBox>
                                    <label class="label" title="Informe o seu RG">
                                        RG
                                    </label>
                                    <asp:TextBox runat="server" ID="tbRG" CssClass="form-control" Enabled="false" placeholder="Digite seu RG"></asp:TextBox>
                                    <label class="label" title="Dê um breve nome ao seu item para que ele seja identificado com facilidade">
                                        Nome do Item
                                    </label>
                                    <asp:TextBox runat="server" ID="tbNomeItem" CssClass="form-control" Enabled="false" placeholder="Digite um nome curto para seu item, para identificá-lo com facilidade"></asp:TextBox>
                                    <label class="label" title="Informe a descrição do item perdido, caso haja foto informe algo específico sobre o item" style="color: black">
                                        Descrição
                                    </label>
                                    <asp:TextBox runat="server" ID="tbDescricao" CssClass="form-control" Enabled="false" TextMode="MultiLine" Rows="7" placeholder="Descreva o objeto perdido"></asp:TextBox>
                                    <label class="label" style="color: black">
                                        Data
                                    </label>
                                    <asp:TextBox runat="server" ID="tbData" CssClass="form-control" TextMode="Date" Enabled="false"></asp:TextBox>
                                    <label class="label" title="Informe o local que foi perdido o item" style="color: black">
                                        Local
                                    </label>
                                    <asp:TextBox runat="server" ID="tbLocal" CssClass="form-control" placeholder="Digite o local" Enabled="false"></asp:TextBox>
                                    <label class="label" title="Informe o seu telefone para que seja possível entrar em contato  " style="color: black">
                                        Telefone
                                    </label>
                                    <asp:TextBox runat="server" ID="tbTelefone" CssClass="form-control" placeholder="Digite seu número de telefone" Enabled="false"></asp:TextBox>
                                    <label class="label" title="Informe o seu e-mail para que seja possível entrar em contato">
                                        E-mail
                                    </label>
                                    <asp:TextBox runat="server" ID="tbEmail" CssClass="form-control" placeholder="Digite seu e-mail" Enabled="false"></asp:TextBox>
                                    <br />
                                    <label runat="server" id="lbAtendidoPor" class="label" title="Informe o seu e-mail para que seja possível entrar em contato">
                                        Usuário atendimento
                                    </label>
                                    <asp:TextBox runat="server" ID="tbAtendidoPor" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    <br />
                                    <label runat="server" id="lbDataAtendimento" class="label">
                                        Data atendimento
                                    </label>
                                    <asp:TextBox runat="server" ID="tbDataAtendimento" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="hfDetalhar" EventName="ValueChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-danger" data-dismiss="modal">
                        <span class="glyphicon glyphicon-remove"></span>
                        Fechar
                    </button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" role="dialog" tabindex="-1" id="modalAtender">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">Atender Chamado</div>
                <div class="modal-body">
                    Tem certeza que deseja atender este chamado ?
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" ID="lbtAtenderOk" CssClass="btn btn-success" OnClick="lbtAtenderOk_Click">
                        <span class="glyphicon glyphicon-ok"></span>
                        Sim
                    </asp:LinkButton>
                    <button class="btn btn-danger" data-dismiss="modal">
                        <span class="glyphicon glyphicon-remove"></span>
                        Não
                    </button>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel runat="server" ID="upHiddenFields" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField runat="server" ID="hfDetalhar" Value="0" OnValueChanged="hfDetalhar_ValueChanged" />
            <asp:HiddenField runat="server" ID="hfAtender" Value="0" OnValueChanged="hfAtender_ValueChanged" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

