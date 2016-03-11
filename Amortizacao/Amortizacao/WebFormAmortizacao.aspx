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
    <asp:Label ID="Label1" runat="server" 
            Text="SISTEMA PARA GERAR TABELA DE AMORTIZAÇÃO" Font-Bold="True" 
            Font-Size="X-Large"></asp:Label>
            <br /><br />
            <table style="width:100%;">
            <tr>
                <td class="style1">Montante:</td>
                <td class="style2">
                    <asp:TextBox ID="txtMontante" runat="server"></asp:TextBox>
                    (em R$)</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtMontante" ErrorMessage="Campo não preenchido." 
                        ValidationGroup="validarCampos" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">Taxa de juros:</td>
                <td class="style2">
                    <asp:TextBox ID="txtTaxaJuros" runat="server"></asp:TextBox>
                    (em %)</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtTaxaJuros" ErrorMessage="Campo não preenchido." 
                        ValidationGroup="validarCampos" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">Quantidade de parcelas:</td>
                <td class="style2">
                    <asp:TextBox ID="txtQtdParc" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtQtdParc" ErrorMessage="Campo não preenchido." 
                        ValidationGroup="validarCampos" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">Sistema de Amortização:</td>
                <td class="style2">
                    <asp:DropDownList ID="DropAmor" runat="server">
                        <asp:ListItem Value="0">SAC</asp:ListItem>
                        <asp:ListItem Value="1">PRICE</asp:ListItem>
                        <asp:ListItem Value="2">AMERICANO</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Button ID="btnGerar" runat="server" Text="Gerar" OnClick="btnGerar_Click" 
                        ValidationGroup="validarCampos" />
                    <asp:Button ID="btnExportar" runat="server" Text="Exportar" 
                        OnClick="btnExportar_Click" ValidationGroup="validarCampos" />
                </td>
                <td class="style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
        <br /><br />
        <div>
            <asp:Table ID="tbtPlanilha" runat="server" GridLines="Both"></asp:Table>
        </div>
    </form>
</body>
</html>
