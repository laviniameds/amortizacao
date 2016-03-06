using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amortizacao_ASP
{
    public class classAmortizacao
    {
        private double montante;
        private double taxaJuros;
        private int qtdParcelas;

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

        private double[] prestacao;
        private double[] juros;
        private double[] amortizacao;
        private double[] saldoDevedor;
        private double[] total = new double[4];

        private void Calcular(int tipoAmor)
        {
            prestacao = new double[QtdParcelas];
            juros = new double[QtdParcelas];
            amortizacao = new double[QtdParcelas];
            saldoDevedor = new double[QtdParcelas + 1];
            saldoDevedor[0] = Montante;
            total[3] = Montante;
            //sac
            if (tipoAmor == 0)
            {
                for (int k = 0; k < QtdParcelas; k++)
                {
                    juros[k] = saldoDevedor[k] * (TaxaJuros / 100);
                    amortizacao[k] = Montante / QtdParcelas;
                    prestacao[k] = juros[k] + amortizacao[k];
                    saldoDevedor[k+1] = saldoDevedor[k] - amortizacao[k];
                    total[0] += prestacao[k];
                    total[1] += juros[k];
                    total[2] += amortizacao[k];
                    total[3] += saldoDevedor[k+1];
                }
            };
            //price
            if (tipoAmor == 1)
            {
                double taxaK = (TaxaJuros / 100) * Math.Pow((1 + TaxaJuros / 100), QtdParcelas);
                for (int k = 0; k < QtdParcelas; k++)
                {
                    juros[k] = saldoDevedor[k] * (TaxaJuros / 100);
                    prestacao[k] = taxaK * Montante;
                    amortizacao[k] = prestacao[k] - juros[k];
                    saldoDevedor[k + 1] = saldoDevedor[k] - amortizacao[k];
                    total[0] += prestacao[k];
                    total[1] += juros[k];
                    total[2] += amortizacao[k];
                    total[3] += saldoDevedor[k+1];
                }
            }
            //americano
            if (tipoAmor == 2)
            {
                for (int k = 0; k < QtdParcelas; k++)
                {
                    if (k == QtdParcelas - 1)
                    {
                        juros[k] = saldoDevedor[k - 1] * (TaxaJuros / 100);
                        prestacao[k] = saldoDevedor[k - 1] + juros[k];
                        amortizacao[k] = saldoDevedor[k - 1];
                        saldoDevedor[k] = 0;
                    }
                    else
                    {
                        juros[k] = saldoDevedor[k - 1] * (TaxaJuros / 100);
                        prestacao[k] = saldoDevedor[k] * TaxaJuros;
                        amortizacao[k] = 0;
                        saldoDevedor[k + 1] = saldoDevedor[k] - amortizacao[k];
                    }
                    total[0] += prestacao[k];
                    total[1] += juros[k];
                    total[2] += amortizacao[k];
                    total[3] += saldoDevedor[k+1];
                }
            }
        }

        public string[,] gerarPlanilha(int qtdParcelas, int tipoAmor)
        {
            Calcular(tipoAmor);
            string[,] matriz = new string[qtdParcelas + 2, 4];
            matriz[0, 0] = null;
            matriz[1, 0] = null;
            matriz[2, 0] = null;
            matriz[3, 0] = saldoDevedor.ToString();
            for (int i = 0; i < qtdParcelas; i++)
            {
                if (i == qtdParcelas-1)
                {
                    matriz[0, i-1] = total[0].ToString();
                    matriz[1, i-1] = total[1].ToString();
                    matriz[2, i-1] = total[2].ToString();
                    matriz[3, i-1] = total[3].ToString();
                }
                else
                {
                    matriz[i, 0] = prestacao[i].ToString();
                    matriz[i, 1] = juros[i].ToString();
                    matriz[i, 2] = amortizacao[i].ToString();
                    matriz[i, 3] = saldoDevedor[i].ToString();
                }
            }
            return matriz;
        }
    }
}