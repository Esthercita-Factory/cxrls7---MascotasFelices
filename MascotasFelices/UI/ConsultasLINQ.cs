using MascotasFelices.Models;
using MascotasFelices.Repositories;

namespace MascotasFelices.UI;

/// <summary>
/// Clase que implementa consultas LINQ reales para filtrar, organizar y analizar mascotas
/// </summary>
public static class ConsultasLINQ
{
    // Filtrar mascotas por edad mínima
    public static List<Mascota> FiltrarPorEdadMinima(int edadMinima)
    {
        return MascotaRepositories.Mascotas
            .Where(m => m.Edad >= edadMinima)
            .OrderBy(m => m.Edad)
            .ToList();
    }

    // Filtrar mascotas por raza
    public static List<Mascota> FiltrarPorRaza(string raza)
    {
        return MascotaRepositories.Mascotas
            .Where(m => m.Raza.ToLower().Contains(raza.ToLower()))
            .OrderBy(m => m.Nombre)
            .ToList();
    }

    // Obtener mascotas ordenadas por edad (de menor a mayor)
    public static List<Mascota> OrdenarPorEdadAscendente()
    {
        return MascotaRepositories.Mascotas
            .OrderBy(m => m.Edad)
            .ToList();
    }

    // Obtener mascotas ordenadas por edad (de mayor a menor)
    public static List<Mascota> OrdenarPorEdadDescendente()
    {
        return MascotaRepositories.Mascotas
            .OrderByDescending(m => m.Edad)
            .ToList();
    }

    // Obtener mascotas ordenadas alfabéticamente
    public static List<Mascota> OrdenarAlfabeticamente()
    {
        return MascotaRepositories.Mascotas
            .OrderBy(m => m.Nombre)
            .ToList();
    }

