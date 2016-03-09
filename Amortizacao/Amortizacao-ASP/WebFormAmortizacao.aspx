<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAmortizacao.aspx.cs" Inherits="Amortizacao_ASP.Amortizacao"
    EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 250px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">Montante:</td>
                <td>
                    <asp:TextBox ID="txtMontante" runat="server"></asp:TextBox>
                    (em R$)</td>
            </tr>
            <tr>
                <td class="auto-style1">Taxa de juros:</td>
                <td>
                    <asp:TextBox ID="txtTaxaJuros" runat="server"></asp:TextBox>
                    (em %)</td>
            </tr>
            <tr>
                <td class="auto-style1">Quantidade de parcelas:</td>
                <td>
                    <asp:TextBox ID="txtQtdParc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Sistema de Amortização:</td>
                <td>
                    <asp:DropDownList ID="DropAmor" runat="server">
                        <asp:ListItem Value="0">SAC</asp:ListItem>
                        <asp:ListItem Value="1">PRICE</asp:ListItem>
                        <asp:ListItem Value="2">AMERICANO</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="btnGerar" runat="server" Text="Gerar" OnClick="btnGerar_Click" />
                    <asp:Button ID="btnExportar" runat="server" Text="Exportar" OnClick="btnExportar_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
        <br /><br />
        <div>
            <asp:Panel ID="Panel1" runat="server">
            <asp:Table ID="tbtPlanilha" runat="server" GridLines="Both"></asp:Table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
