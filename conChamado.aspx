﻿<%@ Page Title="Chamados" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="conChamado.aspx.cs" Inherits="conChamado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="list-group">
        <li class="list-group-item active">
            <div class="row">
                <div class="col-md-12">
                    <div class="input-group">
                        <input type="text" class="form-control" placeholder="Procurando por...">
                        <span class="input-group-btn">
                            <button class="btn btn-default" type="button">Pesquisar</button>
                        </span>
                    </div>
                </div>
            </div>
        </li>
    </ul>

    <div class="row">
        <asp:Repeater runat="server" ID="chamado">
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
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

