using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amortizacao
{
    public class classAmortizacao
    {
        private double montante;
        private double taxaJuros;
        private int qtdParcelas;
        private string tipoAmor;

        public double Montante
        {
            get { return montante; }
            set { montante = value; }
        }
        public double TaxaJuros
        {
            get { return taxaJuros; }
            set { taxaJuros = value; }
        }
        public int QtdParcelas
        {
            get { return qtdParcelas; }
            set { qtdParcelas = value; }
        }
        public string TipoAmor
        {
            get { return tipoAmor; }
            set { tipoAmor = value; }
        }

        private double[] prestacao;
        private double[] juros;
        private double[] amortizacao;
        private double[] saldoDevedor;
        private double[] total = new double[4];

        public double[] Total
        {
            get { return total; }
            set { total = value; }
        }

        private void SacCalculo()
        {
            for (int k = 0; k < QtdParcelas; k++)
            {
                juros[k] = saldoDevedor[k] * (TaxaJuros / 100);
                amortizacao[k] = Montante / QtdParcelas;
                prestacao[k] = juros[k] + amortizacao[k];
                saldoDevedor[k + 1] = saldoDevedor[k] - amortizacao[k];
                total[0] += prestacao[k];
                total[1] += juros[k];
                total[2] += amortizacao[k];
                total[3] = 0;
            }
        }
        private void AmericanoCalculo()
        {
            for (int k = 0; k < QtdParcelas; k++)
            {
                if (k == QtdParcelas - 1)
                {
                    saldoDevedor[k + 1] = 0;
                    amortizacao[k] = Montante;
                    juros[k] = (TaxaJuros / 100) * Montante;
                    prestacao[k] = juros[k] + Montante;
                }
                else
                {
                    saldoDevedor[k + 1] = Montante;
                    juros[k] = (TaxaJuros / 100) * Montante;
                    amortizacao[k] = 0;
                    prestacao[k] = juros[k];
                }
                total[0] += prestacao[k];
                total[1] += juros[k];
                total[2] = Montante;
                total[3] = 0;
            }
        }
        private void PriceCalculo()
        {
            double taxaK = ((TaxaJuros / 100) * Math.Pow((1 + (TaxaJuros / 100)), QtdParcelas)) / ((Math.Pow((1 + (TaxaJuros / 100)), QtdParcelas)) - 1);
            for (int k = 0; k < QtdParcelas; k++)
            {
                prestacao[k] = taxaK * Montante;
                juros[k] = (TaxaJuros / 100) * saldoDevedor[k];
                amortizacao[k] = prestacao[k] - juros[k];
                saldoDevedor[k + 1] = saldoDevedor[k] - amortizacao[k];
                total[0] += prestacao[k];
                total[1] += juros[k];
                total[2] += amortizacao[k];
                total[3] = 0;
            }
        }

        private void Calcular()
        {
            prestacao = new double[QtdParcelas];
            juros = new double[QtdParcelas];
            amortizacao = new double[QtdParcelas];
            saldoDevedor = new double[QtdParcelas + 1];
            saldoDevedor[0] = Montante;
            total[3] = Montante;
            
            if (TipoAmor == "SAC") SacCalculo();
            if (TipoAmor == "PRICE") PriceCalculo();
            if (TipoAmor == "AMERICANO") AmericanoCalculo();
        }

        public void ParaTesteCalculo()
        {
            Calcular();
        }

        public string[,] gerarPlanilha(int qtdParcelas)
        {
            Calcular();
            string [,] matriz = new string[qtdParcelas + 3, 5];
            matriz[0, 0] = "";
            matriz[0, 1] = "Prestação (R$)";
            matriz[0, 2] = "Juros (R$)";
            matriz[0, 3] = "Amortização (R$)";
            matriz[0, 4] = "Saldo devedor (R$)";
            for (int i = 1; i < qtdParcelas + 3; i++)
            {
                if (i == qtdParcelas + 2)
                {
                    matriz[i, 0] = "TOTAL";
                    matriz[i, 1] = total[0].ToString("0.00");
                    matriz[i, 2] = total[1].ToString("0.00");
                    matriz[i, 3] = total[2].ToString("0.00");
                    matriz[i, 4] = total[3].ToString("0.00");
                }
                else if (i == 1)
                {
                    matriz[i, 0] = (i - 1).ToString();
                    matriz[i, 1] = "";
                    matriz[i, 2] = "";
                    matriz[i, 3] = "";
                    matriz[i, 4] = saldoDevedor[i - 1].ToString("0.00"); ;
                }
                else
                {
                    matriz[i, 0] = (i - 1).ToString();
                    matriz[i, 1] = prestacao[i - 2].ToString("0.00");
                    matriz[i, 2] = juros[i - 2].ToString("0.00");
                    matriz[i, 3] = amortizacao[i - 2].ToString("0.00");
                    matriz[i, 4] = saldoDevedor[i-1].ToString("0.00");
                }
            }
            return matriz;
        }
    }
}