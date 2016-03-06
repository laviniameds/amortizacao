using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Amortizacao_ASP
{
    public partial class Amortizacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGerar_Click(object sender, EventArgs e)
        {
            int qtd = Convert.ToInt32(txtQtdParc.Text);
            classAmortizacao classA = new classAmortizacao();
            classA.Montante = Convert.ToDouble(txtMontante.Text);
            classA.QtdParcelas = qtd;
            classA.TaxaJuros = Convert.ToDouble(txtTaxaJuros.Text);
            int tipoAmor = Convert.ToInt32(DropAmor.SelectedItem.Value);

            string[,] planilha = classA.gerarPlanilha(qtd, tipoAmor);

            TableRow[] r = new TableRow[qtd + 4];
            TableCell titulo = new TableCell();
            titulo.Text = "AMORTIZAÇÃO DO TIPO " + DropAmor.SelectedItem.Text;
            TableCell[] cellNums = new TableCell[qtd + 3];
            TableCell[] cellPrest = new TableCell[qtd + 3];
            TableCell[] cellJuros = new TableCell[qtd + 3];
            TableCell[] cellAmor = new TableCell[qtd + 3];
            TableCell[] cellSaldoD = new TableCell[qtd + 3];

            r[0] = new TableRow();
            r[1] = new TableRow();
            r[0].Controls.Add(titulo);

            cellNums[0] = new TableCell();
            cellPrest[0] = new TableCell();
            cellJuros[0] = new TableCell();
            cellAmor[0] = new TableCell();
            cellSaldoD[0] = new TableCell();

            cellNums[0].Text = null;
            cellPrest[0].Text = "Prestação (R$)";
            cellJuros[0].Text = "Juros (R$)";
            cellAmor[0].Text = "Amortização (R$)";
            cellSaldoD[0].Text = "Saldo Devedor (R$)";

            r[1].Controls.Add(cellNums[0]);
            r[1].Controls.Add(cellPrest[0]);
            r[1].Controls.Add(cellJuros[0]);
            r[1].Controls.Add(cellAmor[0]);
            r[1].Controls.Add(cellSaldoD[0]);

            tbtPlanilha.Controls.Add(r[0]);
            tbtPlanilha.Controls.Add(r[1]);

            for (int i = 0; i < qtd; i++)
            {
                r[i+2] = new TableRow();
                cellNums[i+1] = new TableCell();
                cellPrest[i+1] = new TableCell();
                cellJuros[i+1] = new TableCell();
                cellAmor[i+1] = new TableCell();
                cellSaldoD[i+1] = new TableCell();

                cellNums[i+1].Text = i.ToString();
                cellPrest[i+1].Text = planilha[i, 0];
                cellJuros[i+1].Text = planilha[i, 1];
                cellAmor[i+1].Text = planilha[i, 2];
                cellSaldoD[i+1].Text = planilha[i, 3];

                r[i+2].Controls.Add(cellNums[i+1]);
                r[i+2].Controls.Add(cellPrest[i+1]);
                r[i+2].Controls.Add(cellJuros[i+1]);
                r[i+2].Controls.Add(cellAmor[i+1]);
                r[i+2].Controls.Add(cellSaldoD[i+1]);
                tbtPlanilha.Controls.Add(r[i+2]);
            }
        }
    }
}