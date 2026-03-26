using LigaBetPlaySimulador.Services;

namespace LigaBetPlaySimulador
{
    class Program
    {
        static void LimpiarConsola()
        {
            try
            {
                Console.Clear();
            }
            catch (IOException)
            {
                if (!Console.IsOutputRedirected)
                {
                    Console.Write("\u001b[3J\u001b[2J\u001b[H");
                    Console.Out.Flush();
                }
            }
        }

        static void Main(string[] args)
        {
            var servicio = new TorneoService();
            servicio.CargarDatos();
            int opcion;

            do
            {
                LimpiarConsola();
                Console.WriteLine("\n=== LIGA BETPLAY ===");
                Console.WriteLine("1. Registrar equipo");
                Console.WriteLine("2. Listar equipos");
                Console.WriteLine("3. Simular partido");
                Console.WriteLine("4. Ver tabla");
                Console.WriteLine("5. Estadísticas");
                Console.WriteLine("6. Simular jornada automática");
                Console.WriteLine("7. Simular torneo completo");
                Console.WriteLine("8. Guardar datos");
                Console.WriteLine("9. Cargar datos");
                Console.WriteLine("10. Generar fixture");
                Console.WriteLine("11. Ver fixture");
                Console.WriteLine("12. Simular jornada por número");
                Console.WriteLine("13. Reporte final");
                Console.WriteLine("14. Salir");

                Console.Write("Seleccione opción: ");
                opcion = int.Parse(Console.ReadLine() ?? "0");
                LimpiarConsola();

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nombre del equipo: ");
                        var nombre = Console.ReadLine() ?? "";
                        servicio.RegistrarEquipo(nombre);
                        break;

                    case 2:
                        servicio.ListarEquipos();
                        break;

                    case 3:
                        Console.Write("Equipo 1: ");
                        var e1 = Console.ReadLine() ?? "";

                        Console.Write("Goles equipo 1: ");
                        int g1 = int.Parse(Console.ReadLine() ?? "0");

                        Console.Write("Equipo 2: ");
                        var e2 = Console.ReadLine() ?? "";

                        Console.Write("Goles equipo 2: ");
                        int g2 = int.Parse(Console.ReadLine() ?? "0");

                        servicio.SimularPartido(e1, e2, g1, g2);
                        break;

                    case 4:
                        servicio.MostrarTabla();
                        break;

                    case 5:
                        Console.WriteLine("\n--- ESTADÍSTICAS ---");
                        Console.WriteLine("1. Líder");
                        Console.WriteLine("2. Más goleador");
                        Console.WriteLine("3. Mejor defensa");
                        Console.WriteLine("4. Top 3");

                        Console.Write("Seleccione opción: ");
                        int op = int.Parse(Console.ReadLine() ?? "0");
                        LimpiarConsola();

                        switch (op)
                        {
                            case 1: servicio.ObtenerLider(); break;
                            case 2: servicio.EquipoMasGoleador(); break;
                            case 3: servicio.MejorDefensa(); break;
                            case 4: servicio.Top3(); break;
                        }
                        break;

                    case 6:
                        servicio.SimularJornada();
                        break;

                    case 7:
                        servicio.SimularTodosContraTodos();
                        break;

                    case 8:
                        servicio.GuardarDatos();
                        break;

                    case 9:
                        servicio.CargarDatos();
                        break;
                    case 10:
                        servicio.GenerarFixture();
                        break;

                    case 11:
                        servicio.MostrarFixture();
                        break;

                    case 12:
                        Console.Write("Número de jornada: ");
                        int num = int.Parse(Console.ReadLine() ?? "0");
                        servicio.SimularJornadaFixture(num);
                        break;

                    case 13:
                        servicio.GenerarReporteFinal();
                        break;

                    case 14:
                        break;
                }

                if (opcion != 14)
                {
                    Console.WriteLine();
                    Console.WriteLine("Pulse una tecla para continuar...");
                    Console.ReadKey(intercept: true);
                }

            } while (opcion != 14);
        }
    }
}