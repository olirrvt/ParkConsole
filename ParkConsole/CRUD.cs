using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkConsole
{
    internal class CRUD
    {
        public static int NumeroDeVagas { get; set; } = 50;
        public static bool VerificarHorarioEntrada(string horaEntrada)
        {
            if (DateTime.TryParseExact(horaEntrada, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime hora))
            {
                DateTime horaMinima = DateTime.ParseExact("07:00", "HH:mm", CultureInfo.InvariantCulture);
                DateTime horaMaxima = DateTime.ParseExact("20:00", "HH:mm", CultureInfo.InvariantCulture);

                if (hora >= horaMinima && hora <= horaMaxima)
                {
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Horário de entrada inválido.");
                    Console.WriteLine("Os carros só podem ser cadastrados de 07:00 às 20:00.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Formato de hora inválido. Use o formato HH:mm.");
                Console.ResetColor();
            }

            return false;
        }
        public static void cadastrar(List<Veiculo> listaVeiculo, string caminhoArquivo)
        {
            string placaVeiculo;
            string horaEntrada;
            string resposta;
            bool continuar = true;
            Veiculo veiculo;

            do
            {
                if (CRUD.NumeroDeVagas != 0)
                {
                    Console.Write("Digite a placa do veículo: ");
                    placaVeiculo = Console.ReadLine().ToUpper();

                    do
                    {
                        Console.Write("Digite a hora da entrada do veículo (formato HH:mm): ");
                        horaEntrada = Console.ReadLine();
                    } while (!VerificarHorarioEntrada(horaEntrada));

                    veiculo = new Veiculo(placaVeiculo, horaEntrada);

                    if (!listaVeiculo.Contains(veiculo))
                    {
                        Console.Clear();

                        CRUD.NumeroDeVagas--;
                        listaVeiculo.Add(veiculo);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Veículo Cadastrado na Garagem!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("O veículo já está na garagem!");
                        Console.ResetColor();
                    }

                    Persistencia.atualizarEntradaArquivo(veiculo, caminhoArquivo);
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Garagem cheia, tente novamente mais tarde!");
                    Console.ResetColor();
                    break;
                }

                Console.WriteLine("Deseja cadastrar mais um carro? (S/N)");
                resposta = Console.ReadLine().ToUpper();

                continuar = resposta == "S";

            } while (continuar);
  
        }
        public static void registrarSaida(List<Veiculo> listaVeiculo, string caminhoEntrada, string caminhoSaida)
        {
            string placaVeiculo;
            string horaSaida;
            string resposta;
            bool continuar = true;

            List<Veiculo> listaVeiculoEntrada = Persistencia.popularArquivoEntrada(caminhoEntrada);

            do
            {

                Console.Clear();

                listaVeiculo = listaVeiculoEntrada;

                Console.Write("Digite a placa do veículo que irá sair: ");
                placaVeiculo = Console.ReadLine().ToUpper();

                foreach(var item in listaVeiculo)
                {
                    Console.WriteLine(item.PlacaVeiculo);
                    Console.WriteLine(item.DataEntrada);
                    Console.WriteLine(item.HoraEntrada);
                }

                Veiculo veiculo = listaVeiculo.Find(v =>
                v.PlacaVeiculo.Equals(placaVeiculo, StringComparison.OrdinalIgnoreCase));

                if (veiculo != null)
                {
                    Console.Write("Digite a hora da saída do veículo: ");
                    horaSaida = Console.ReadLine();

                    CRUD.NumeroDeVagas++;
                    listaVeiculo.Remove(veiculo);
                    veiculo.RegistrarSaida(horaSaida);

                    Persistencia.atualizarSaidaArquivo(veiculo, caminhoSaida);

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saída registrada com sucesso!");
                    Console.ResetColor();
                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Veículo não encontrado no estacionamento");
                    Console.ResetColor();
                }

                Console.WriteLine("Deseja registrar mais uma saída?");
                resposta = Console.ReadLine().ToUpper();

                continuar = resposta == "S";

            } while (continuar);
        }
    }
}
