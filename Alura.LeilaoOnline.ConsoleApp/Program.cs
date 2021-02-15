using System;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var leilaoPeca1 = new Leilao("Van Gogh");

            var fulano = new Interessada("Fulano", leilaoPeca1);
            var maria = new Interessada("Maria",leilaoPeca1);

            //Lance lanceFulano = new Lance(fulano,5000.0);
            //Lance lanceMaria = new Lance(maria, 4000.0);

            leilaoPeca1.RecebeLance(fulano,800.0);
            leilaoPeca1.RecebeLance(maria, 900.0);
            leilaoPeca1.RecebeLance(fulano, 1000.0);
            leilaoPeca1.RecebeLance(maria, 990.0);

            //Act - método sob teste
            leilaoPeca1.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilaoPeca1.Ganhador.Valor;

            if (valorEsperado == valorObtido)
            {
                Console.WriteLine("Test OK");
            }
            else
            {
                Console.WriteLine("Teste falhou");
            }

        }
    }
}
