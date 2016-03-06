using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortizacao
{
    public class Amortizacao
    {
        private double montante;
        private double taxaJuros;
        private int qtdParcelas;

        public double Montante
        {
            get
            {
                return montante;
            }

            set
            {
                montante = value;
            }
        }
        public double TaxaJuros
        {
            get
            {
                return taxaJuros;
            }

            set
            {
                taxaJuros = value;
            }
        }
        public int QtdParcelas
        {
            get
            {
                return qtdParcelas;
            }

            set
            {
                qtdParcelas = value;
            }
        }

        public void Calcular(int i)
        {
            //price
            if (i == 0)
            {

            };
            if (i == 1) ;
            if (i == 2) ;
        }
    }
}
