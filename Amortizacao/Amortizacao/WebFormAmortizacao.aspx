<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAmortizacao.aspx.cs" Inherits="Amortizacao.WebFormAmortizacao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 295px;
        }
        .style2
        {
            width: 249px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Table ID="tbtPlanilha" runat="server" GridLines="Both">
                </asp:Table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnGerar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <br />
        <div>
    </div>
    </form>
</body>
</html>
