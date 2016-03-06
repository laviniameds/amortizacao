using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortizacao
{
    public class Planilha
    {
        private double montante;
        private double taxaJuros;
        private int qtdParcelas;

        public double Montante
        {
            get {return montante;}
            set {montante = value;}
        }
        public double TaxaJuros
        {
            get {return taxaJuros;}
            set {taxaJuros = value;}
        }
        public int QtdParcelas
        {
            get {return qtdParcelas;}
            set {qtdParcelas = value;}
        }

        private double[] prestacao;
        private double[] juros;
        private double[] amortizacao;
        private double[] saldoDevedor;
        private double[] total = new double[3];

        private void Calcular(int i)
        {
            prestacao = new double[QtdParcelas];
            juros = new double[QtdParcelas];
            amortizacao = new double[QtdParcelas];
            saldoDevedor = new double[QtdParcelas+1];
            total = new double[QtdParcelas];
            saldoDevedor[0] = Montante;
            //sac
            if (i == 0)
            {
                for (int k = 0; k < QtdParcelas; k++)
                {
                    juros[k] = saldoDevedor[k] * (TaxaJuros / 100);
                    amortizacao[k] = Montante / QtdParcelas;
                    prestacao[k] = juros[k] + amortizacao[k];
                    saldoDevedor[k+1] = saldoDevedor[k] - amortizacao[k];
                    total[0] += prestacao[k];
                    total[1] += juros[k];
                    total[3] += amortizacao[k];
                }
            };
            //price
            if (i == 1)
            {
                double taxaK = (TaxaJuros / 100) * Math.Pow((1 + TaxaJuros / 100), QtdParcelas);
                for (int k = 0; k < QtdParcelas; k++)
                {
                    juros[k] = saldoDevedor[k - 1] * (TaxaJuros / 100);
                    prestacao[k] = taxaK * Montante;
                    amortizacao[k] = prestacao[k] - juros[k];
                    saldoDevedor[k+1] = saldoDevedor[k] - amortizacao[k];
                    total[0] += prestacao[k];
                    total[1] += juros[k];
                    total[3] += amortizacao[k];
                }
            }
            //americao
            if (i == 2)
            {
                for (int k = 0; k < QtdParcelas; k++)
                {
                    if (k == QtdParcelas - 1)
                    {
                        juros[k] = saldoDevedor[k - 1] * (TaxaJuros / 100);
                        prestacao[k] = saldoDevedor[k - 1] + juros[k];
                        amortizacao[k] = saldoDevedor[k-1];
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
                    total[3] += amortizacao[k];
                }
            }
        }

        public string[,] gerarPlanilha(int x)
        {
            string[,] matriz = new string[x+2, 4];
            matriz[0, 0] = null;
            matriz[0, 1] = null;
            matriz[0, 2] = null;
            matriz[0, 3] = saldoDevedor.ToString();
            for (int i=1;i<x+2;i++)
            {
                if (i == x + 2)
                {
                    matriz[i, 0] = total[0].ToString();
                    matriz[i, 1] = total[1].ToString();
                    matriz[i, 2] = total[2].ToString();
                    matriz[i, 3] = total[3].ToString();
                }
                else
                {
                    matriz[i, 0] = prestacao[i - 1].ToString();
                    matriz[i, 1] = juros[i - 1].ToString();
                    matriz[i, 2] = amortizacao[i - 1].ToString();
                    matriz[i, 3] = saldoDevedor[i - 1].ToString();
                }
            }
            return matriz;
        }



        /*public Planilha()
        {
            SaldoDevedor = new double[Formulario.QtdParcelas];
            ValorJuros = new double[Formulario.QtdParcelas];
            ValorPrestacao = new double[Formulario.QtdParcelas];
        }

        FormInfo Formulario = new FormInfo();
        FormTabela ConstTab = new FormTabela();

        double ValorAmortizacao;

        public double[] SaldoDevedor;
        public double[] ValorJuros;
        public double[] ValorPrestacao;

        //TIPO AMORTIZAÇÃO
        private bool IsSac()
        {
            return (Formulario.Amortizacao == "SAC");
        }

        private bool IsAmericano()
        {
            return (Formulario.Amortizacao == "AMERICANO");
        }

        private bool IsPrice()
        {
            return (Formulario.Amortizacao == "PRICE");
        }

        //CALCULOS
        private void CalculoSAC()
        {
            ValorAmortizacao = Formulario.Montante / Formulario.QtdParcelas;

            SaldoDevedor[0] = Formulario.Montante;

            for (int i = 1; i <= Formulario.QtdParcelas + 1; i++)
            {
                SaldoDevedor[i] = SaldoDevedor[i - 1] - ValorAmortizacao;
                ValorJuros[i] = SaldoDevedor[i - 1] * Formulario.TaxaJuros;
                ValorPrestacao[i] = ValorAmortizacao + ValorJuros[i];
            }
        }

        private void CalculoPrice()
        {

        }

        private void CalculoAmericano()
        {

        }*/

    }
}
