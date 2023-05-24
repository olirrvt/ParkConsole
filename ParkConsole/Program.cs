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

                Console.WriteLine($"Data de hoje: {dateTime}");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("SEJA BEM-VINDO(A) AO PROGRAMA!");
                Console.WriteLine("--------------------------------");
                Console.WriteLine(" ");

                Console.WriteLine("O que você deseja registrar?");
                Console.WriteLine(" ");

                Console.WriteLine("1- Entrada de um Veículo");
                Console.WriteLine("2- Saída de um Veículo");   
                Console.WriteLine("3- Ver veículos da garagem");
                Console.WriteLine("4- Sair do programa");         
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
                        Console.WriteLine("Listar Veículos");
                        break;

                    case 4:
                        // Saindo do programa
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Entrada inválida, tente outra opção!");
                        break;
                }

            }
            
        }
    }
}