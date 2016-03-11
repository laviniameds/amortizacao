using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amortizacao;

namespace AmortizacaoTestes
{
    [TestClass]
    public class UnitTest1
    {
        private classAmortizacao classAmor = new classAmortizacao();

        [TestMethod]
        public void CalculoSAC_Teste()
        {            
            classAmor.Montante = 1000;
            classAmor.TaxaJuros = 2;
            classAmor.QtdParcelas = 5;
            classAmor.TipoAmor = "SAC";

            classAmor.ParaTesteCalculo();
                        
            Assert.AreEqual(1060.00, Math.Round(classAmor.Total[0], 2));
            Assert.AreEqual(60.00, Math.Round(classAmor.Total[1], 2));
            Assert.AreEqual(1000.00, Math.Round(classAmor.Total[2], 2));
            Assert.AreEqual(0.00, Math.Round(classAmor.Total[3], 2));
        }

        [TestMethod]
        public void CalculoAmericano_Teste()
        {
            classAmor.Montante = 1000;
            classAmor.TaxaJuros = 2;
            classAmor.QtdParcelas = 5;
            classAmor.TipoAmor = "AMERICANO";

            classAmor.ParaTesteCalculo();

            Assert.AreEqual(1100.00, Math.Round(classAmor.Total[0], 2));
            Assert.AreEqual(100.00, Math.Round(classAmor.Total[1], 2));
            Assert.AreEqual(1000.00, Math.Round(classAmor.Total[2], 2));
            Assert.AreEqual(0.00, Math.Round(classAmor.Total[3], 2));
        }

        [TestMethod]
        public void CalculoPrice_Teste()
        {
            classAmor.Montante = 1000;
            classAmor.TaxaJuros = 2;
            classAmor.QtdParcelas = 5;
            classAmor.TipoAmor = "PRICE";

            classAmor.ParaTesteCalculo();

            Assert.AreEqual(1060.79, Math.Round(classAmor.Total[0], 2));
            Assert.AreEqual(60.79, Math.Round(classAmor.Total[1], 2));
            Assert.AreEqual(1000.00, Math.Round(classAmor.Total[2], 2));
            Assert.AreEqual(0.00, Math.Round(classAmor.Total[3], 2));
        }
    }
}
