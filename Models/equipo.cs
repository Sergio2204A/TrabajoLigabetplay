namespace LigaBetPlaySimulador.Models
{
    public class Equipo
    {
        public string Nombre { get; set; }

        public int PJ { get; set; } = 0;
        public int PG { get; set; } = 0;
        public int PE { get; set; } = 0;
        public int PP { get; set; } = 0;

        public int GF { get; set; } = 0;
        public int GC { get; set; } = 0;

        public int Puntos { get; set; } = 0;

        // Diferencia de gol (propiedad calculada)
        public int DiferenciaGoles => GF - GC;

        public Equipo(string nombre)
        {
            Nombre = nombre;
        }
    }
}
