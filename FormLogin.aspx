<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormLogin.aspx.cs" Inherits="FormLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script src="script/jquery-3.4.1.js"></script>
    <script src="bootstrap/js/bootstrap.js"></script>
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="login" runat="server">
        <div style="width: 100%; height: 100%; position: absolute; float: left; background-color:#E6EFEA">
            <div style="display: flex; align-items: center; justify-content: center; height: 100%">
                <div class="row" style="width:100%">
                    <div class="col-md-4"></div>
                    <div class="col-md-4">
                        <div class="panel panel-info" style="width:100%">
                            <div class="panel-heading">Login</div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label class="label" style="color: black">
                                                Usuário
                                            </label>
                                            <asp:TextBox runat="server" ID="usuario" CssClass="form-control" placeholder="Digite seu usuario aqui"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label class="label" style="color:black">
                                                Senha
                                            </label>
                                            <asp:TextBox runat="server" ID="senha" CssClass="form-control" placeholder="Digite sua senha" TextMode="Password"></asp:TextBox>
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
    </form>
</body>
</html>
