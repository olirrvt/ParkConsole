namespace ParkConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string caminhoEntrada = "C:/Users/Taylor/Desktop/ParkConsole/VeiculosEntradas.dat";
            string caminhoSaida = "C:/Users/Taylor/Desktop/ParkConsole/VeiculosSaida.dat";
            int opcao = 0;
            bool continuar = true;

            List<Veiculo> listaVeiculos = new List<Veiculo>(); 
            DateTime dateTime = DateTime.Now;


            while (continuar)
            {

                Console.WriteLine($"Data de hoje: {dateTime.ToString("dd/MM/yyyy")}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--------------------------------");
                Console.WriteLine("SEJA BEM-VINDO(A) AO PROGRAMA!");
                Console.WriteLine("--------------------------------");
                Console.ResetColor();
                Console.WriteLine(" ");

                Console.WriteLine("Escolha uma das opções abaixo:");
                Console.WriteLine(" ");

                Console.WriteLine("1- Entrada de um Veículo");
                Console.WriteLine("2- Saída de um Veículo");   
                Console.WriteLine("3- Ver veículos da garagem");
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("4- Sair do programa");             
                Console.ResetColor();

                Console.WriteLine(" ");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        // Entrada de um veículo
                        Console.Clear();
                        CRUD.cadastrar(listaVeiculos, caminhoEntrada);
                        break;

                    case 2:
                        // Saída de um veículo
                        Console.Clear();
                        CRUD.registrarSaida(listaVeiculos, caminhoEntrada, caminhoSaida);
                        break;

                    case 3:
                        // Listar Carros
                        Console.Clear();
                        CRUD.listarCarros(listaVeiculos, caminhoEntrada);
                        break;

                    case 4:
                        // Saindo do programa
                        continuar = false;
                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entrada inválida, tente outra opção!");
                        Console.WriteLine(" ");
                        Console.ResetColor();
                    break;
                }

            }
            
        }
    }
}