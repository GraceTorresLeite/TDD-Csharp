using Alura.LeilaoOnline.Core;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline
{
    public class LeilaoTerminaPregao
    {
        //Para executar, v� na barra superior de op��es 
        //e acesse "Teste > Executar > Todos os testes" 
        //pela primeira vez, sendo poss�vel acionar outras execu��es.
        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(
            double valorEsperado,
            double[] ofertas)
        {
            //Arranje - cen�rio
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }

            //Act - m�todo sob teste
            leilao.TerminaPregao();

            //Assert
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);

        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arranje - cen�rio
            var leilao = new Leilao("Van Gogh");
            leilao.IniciaPregao();

            //Act - m�todo sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LancaInvalidOperationExceptionDadopregaoNaoIniciado()
        {
            //Arrange - cen�rio
            var leilao = new Leilao("Van Gogh");

            //try
            //{
            //    //Act - m�todo sob teste
            //    leilao.TerminaPregao();
            //    Assert.True(false);
            //}
            //catch (System.Exception e)
            //{
            //    //Assert
            //    Assert.IsType<System.InvalidOperationException>(e);
            //}

            //Assert
            Assert.Throws<System.InvalidOperationException>(
                //Act - m�todo sob teste
                () => leilao.TerminaPregao()
            );
        }

    }
}
