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
using System.Drawing;

namespace Amortizacao
{
    public partial class WebFormAmortizacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static Table atualTable = new Table();

        private void exportarPdf()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Planilha.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            atualTable.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 30f, 30f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        private void exibirPlanilha()
        {
            classAmortizacao classA = new classAmortizacao();

            int qtd = Convert.ToInt32(txtQtdParc.Text);
            classA.Montante = Convert.ToDouble(txtMontante.Text);
            classA.QtdParcelas = qtd;
            classA.TaxaJuros = Convert.ToDouble(txtTaxaJuros.Text);
            classA.TipoAmor = DropAmor.SelectedItem.Text;

            string[,] planilha = classA.gerarPlanilha(qtd);
            
            //elementos da tabela
            TableRow[] r = new TableRow[qtd + 4];
            TableCell[] cellNums = new TableCell[qtd + 3];
            TableCell[] cellPrest = new TableCell[qtd + 3];
            TableCell[] cellJuros = new TableCell[qtd + 3];
            TableCell[] cellAmor = new TableCell[qtd + 3];
            TableCell[] cellSaldoD = new TableCell[qtd + 3];

            //titulo da tabela
            TableCell titulo = new TableCell();
            titulo.ColumnSpan = 5;
            titulo.HorizontalAlign = HorizontalAlign.Center;
            titulo.Font.Bold = true;
            titulo.Text = "AMORTIZAÇÃO DO TIPO " + DropAmor.SelectedItem.Text;
            r[0] = new TableRow();
            r[0].Controls.Add(titulo);
            tbtPlanilha.Controls.Add(r[0]);

            for (int i = 0; i < qtd + 3; i++)
            {
                r[i + 1] = new TableRow();

                cellNums[i] = new TableCell();
                cellPrest[i] = new TableCell();
                cellJuros[i] = new TableCell();
                cellAmor[i] = new TableCell();
                cellSaldoD[i] = new TableCell();

                cellNums[i].Text = planilha[i, 0];
                cellPrest[i].Text = planilha[i, 1];
                cellJuros[i].Text = planilha[i, 2];
                cellAmor[i].Text = planilha[i, 3];
                cellSaldoD[i].Text = planilha[i, 4];

                r[i + 1].Controls.Add(cellNums[i]);
                r[i + 1].Controls.Add(cellPrest[i]);
                r[i + 1].Controls.Add(cellJuros[i]);
                r[i + 1].Controls.Add(cellAmor[i]);
                r[i + 1].Controls.Add(cellSaldoD[i]);

                tbtPlanilha.Controls.Add(r[i + 1]);
            }
            atualTable = tbtPlanilha;
        }

        protected void btnGerar_Click(object sender, EventArgs e)
        {
            exibirPlanilha();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            exportarPdf();
        }
    }
}