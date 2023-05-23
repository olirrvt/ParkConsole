using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkConsole
{
    internal class Persistencia
    {
        // Entrada dos Veículos

        public static void lerArquivoVeiculoEntrada(string caminhoArquivo)
        {
            try
            {
                StreamReader leitor = new StreamReader(caminhoArquivo, Encoding.UTF8);
                do
                {
                    Console.WriteLine(leitor.ReadToEnd());
                } while (leitor.EndOfStream);

                leitor.Close();
            } 
            catch (Exception)
            {
                Console.WriteLine("Ocorreu um erro no arquivo!");
            }
        }
        public static void gravarArquivoVeiculosEntrada(List<Veiculo> listaEntrada, string caminhoArquivo)
        {
            StreamWriter escritor = new StreamWriter(caminhoArquivo, append: true);

            foreach (var veiculo in listaEntrada)
            { 
                escritor.WriteLine($"{veiculo.PlacaVeiculo};{veiculo.DataEntrada};{veiculo.HoraEntrada}");
                escritor.Flush();
            }
            escritor.Close();
        }
        public static void atualizarEntradaArquivo(Veiculo veiculo, string nomeArquivo)
        {
            StreamWriter escritor = new StreamWriter(nomeArquivo, append: true);
            escritor.WriteLine($"{veiculo.PlacaVeiculo};{veiculo.DataEntrada};{veiculo.HoraEntrada}");

            escritor.Close();
        }
        public static void popularArquivoEntrada(string nomeArquivo, List<Veiculo> lista)
        {
            StreamReader leitor = new StreamReader(nomeArquivo, Encoding.UTF8);

            string[] vetorLinha;
            string linha;

            do
            {
                linha = leitor.ReadLine();
                vetorLinha = linha.Split(";");

                lista.Add(new Veiculo(vetorLinha[0], vetorLinha[1]));

            } while (!leitor.EndOfStream);
            leitor.Close();
        }

        // Saída dos Veículos 

        public static void lerArquivoVeiculosSaida(string caminhoArquivo)
        {
            try
            {
                StreamReader leitor = new StreamReader(caminhoArquivo, Encoding.UTF8);
                do
                {
                    Console.WriteLine(leitor.ReadToEnd());
                } while (leitor.EndOfStream);

                leitor.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Ocorreu um erro no arquivo!");
            }
        }
        public static void gravarArquivoVeiculosSaida(List<Veiculo> listaSaida, string caminhoArquivo)
        {
            StreamWriter escritor = new StreamWriter(caminhoArquivo, append: true);

            foreach (var veiculo in listaSaida)
            {
                escritor.WriteLine($"{veiculo.PlacaVeiculo};{veiculo.HoraEntrada};{veiculo.TempoPermanencia};{veiculo.ValorCobrado}");
                escritor.Flush();
            }
            escritor.Close();
        }
        public static void atualizarSaidaArquivo(Veiculo veiculo, string nomeArquivo)
        {
            StreamWriter escritor = new StreamWriter(nomeArquivo, append: true);
            escritor.WriteLine($"{veiculo.PlacaVeiculo};{veiculo.HoraEntrada};{veiculo.TempoPermanencia};{veiculo.ValorCobrado}");

            escritor.Close();
        }
        public static void popularArquivoSaida(string nomeArquivo, List<Veiculo> lista)
        {
            StreamReader leitor = new StreamReader(nomeArquivo, Encoding.UTF8);

            string[] vetorLinha;
            string linha;

            do
            {
                linha = leitor.ReadLine();
                vetorLinha = linha.Split(";");

                lista.Add(new Veiculo(vetorLinha[0], vetorLinha[1]));

            } while (!leitor.EndOfStream);
            leitor.Close();
        }
    }
}

//  lerArquivoVeiculosEntrada();
//  gravarArquivoVeiculosEntrada();

//  lerArquivoVeiculosSaida();
//  gravarArquivoVeiculosSaida();