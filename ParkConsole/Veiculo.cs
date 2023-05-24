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
            HoraEntrada = horaEntrada;
            DataEntrada = dateTime.ToString("dd/MM/yyyy");
        }

        public void RegistrarSaida(string horaSaida)
        {
            HoraSaida = horaSaida;
            CalculaTempoPermanencia();
        }

        private void CalculaTempoPermanencia()
        {
            Veiculo veiculo;
            veiculo = new Veiculo();

            TimeSpan horaEntrada = TimeSpan.Parse(HoraEntrada);
            TimeSpan horaSaida = TimeSpan.Parse(HoraSaida);

            TimeSpan intervalo = horaSaida - horaEntrada;
            TempoPermanencia = intervalo.TotalMinutes;
            CalculaValorCobrado(horaSaida);
        }

        private void CalculaValorCobrado(TimeSpan horaSaida)
        {
            const double valorPorHora = 5.0;

            if (TempoPermanencia > 60.0)
            {
                int horasPermanencia = (int)Math.Ceiling(TempoPermanencia / 60.0);
                TimeSpan horaLimite = new TimeSpan(20, 1, 0);

                if (horaSaida > horaLimite)
                {
                    horasPermanencia += 1;
                }

                ValorCobrado = valorPorHora * horasPermanencia;
            }
            else
            {
                ValorCobrado = 0.0;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Veiculo veiculo)
            {
                return PlacaVeiculo == veiculo.PlacaVeiculo;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return PlacaVeiculo.GetHashCode();
        }
    }
}
