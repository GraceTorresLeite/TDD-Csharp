using System;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        private static void LeilaoComApenasUmLance()
        {
            var leilaoPeca1 = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilaoPeca1);

            leilaoPeca1.RecebeLance(fulano, 800.0);

            //Act - método sob teste
            leilaoPeca1.TerminaPregao();

            //Assert
            var valorEsperado = 800;
            var valorObtido = leilaoPeca1.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);

        }

        private static void LeilaoComVariosLances()
        {
            var leilaoPeca1 = new Leilao("Van Gogh");

            var fulano = new Interessada("Fulano", leilaoPeca1);
            var maria = new Interessada("Maria", leilaoPeca1);

            leilaoPeca1.RecebeLance(fulano, 800.0);
            leilaoPeca1.RecebeLance(maria, 900.0);
            leilaoPeca1.RecebeLance(fulano, 1000.0);
            leilaoPeca1.RecebeLance(maria, 990.0);

            //Act - método sob teste
            leilaoPeca1.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilaoPeca1.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);

        }

        private static void Verifica(double esperado, double obtido)
        {
            var cor = Console.ForegroundColor;
            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TESTE OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"TESTE FALHOU! Esperado: {esperado}, obtido: {obtido}.");
            }
            Console.ForegroundColor = cor;
        }

        static void Main(string[] args)
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();
        }
    }
}
