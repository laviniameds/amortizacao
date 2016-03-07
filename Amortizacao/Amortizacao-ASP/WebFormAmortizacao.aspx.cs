using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
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

        private static Table atualTable = new Table();

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
            r[2] = new TableRow();
            r[0].Controls.Add(titulo);

            cellNums[0] = new TableCell();
            cellNums[0].ID = "header";
            cellPrest[0] = new TableCell();
            cellJuros[0] = new TableCell();
            cellAmor[0] = new TableCell();
            cellSaldoD[0] = new TableCell();

            cellNums[1] = new TableCell();
            cellPrest[1] = new TableCell();
            cellJuros[1] = new TableCell();
            cellAmor[1] = new TableCell();
            cellSaldoD[1] = new TableCell();

            cellNums[0].Text = null;
            cellPrest[0].Text = "Prestação (R$)";
            cellJuros[0].Text = "Juros (R$)";
            cellAmor[0].Text = "Amortização (R$)";
            cellSaldoD[0].Text = "Saldo Devedor (R$)";

            cellNums[1].Text = "0";
            cellPrest[1].Text = null;
            cellJuros[1].Text = null;
            cellAmor[1].Text = null;
            cellSaldoD[1].Text = txtMontante.Text;

            r[1].Controls.Add(cellNums[0]);
            r[1].Controls.Add(cellPrest[0]);
            r[1].Controls.Add(cellJuros[0]);
            r[1].Controls.Add(cellAmor[0]);
            r[1].Controls.Add(cellSaldoD[0]);

            r[2].Controls.Add(cellNums[1]);
            r[2].Controls.Add(cellPrest[1]);
            r[2].Controls.Add(cellJuros[1]);
            r[2].Controls.Add(cellAmor[1]);
            r[2].Controls.Add(cellSaldoD[1]);

            tbtPlanilha.Controls.Add(r[0]);
            tbtPlanilha.Controls.Add(r[1]);
            tbtPlanilha.Controls.Add(r[2]);

            for (int i = 0; i < qtd + 1; i++)
            {
                r[i + 3] = new TableRow();
                cellNums[i + 1] = new TableCell();
                cellPrest[i + 1] = new TableCell();
                cellJuros[i + 1] = new TableCell();
                cellAmor[i + 1] = new TableCell();
                cellSaldoD[i + 1] = new TableCell();

                if (i == qtd) cellNums[i + 1].Text = "TOTAL";
                else cellNums[i + 1].Text = (i + 1).ToString();
                cellNums[i + 1].ID = (i + 1).ToString();
                cellPrest[i + 1].Text = planilha[i, 0];
                cellJuros[i + 1].Text = planilha[i, 1];
                cellAmor[i + 1].Text = planilha[i, 2];
                cellSaldoD[i + 1].Text = planilha[i, 3];

                r[i + 3].Controls.Add(cellNums[i + 1]);
                r[i + 3].Controls.Add(cellPrest[i + 1]);
                r[i + 3].Controls.Add(cellJuros[i + 1]);
                r[i + 3].Controls.Add(cellAmor[i + 1]);
                r[i + 3].Controls.Add(cellSaldoD[i + 1]);
                tbtPlanilha.Controls.Add(r[i + 3]);
            }
            atualTable = tbtPlanilha;
        }

        public static string ConvertDataTableToHTML(Table tb, int limite)
        {
            string html = "<table>";
            //add header row
            html += "<tr>";
            html += "<th>" + tb.Rows[0].Cells[0].Text + "</th>";
            for (int i = 0; i < 5; i++)
                html += "<th>" + tb.Rows[1].Cells[i].Text + "</th>";
            html += "</tr>";
            //add rows
            for (int i = 2; i < limite; i++)
            {
                html += "<tr>";
                for (int j = 0; j < 5; j++)
                    html += "<td>" + tb.Rows[i].Cells[j].Text + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            return html;
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            string html = ConvertDataTableToHTML(atualTable, atualTable.Rows.Count - 2);
            HtmlString s = new HtmlString(html);
            try
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                Paragraph Text = new Paragraph(s.ToString());
                pdfDoc.Add(Text);
                pdfWriter.CloseStream = false;
                pdfDoc.Close();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Example.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
            catch (Exception ex)
            { Response.Write(ex.Message); }
        }

    }
}