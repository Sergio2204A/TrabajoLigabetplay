using System.Collections.Generic;

namespace LigaBetPlaySimulador.Models
{
    public class Jornada
    {
        public int Numero { get; set; }
        public List<(string, string)> Partidos { get; set; }

        public Jornada(int numero)
        {
            Numero = numero;
            Partidos = new List<(string, string)>();
        }
    }
}
