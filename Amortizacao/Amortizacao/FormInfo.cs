using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amortizacao
{
    public partial class FormInfo : Form
    {
        public FormInfo()
        {
            InitializeComponent();

            amortizacao = comboBoxAmortizacao.SelectedText;
            montante = double.Parse(textBoxMontante.Text);
            taxaJuros = double.Parse(textBoxJuros.Text);
            qtdParcelas = int.Parse(textBoxParcelas.Text);
        }

        private void ButtonGerarTabela_Click(object sender, EventArgs e)
        {

        }

        private readonly double montante;
        public double Montante
        {
            get { return montante; }
        }

        private readonly double taxaJuros;
        public double TaxaJuros
        {
            get { return taxaJuros; }
        }

        private readonly int qtdParcelas;
        public int QtdParcelas
        {
            get { return qtdParcelas; }
        }

        private readonly string amortizacao;
        public string Amortizacao
        {
            get { return amortizacao; }
        } 
    }
}
