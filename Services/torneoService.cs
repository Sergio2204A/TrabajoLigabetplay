using LigaBetPlaySimulador.Models;
using System;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace LigaBetPlaySimulador.Services
{
    public class TorneoService
    {
        private Torneo torneo;
        private Random random = new Random();

        public TorneoService()
        {
            torneo = new Torneo();
        }

        // Registrar equipo
        public void RegistrarEquipo(string nombre)
        {
            torneo.Equipos.Add(new Equipo(nombre));
        }

        // Listar equipos
        public void ListarEquipos()
        {
            foreach (var equipo in torneo.Equipos)
            {
                Console.WriteLine($"- {equipo.Nombre}");
            }
        }
        public void MostrarTabla()
{
    var tabla = torneo.Equipos
        .OrderByDescending(e => e.Puntos)
        .ThenByDescending(e => e.DiferenciaGoles)
        .ThenByDescending(e => e.GF)
        .ThenBy(e => e.Nombre);

    Console.WriteLine("\nTABLA DE POSICIONES\n");

    foreach (var e in tabla)
    {
        Console.WriteLine($"{e.Nombre} | PJ:{e.PJ} PG:{e.PG} PE:{e.PE} PP:{e.PP} GF:{e.GF} GC:{e.GC} DG:{e.DiferenciaGoles} PTS:{e.Puntos}");
    }
}
        // Buscar equipo
        public Equipo BuscarEquipo(string nombre)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return torneo.Equipos
                .FirstOrDefault(e => e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
#pragma warning restore CS8603 // Possible null reference return.
        }

        // Simular partido
        public void SimularPartido(string nombre1, string nombre2, int goles1, int goles2)
        {
            var equipo1 = BuscarEquipo(nombre1);
            var equipo2 = BuscarEquipo(nombre2);

            if (equipo1 == null || equipo2 == null)
            {
                Console.WriteLine("Uno de los equipos no existe.");
                return;
            }

            // Actualizar PJ
            equipo1.PJ++;
            equipo2.PJ++;

            // Goles
            equipo1.GF += goles1;
            equipo1.GC += goles2;

            equipo2.GF += goles2;
            equipo2.GC += goles1;

            // Resultado
            if (goles1 > goles2)
            {
                equipo1.PG++;
                equipo2.PP++;
                equipo1.Puntos += 3;
            }
            else if (goles2 > goles1)
            {
                equipo2.PG++;
                equipo1.PP++;
                equipo2.Puntos += 3;
            }
            else
            {
                equipo1.PE++;
                equipo2.PE++;
                equipo1.Puntos += 1;
                equipo2.Puntos += 1;
            }
        }

        // Obtener líder
        public void ObtenerLider()
        {
            var lider = torneo.Equipos
                .OrderByDescending(e => e.Puntos)
                .ThenByDescending(e => e.DiferenciaGoles)
                .FirstOrDefault();

            Console.WriteLine($"\nLíder: {lider?.Nombre} con {lider?.Puntos} puntos");
        }

        // Equipo más goleador
        public void EquipoMasGoleador()
        {
            var equipo = torneo.Equipos
                .OrderByDescending(e => e.GF)
                .FirstOrDefault();

            Console.WriteLine($"\nMás goleador: {equipo?.Nombre} ({equipo?.GF} goles)");
        }

        // Mejor defensa
        public void MejorDefensa()
        {
            var equipo = torneo.Equipos
                .OrderBy(e => e.GC)
                .FirstOrDefault();

            Console.WriteLine($"\nMejor defensa: {equipo?.Nombre} ({equipo?.GC} goles recibidos)");
        }

        // Equipos con más victorias
        public void MasGanados()
        {
            var max = torneo.Equipos.Max(e => e.PG);

            var equipos = torneo.Equipos
                .Where(e => e.PG == max);

            Console.WriteLine("\nEquipos con más victorias:");
            foreach (var e in equipos)
                Console.WriteLine($"{e.Nombre} - {e.PG} PG");
        }

        // Equipos con más empates
        public void MasEmpates()
        {
            var max = torneo.Equipos.Max(e => e.PE);

            var equipos = torneo.Equipos
                .Where(e => e.PE == max);

            Console.WriteLine("\nEquipos con más empates:");
            foreach (var e in equipos)
                Console.WriteLine($"{e.Nombre} - {e.PE} PE");
        }

        // Equipos con más derrotas
        public void MasDerrotas()
        {
            var max = torneo.Equipos.Max(e => e.PP);

            var equipos = torneo.Equipos
                .Where(e => e.PP == max);

            Console.WriteLine("\nEquipos con más derrotas:");
            foreach (var e in equipos)
                Console.WriteLine($"{e.Nombre} - {e.PP} PP");
        }

        // Equipos invictos
        public void EquiposInvictos()
        {
            var equipos = torneo.Equipos
                .Where(e => e.PP == 0);

            Console.WriteLine("\nEquipos invictos:");
            foreach (var e in equipos)
                Console.WriteLine(e.Nombre);
        }

        // Equipos sin victorias
        public void SinVictorias()
        {
            var equipos = torneo.Equipos
                .Where(e => e.PG == 0);

            Console.WriteLine("\nEquipos sin victorias:");
            foreach (var e in equipos)
                Console.WriteLine(e.Nombre);
        }

        // Top 3
        public void Top3()
        {
            var top = torneo.Equipos
                .OrderByDescending(e => e.Puntos)
                .Take(3);

            Console.WriteLine("\nTop 3:");
            foreach (var e in top)
                Console.WriteLine($"{e.Nombre} - {e.Puntos} pts");
        }

        // Equipos con diferencia positiva
        public void DiferenciaPositiva()
        {
            var equipos = torneo.Equipos
                .Where(e => e.DiferenciaGoles > 0);

            Console.WriteLine("\nEquipos con diferencia positiva:");
            foreach (var e in equipos)
                Console.WriteLine(e.Nombre);
        }

        // Buscar equipo por nombre
        public void BuscarEquipoPorNombre(string nombre)
        {
            var equipo = torneo.Equipos
                .FirstOrDefault(e => e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (equipo != null)
                Console.WriteLine($"{equipo.Nombre} - {equipo.Puntos} pts");
            else
                Console.WriteLine("Equipo no encontrado");
        }

        // Promedio goles a favor
        public void PromedioGolesFavor()
        {
            var promedio = torneo.Equipos.Average(e => e.GF);
            Console.WriteLine($"\nPromedio GF: {promedio:F2}");
        }

        // Total goles
        public void TotalGoles()
        {
            var total = torneo.Equipos.Sum(e => e.GF);
            Console.WriteLine($"\nTotal goles: {total}");
        }

        // Total puntos
        public void TotalPuntos()
        {
            var total = torneo.Equipos.Sum(e => e.Puntos);
            Console.WriteLine($"\nTotal puntos: {total}");
        }

        // Orden alfabético
        public void OrdenAlfabetico()
        {
            var lista = torneo.Equipos.OrderBy(e => e.Nombre);

            Console.WriteLine("\nEquipos ordenados:");
            foreach (var e in lista)
                Console.WriteLine(e.Nombre);
        }

        // Generar goles aleatorios
        private int GenerarGoles()
        {
            return random.Next(0, 6); // entre 0 y 5 goles
        }

        // Simular partido automático
        public void SimularPartidoAutomatico(string equipo1, string equipo2)
        {
            int goles1 = GenerarGoles();
            int goles2 = GenerarGoles();

            Console.WriteLine($"\n{equipo1} {goles1} - {goles2} {equipo2}");

            SimularPartido(equipo1, equipo2, goles1, goles2);
        }

        // Simular todos contra todos
        public void SimularTodosContraTodos()
        {
            for (int i = 0; i < torneo.Equipos.Count; i++)
            {
                for (int j = i + 1; j < torneo.Equipos.Count; j++)
                {
                    var eq1 = torneo.Equipos[i].Nombre;
                    var eq2 = torneo.Equipos[j].Nombre;

                    SimularPartidoAutomatico(eq1, eq2);
                }
            }
        }

        // Simular jornada
        public void SimularJornada()
        {
            var equipos = torneo.Equipos.OrderBy(e => random.Next()).ToList();

            Console.WriteLine("\n--- JORNADA ---");

            for (int i = 0; i < equipos.Count - 1; i += 2)
            {
                SimularPartidoAutomatico(equipos[i].Nombre, equipos[i + 1].Nombre);
            }
        }

        // Generar fixture
        public void GenerarFixture()
        {
            var equipos = torneo.Equipos.Select(e => e.Nombre).ToList();

            if (equipos.Count % 2 != 0)
                equipos.Add("DESCANSA");

            int numEquipos = equipos.Count;
            int jornadas = numEquipos - 1;
            int partidosPorJornada = numEquipos / 2;

            torneo.Jornadas.Clear();

            for (int j = 0; j < jornadas; j++)
            {
                var jornada = new Jornada(j + 1);

                for (int i = 0; i < partidosPorJornada; i++)
                {
                    string local = equipos[i];
                    string visitante = equipos[numEquipos - 1 - i];

                    if (local != "DESCANSA" && visitante != "DESCANSA")
                    {
                        jornada.Partidos.Add((local, visitante));
                    }
                }

                torneo.Jornadas.Add(jornada);

                // Rotación de equipos (algoritmo round-robin)
                var ultimo = equipos[numEquipos - 1];
                equipos.RemoveAt(numEquipos - 1);
                equipos.Insert(1, ultimo);
            }

            Console.WriteLine("\nFixture generado correctamente.");
        }

        // Guardar datos
        public void GuardarDatos(string archivo = "torneo.json")
        {
            var json = JsonSerializer.Serialize(torneo, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(archivo, json);
            Console.WriteLine($"Datos guardados en {archivo}");
        }

        // Cargar datos
        public void CargarDatos()
        {
            if (File.Exists("torneo.json"))
            {
                string json = File.ReadAllText("torneo.json");

                torneo = JsonSerializer.Deserialize<Torneo>(json) ?? new Torneo();

                Console.WriteLine("Datos cargados correctamente.");
            }
            else
            {
                Console.WriteLine("No hay datos guardados.");
            }
        }

        // Guardar datos
        public void GuardarDatos()
        {
            string json = JsonSerializer.Serialize(torneo, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("torneo.json", json);

            Console.WriteLine("\nDatos guardados correctamente.");
        }
        public void MostrarFixture()
            {
                foreach (var jornada in torneo.Jornadas)
                {
                    Console.WriteLine($"\nJornada {jornada.Numero}");

                    foreach (var partido in jornada.Partidos)
                    {
                    Console.WriteLine($"{partido.Item1} vs {partido.Item2}");
                }
            }
        }
        public void SimularJornadaFixture(int numero)
        {
            var jornada = torneo.Jornadas.FirstOrDefault(j => j.Numero == numero);

            if (jornada == null)
            {
                Console.WriteLine("Jornada no existe.");
                return;
            }

            Console.WriteLine($"\n--- SIMULANDO JORNADA {numero} ---");

            foreach (var partido in jornada.Partidos)
            {
                SimularPartidoAutomatico(partido.Item1, partido.Item2);
            }
        }
        public void GenerarReporteFinal()
        {
            Console.WriteLine("\n===== REPORTE FINAL DEL TORNEO =====\n");

            var campeon = torneo.Equipos
                .OrderByDescending(e => e.Puntos)
                .ThenByDescending(e => e.DiferenciaGoles)
                .FirstOrDefault();

            var goleador = torneo.Equipos
                .OrderByDescending(e => e.GF)
                .FirstOrDefault();

            var mejorDefensa = torneo.Equipos
                .OrderBy(e => e.GC)
                .FirstOrDefault();

            var totalGoles = torneo.Equipos.Sum(e => e.GF);
            var promedioGoles = torneo.Equipos.Average(e => e.GF);

            Console.WriteLine($"🏆 Campeón: {campeon?.Nombre} ({campeon?.Puntos} pts)");
            Console.WriteLine($"⚽ Mejor ataque: {goleador?.Nombre} ({goleador?.GF} goles)");
            Console.WriteLine($"🧤 Mejor defensa: {mejorDefensa?.Nombre} ({mejorDefensa?.GC} goles)");
            Console.WriteLine($"📊 Total goles del torneo: {totalGoles}");
            Console.WriteLine($"📈 Promedio de goles: {promedioGoles:F2}");

            Console.WriteLine("\n===== TOP 5 =====");

            var top5 = torneo.Equipos
                .OrderByDescending(e => e.Puntos)
                .Take(5);

            foreach (var e in top5)
            {
                Console.WriteLine($"{e.Nombre} - {e.Puntos} pts");
            }
        }
    }
}
