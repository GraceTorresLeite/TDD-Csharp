using Alura.LeilaoOnline.Core;
using System;
using Xunit;

namespace Alura.LeilaoOnline
{
    public class LeilaoTestes
    {
        //Para executar, v� na barra superior de op��es 
        //e acesse "Teste > Executar > Todos os testes" 
        //pela primeira vez, sendo poss�vel acionar outras execu��es.
   
        [Fact]
        public void LeilaoComApenasUmLance()
        {
            //Arrange
            var leilaoPeca1 = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilaoPeca1);

            leilaoPeca1.RecebeLance(fulano, 800.0);

            //Act - m�todo sob teste
            leilaoPeca1.TerminaPregao();

            //Assert
            var valorEsperado = 800;
            var valorObtido = leilaoPeca1.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);

        }

        [Fact]
        public void LeilaoComTresLances()
        {
            //Arrange
            var leilaoPeca1 = new Leilao("Van Gogh");

            var fulano = new Interessada("Fulano", leilaoPeca1);
            var maria = new Interessada("Maria", leilaoPeca1);
            var beltrano = new Interessada("Beltrano", leilaoPeca1);

            leilaoPeca1.RecebeLance(fulano, 800.0);
            leilaoPeca1.RecebeLance(maria, 900.0);
            leilaoPeca1.RecebeLance(fulano, 1000.0);
            leilaoPeca1.RecebeLance(maria, 990.0);
            leilaoPeca1.RecebeLance(beltrano, 1400.0);

            //Act - m�todo sob teste
            leilaoPeca1.TerminaPregao();

            //Assert
            var valorEsperado = 1400;
            var valorObtido = leilaoPeca1.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
            Assert.Equal(beltrano, leilaoPeca1.Ganhador.Cliente);

        }


        [Fact]
        public void LeilaoComVariosLances()
        {
            //Arrange
            var leilaoPeca1 = new Leilao("Van Gogh");

            var fulano = new Interessada("Fulano", leilaoPeca1);
            var maria = new Interessada("Maria", leilaoPeca1);

            leilaoPeca1.RecebeLance(fulano, 800.0);
            leilaoPeca1.RecebeLance(maria, 900.0);
            leilaoPeca1.RecebeLance(fulano, 1000.0);
            leilaoPeca1.RecebeLance(maria, 990.0);

            //Act - m�todo sob teste
            leilaoPeca1.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilaoPeca1.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);

        }
        //xunit n�o trabalha com m�todos est�ticos 
       
    }
}
