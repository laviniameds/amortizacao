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
                    total[3] = 0;
                }
            };
            //price
            if (tipoAmor == 1)
            {
                double taxaK = ((TaxaJuros / 100) * Math.Pow((1 + (TaxaJuros / 100)), QtdParcelas))/((Math.Pow((1 + (TaxaJuros / 100)), QtdParcelas))-1);
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
            //americano
            if (tipoAmor == 2)
            {
                for (int k = 0; k < QtdParcelas; k++)
                {
                    if (k == QtdParcelas-1)
                    {
                        saldoDevedor[k+1] = 0;
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
        }

        public string[,] gerarPlanilha(int qtdParcelas, int tipoAmor)
        {
            Calcular(tipoAmor);
            string[,] matriz = new string[qtdParcelas + 1, 4];
            for (int i = 0; i < qtdParcelas+1; i++)
            {
                if (i == qtdParcelas)
                {
                    matriz[i, 0] = total[0].ToString("0.00");
                    matriz[i, 1] = total[1].ToString("0.00");
                    matriz[i, 2] = total[2].ToString("0.00");
                    matriz[i, 3] = total[3].ToString("0.00");
                }
                else
                {
                    matriz[i, 0] = prestacao[i].ToString("0.00");
                    matriz[i, 1] = juros[i].ToString("0.00");
                    matriz[i, 2] = amortizacao[i].ToString("0.00");
                    matriz[i, 3] = saldoDevedor[i].ToString("0.00");
                }
            }
            return matriz;
        }
    }
}