    // Agrupar mascotas por raza
    public static Dictionary<string, List<Mascota>> AgruparPorRaza()
    {
        return MascotaRepositories.Mascotas
            .GroupBy(m => m.Raza)
            .OrderBy(g => g.Key)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Contar mascotas por raza
    public static Dictionary<string, int> ContarPorRaza()
    {
        return MascotaRepositories.Mascotas
            .GroupBy(m => m.Raza)
            .Select(g => new { Raza = g.Key, Cantidad = g.Count() })
            .OrderByDescending(x => x.Cantidad)
            .ToDictionary(x => x.Raza, x => x.Cantidad);
    }

    // Encontrar mascota más joven
    public static Mascota ObtenerMasJoven()
    {
        return MascotaRepositories.Mascotas.Any() 
            ? MascotaRepositories.Mascotas.OrderBy(m => m.Edad).First() 
            : null;
    }

    // Encontrar mascota más vieja
    public static Mascota ObtenerMasVieja()
    {
        return MascotaRepositories.Mascotas.Any()
            ? MascotaRepositories.Mascotas.OrderByDescending(m => m.Edad).First()
            : null;
    }

    // Verificar si existe mascota de una raza específica
    public static bool ExistePorRaza(string raza)
    {
        return MascotaRepositories.Mascotas
            .Any(m => m.Raza.ToLower() == raza.ToLower());
    }

    // Contar total de mascotas
    public static int ContarTotal()
    {
        return MascotaRepositories.Mascotas.Count();
    }

    // Obtener nombres de todas las mascotas en mayúscula
    public static List<string> ObtenerNombresEnMayuscula()
    {
        return MascotaRepositories.Mascotas
            .Select(m => m.Nombre.ToUpper())
            .OrderBy(n => n)
            .ToList();
    }

    // Obtener edad promedio de las mascotas
    public static double ObtenerEdadPromedio()
    {
        return MascotaRepositories.Mascotas.Any()
            ? MascotaRepositories.Mascotas.Average(m => m.Edad)
            : 0;
    }

    // Filtrar mascotas dentro de un rango de edad
    public static List<Mascota> FiltrarPorRangoEdad(int edadMinima, int edadMaxima)
    {
        return MascotaRepositories.Mascotas
            .Where(m => m.Edad >= edadMinima && m.Edad <= edadMaxima)
            .OrderBy(m => m.Edad)
            .ToList();
    }

    // Buscar mascota más similar (por edad) a una edad dada
    public static Mascota BuscarMasSimilarPorEdad(int edad)
    {
        return MascotaRepositories.Mascotas.Any()
            ? MascotaRepositories.Mascotas
                .OrderBy(m => Math.Abs(m.Edad - edad))
                .First()
            : null;
    }

    // Mostrar estadísticas completas de mascotas por raza
    public static void MostrarEstadisticasPorRaza()
    {
        var estadisticas = MascotaRepositories.Mascotas
            .GroupBy(m => m.Raza)
            .Select(g => new
            {
                Raza = g.Key,
                Cantidad = g.Count(),
                EdadPromedio = g.Average(m => m.Edad),
                MasJoven = g.OrderBy(m => m.Edad).First(),
                MasVieja = g.OrderByDescending(m => m.Edad).First()
            })
            .OrderByDescending(x => x.Cantidad)
            .ToList();

        Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
        Console.WriteLine("║        ESTADÍSTICAS DE MASCOTAS POR RAZA            ║");
        Console.WriteLine("╚════════════════════════════════════════════════════╝\n");

        foreach (var stat in estadisticas)
        {
            Console.WriteLine($"  {stat.Raza.ToUpper()}");
            Console.WriteLine($"    Cantidad: {stat.Cantidad}");
            Console.WriteLine($"    Edad Promedio: {stat.EdadPromedio:F1} meses");
            Console.WriteLine($"    Más Joven: {stat.MasJoven.Nombre} ({stat.MasJoven.Edad} meses)");
            Console.WriteLine($"    Más Vieja: {stat.MasVieja.Nombre} ({stat.MasVieja.Edad} meses)");
            Console.WriteLine();
        }
    }

    // Menú de consultas LINQ interactivo
    public static void MostrarMenuConsultas()
    {
        string opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║           CONSULTAS LINQ - BÚSQUEDA Y FILTRO       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝\n");

            Console.WriteLine("  [1] Filtrar mascotas por edad mínima");
            Console.WriteLine("  [2] Filtrar mascotas por raza");
            Console.WriteLine("  [3] Ordenar mascotas por edad (menor a mayor)");
            Console.WriteLine("  [4] Ordenar mascotas por edad (mayor a menor)");
            Console.WriteLine("  [5] Ordenar alfabéticamente");
            Console.WriteLine("  [6] Agrupar por raza");
            Console.WriteLine("  [7] Mascota más joven y más vieja");
            Console.WriteLine("  [8] Estadísticas por raza");
            Console.WriteLine("  [9] Rango de edad");
            Console.WriteLine("  [0] Volver\n");

            Console.Write("  >> Seleccione una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    FiltrarPorEdadMinima_Menu();
                    break;
                case "2":
                    FiltrarPorRaza_Menu();
                    break;
                case "3":
                    MostrarMascotas(OrdenarPorEdadAscendente(), "Mascotas ordenadas por edad (menor a mayor)");
                    break;
                case "4":
                    MostrarMascotas(OrdenarPorEdadDescendente(), "Mascotas ordenadas por edad (mayor a menor)");
                    break;
                case "5":
                    MostrarMascotas(OrdenarAlfabeticamente(), "Mascotas ordenadas alfabéticamente");
                    break;
                case "6":
                    MostrarAgrupadas();
                    break;
                case "7":
                    MostrarExtremos();
                    break;
                case "8":
                    MostrarEstadisticasPorRaza();
                    PausarConsola();
                    break;
                case "9":
                    FiltrarPorRangoEdad_Menu();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("\n✗ Opción no válida.");
                    PausarConsola();
                    break;
            }
        } while (opcion != "0");
    }

