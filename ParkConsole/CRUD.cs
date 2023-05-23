using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkConsole
{
    internal class CRUD
    {
        public static void cadastrar(List<Veiculo> listaVeiculo, string caminhoArquivo)
        {
            string placaVeiculo;
            string horaEntrada;
            Veiculo veiculo;

            Console.Write("Digite a placa do veículo: ");
            placaVeiculo = Console.ReadLine().ToUpper();

            Console.Write("Digite a hora da entrada do veículo: ");
            horaEntrada = Console.ReadLine();

            veiculo = new Veiculo(placaVeiculo, horaEntrada);

            if (!listaVeiculo.Contains(veiculo))
            {
                listaVeiculo.Add(veiculo);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Veículo Cadastrado na Garagem!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O veículo já está na garagem!");
                Console.ResetColor();
            }

            Persistencia.atualizarEntradaArquivo(veiculo, caminhoArquivo);
        }
    }
}
