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
                    juros[k] = Math.Round(saldoDevedor[k] * (TaxaJuros / 100), 2);
                    amortizacao[k] = Math.Round(Montante / QtdParcelas,2);
                    prestacao[k] = Math.Round(juros[k] + amortizacao[k],2);
                    saldoDevedor[k+1] = Math.Round(saldoDevedor[k] - amortizacao[k], 2);
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
                    prestacao[k] = Math.Round(taxaK * Montante,2);
                    juros[k] = Math.Round((TaxaJuros / 100) * saldoDevedor[k],2);
                    amortizacao[k] = Math.Round(prestacao[k] - juros[k],2);
                    saldoDevedor[k + 1] = Math.Round(saldoDevedor[k] - amortizacao[k],2);
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
                        amortizacao[k] = Math.Round(Montante,2);
                        juros[k] = Math.Round((TaxaJuros / 100) * Montante,2);
                        prestacao[k] = Math.Round(juros[k] + Montante,2);
                    }
                    else
                    {
                        saldoDevedor[k + 1] = Math.Round(Montante,2);
                        juros[k] = Math.Round((TaxaJuros / 100) * Montante,2);
                        amortizacao[k] = 0;
                        prestacao[k] = Math.Round(juros[k],2);
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
                    matriz[i, 0] = total[0].ToString();
                    matriz[i, 1] = total[1].ToString();
                    matriz[i, 2] = total[2].ToString();
                    matriz[i, 3] = total[3].ToString();
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