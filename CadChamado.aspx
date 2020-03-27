<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadChamado.aspx.cs" Inherits="CadChamado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 100%; height: 100%; position: absolute; float: left; background-color: #ffffff">
        <div style="display: flex; align-items: center; justify-content: center; height: 100%">
            <div class="row" style="width: 100%">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <div class="panel panel-info" style="width: 100%">
                        <div class="panel-heading">Login</div>
                        <div class="panel-body">
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label class="label" style="color: black">
                                            Nome
                                        </label>
                                        <asp:TextBox runat="server" ID="tbNome" CssClass="form-control" placeholder="Digite seu nome aqui"></asp:TextBox>
                                        <label class="label" style="color: black">
                                            Telefone
                                        </label>
                                        <asp:TextBox runat="server" ID="tbTelefone" CssClass="form-control" placeholder="Digite seu número de telefone"></asp:TextBox>
                                        <label class="label" style="color: black">
                                            Descrição
                                        </label>
                                        <asp:TextBox runat="server" ID="tbDescricao" CssClass="form-control" placeholder="Descreva o objeto perdido"></asp:TextBox>
                                        <label class="label" style="color: black">
                                            Local
                                        </label>
                                        <asp:TextBox runat="server" ID="tbLocal" CssClass="form-control" placeholder="Digite o local"></asp:TextBox>
                                        <br />
                                        <div class="form-group">
                                            <label for="exampleInputFile">Escolher imagem do item</label>
                                            <input type="file" id="exampleInputFile">
                                            <p class="help-block">Selecione a imagem do item perdido.</p>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12 text-center">
                                        <asp:LinkButton runat="server" ID="logar" CssClass="btn btn-success">
                                                <span class="glyphicon glyphicon-log-in"></span> Logar
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="cancelar" CssClass="btn btn-danger">
                                             <span class="glyphicon glyphicon-log-out"></span> Cancelar
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4"></div>
            </div>
        </div>

    </div>
</asp:Content>