    private static void FiltrarPorEdadMinima_Menu()
    {
        Console.Clear();
        Console.Write("\nIngrese edad mínima (en meses): ");
        if (int.TryParse(Console.ReadLine(), out int edad))
        {
            var resultado = FiltrarPorEdadMinima(edad);
            MostrarMascotas(resultado, $"Mascotas con edad mínima {edad} meses");
        }
        else
        {
            Console.WriteLine("Edad inválida.");
        }
        PausarConsola();
    }

    private static void FiltrarPorRaza_Menu()
    {
        Console.Clear();
        Console.Write("\nIngrese raza a buscar: ");
        string raza = Console.ReadLine();
        var resultado = FiltrarPorRaza(raza);
        MostrarMascotas(resultado, $"Mascotas de raza '{raza}'");
        PausarConsola();
    }

    private static void FiltrarPorRangoEdad_Menu()
    {
        Console.Clear();
        Console.Write("\nIngrese edad mínima (en meses): ");
        if (int.TryParse(Console.ReadLine(), out int edadMin))
        {
            Console.Write("Ingrese edad máxima (en meses): ");
            if (int.TryParse(Console.ReadLine(), out int edadMax))
            {
                var resultado = FiltrarPorRangoEdad(edadMin, edadMax);
                MostrarMascotas(resultado, $"Mascotas entre {edadMin} y {edadMax} meses");
            }
        }
        PausarConsola();
    }

    private static void MostrarAgrupadas()
    {
        Console.Clear();
        var grupos = AgruparPorRaza();

        Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
        Console.WriteLine("║           MASCOTAS AGRUPADAS POR RAZA              ║");
        Console.WriteLine("╚════════════════════════════════════════════════════╝\n");

        foreach (var grupo in grupos)
        {
            Console.WriteLine($"  {grupo.Key.ToUpper()} ({grupo.Value.Count} mascotas):");
            foreach (var mascota in grupo.Value.OrderBy(m => m.Nombre))
            {
                Console.WriteLine($"    • {mascota.Nombre} - {mascota.Edad} meses");
            }
            Console.WriteLine();
        }

        PausarConsola();
    }

    private static void MostrarExtremos()
    {
        Console.Clear();
        var masJoven = ObtenerMasJoven();
        var masVieja = ObtenerMasVieja();

        Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
        Console.WriteLine("║           MASCOTAS MÁS Y MENOS JÓVENES             ║");
        Console.WriteLine("╚════════════════════════════════════════════════════╝\n");

        if (masJoven != null)
        {
            Console.WriteLine($"  🐶 Más Joven: {masJoven.Nombre.ToUpper()} ({masJoven.Raza})");
            Console.WriteLine($"     Edad: {masJoven.Edad} meses\n");
        }

        if (masVieja != null)
        {
            Console.WriteLine($"  🐶 Más Vieja: {masVieja.Nombre.ToUpper()} ({masVieja.Raza})");
            Console.WriteLine($"     Edad: {masVieja.Edad} meses\n");
        }

        PausarConsola();
    }

    private static void MostrarMascotas(List<Mascota> mascotas, string titulo)
    {
        Console.Clear();
        Console.WriteLine($"\n╔════════════════════════════════════════════════════╗");
        Console.WriteLine($"║  {titulo,-46}  ║");
        Console.WriteLine($"╚════════════════════════════════════════════════════╝\n");

        if (mascotas.Count == 0)
        {
            Console.WriteLine("  No hay mascotas que coincidan con la búsqueda.");
        }
        else
        {
            Console.WriteLine($"  Total: {mascotas.Count} mascota(s)\n");
            foreach (var mascota in mascotas)
            {
                Console.WriteLine($"  • {mascota.Nombre.ToUpper()} - {mascota.Raza} ({mascota.Edad} meses)");
            }
        }

        PausarConsola();
    }

    private static void PausarConsola()
    {
        Console.WriteLine("\n  Presione Enter para continuar...");
        Console.ReadLine();
    }
}
