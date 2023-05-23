using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkConsole
{
    internal class Veiculo
    {
        public string PlacaVeiculo { get; set; }
        public string DataEntrada { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSaida { get; set; }
        public double TempoPermanencia { get; set; }
        public double ValorCobrado { get; set; }

        public Veiculo() { }

        public Veiculo(string placaVeiculo, string horaEntrada)
        {
            DateTime dateTime = DateTime.Now;

            PlacaVeiculo = placaVeiculo;
            DataEntrada = dateTime.ToString("dd/MM/yyyy");
            HoraEntrada = horaEntrada;
        }

        public void RegistrarSaida(string horaSaida)
        {
            HoraSaida = horaSaida;
            CalculaTempoPermanencia();
        }

        private void CalculaTempoPermanencia()
        {
            TimeSpan horaEntrada = TimeSpan.Parse(HoraEntrada);
            TimeSpan horaSaida = TimeSpan.Parse(HoraSaida);

            TimeSpan intervalo = horaSaida - horaEntrada;
            TempoPermanencia = intervalo.TotalMinutes;
            CalculaValorCobrado();
        }

        private void CalculaValorCobrado()
        {
            double valorMinutos = 0.50;
            ValorCobrado = TempoPermanencia * valorMinutos;
        }

        public override bool Equals(object? obj)
        {
            return obj is Veiculo veiculo &&
                PlacaVeiculo == veiculo.PlacaVeiculo;
        }
    }
}
