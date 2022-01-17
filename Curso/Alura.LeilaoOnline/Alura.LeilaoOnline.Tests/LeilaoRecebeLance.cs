using Xunit;
using Alura.LeilaoOnline.Core;
using System.Linq;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeLance
    {
        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoRealizouUltimoLance()
        {

            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 800);
                       
            //Act - método sob teste
            leilao.RecebeLance(fulano, 1000);

            //leilao.TerminaPregao();

            //Assert
            var qtdeEsperada = 1;
            var qtdeObtido = leilao.Lances.Count();

            Assert.Equal(qtdeEsperada, qtdeObtido);
        }

        [Theory]
        [InlineData(4, new double[] { 1000, 1200, 1400, 1300 })]
        [InlineData(2, new double[] { 800, 900})]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdeEsperada, double[] ofertas)
        {

            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();

            float intercalar = 0;

            foreach(var valor in ofertas)
            {
                if((intercalar%2) == 0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }

                intercalar++;
                
            }

            leilao.TerminaPregao();

            //Act - método sob teste
            leilao.RecebeLance(fulano, 1000);

            //Assert
            var qtdeObtido = leilao.Lances.Count();

            Assert.Equal(qtdeEsperada, qtdeObtido);
        }
    }
}
