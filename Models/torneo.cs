using System.Collections.Generic;

namespace LigaBetPlaySimulador.Models
{
    public class Torneo
    {
        public List<Equipo> Equipos { get; set; }
        public List<Jornada> Jornadas { get; set; }

        public Torneo()
        {
            Equipos = new List<Equipo>();
            Jornadas = new List<Jornada>();
        }
    }
}
