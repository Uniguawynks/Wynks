<%@ Page Title="Cadastrar Chamado" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadChamado.aspx.cs" Inherits="CadChamado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="/*width: 100%; height: 100%; position: absolute; float: left; background-color: #ffffff*/">
        <div style="display: flex; align-items: center; justify-content: center; height: 100%">
            <div class="row" style="width: 100%">
                <div class="col-md-3"></div>
                <div class="col-md-6">
                    <div class="panel panel-info" style="width: 100%">
                        <div class="panel-heading">Cadastro de chamado</div>
                        <div class="panel-body">
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label class="label" title="Informe o seu nome para o cadastro do chamado" style="color: black">
                                            Nome
                                        </label>
                                        <asp:TextBox runat="server" ID="tbNomeAluno" CssClass="form-control" placeholder="Digite seu nome aqui"></asp:TextBox>
                                        <label class="label" title="Informe o seu CPF">
                                            CPF
                                        </label>
                                        <asp:TextBox runat="server" ID="tbCPF" CssClass="form-control" placeholder="Digite seu CPF" MaxLength="14" onkeyup="MascaraCpf(this, event);"></asp:TextBox>
                                        <label class="label" title="Informe o seu RG">
                                            RG
                                        </label>
                                        <asp:TextBox runat="server" ID="tbRG" CssClass="form-control" placeholder="Digite seu RG"></asp:TextBox>
                                        <label class="label" title="Dê um breve nome ao seu item para que ele seja identificado com facilidade">
                                            Nome do Item
                                        </label>
                                        <asp:TextBox runat="server" ID="tbNomeItem" CssClass="form-control" placeholder="Digite um nome curto para seu item, para identificá-lo com facilidade"></asp:TextBox>
                                        <label class="label" title="Informe a descrição do item perdido, caso haja foto informe algo específico sobre o item" style="color: black">
                                            Descrição
                                        </label>
                                        <asp:TextBox runat="server" ID="tbDescricao" CssClass="form-control" TextMode="MultiLine" Rows="7" placeholder="Descreva o objeto perdido"></asp:TextBox>
                                        <label class="label" style="color: black">
                                            Data
                                        </label>
                                        <asp:TextBox runat="server" ID="tbData" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        <label class="label" title="Informe o local que foi perdido o item" style="color: black">
                                            Local
                                        </label>
                                        <asp:TextBox runat="server" ID="tbLocal" CssClass="form-control" placeholder="Digite o local"></asp:TextBox>
                                        <label class="label" title="Informe o seu telefone para que seja possível entrar em contato  " style="color: black" >
                                            Telefone
                                        </label>
                                        <asp:TextBox runat="server" ID="tbTelefone" CssClass="form-control" placeholder="Digite seu número de telefone"></asp:TextBox>
                                        <label class="label" title="Informe o seu e-mail para que seja possível entrar em contato" >
                                            E-mail
                                        </label>
                                        <asp:TextBox runat="server" ID="tbEmail" CssClass="form-control" placeholder="Digite seu e-mail"></asp:TextBox>
                                        <br />
                                        <div class="form-group">
                                            <label for="exampleInputFile">Escolher imagem do item</label>
                                            <asp:FileUpload runat="server" ID="fuImagem" />
                                            <p class="help-block">Selecione a imagem do item perdido.</p>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12 text-center">
                                        <asp:UpdatePanel runat="server" ID="upBotoes" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:LinkButton runat="server" ID="btnEnviar" CssClass="btn btn-success" OnClick="btnEnviar_Click">
                                                    <span class="glyphicon glyphicon-ok"></span> Enviar
                                                </asp:LinkButton>
                                                <asp:LinkButton runat="server" ID="btnCancelar" CssClass="btn btn-danger">
                                                     <span class="glyphicon glyphicon-remove"></span> Cancelar
                                                </asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3"></div>
            </div>
        </div>

    </div>
</asp:Content>

