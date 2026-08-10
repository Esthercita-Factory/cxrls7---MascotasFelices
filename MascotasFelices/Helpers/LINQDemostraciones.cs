using MascotasFelices.Models;

namespace MascotasFelices.Helpers;

/// <summary>
/// Clase que contiene todas las demostraciones de LINQ para el sistema veterinario.
/// Incluye ejemplos de colecciones, sintaxis de consulta, métodos de LINQ y casos prácticos.
/// </summary>
public static class LINQDemostraciones
{
    // ===== COLECCIONES DE DATOS GLOBALES =====
    private static List<Mascota> mascotas = ObtenerMascotas();
    private static Dictionary<int, Mascota> mascotasPorId = ObtenerMascotasPorId();
    private static Dictionary<string, List<Mascota>> mascotasPorEspecie = ObtenerMascotasPorEspecie();

    public static void MostrarMenuDemostraciones()
    {
        string opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           DEMOSTRACIONES DE LINQ - MENÚ PRINCIPAL          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");
            
            Console.WriteLine("  [1] Tarea 1: Reforzar uso de Colecciones");
            Console.WriteLine("  [2] Tarea 2: Sintaxis de Consulta vs Métodos");
            Console.WriteLine("  [3] Tarea 3: Métodos Fundamentales de LINQ");
            Console.WriteLine("  [4] Tarea 4: Encadenamiento de Consultas");
            Console.WriteLine("  [5] Tarea 5: Problemas Prácticos con LINQ");
            Console.WriteLine("  [6] Ver todas las demostraciones");
            Console.WriteLine("  [0] Volver al menú principal\n");
            
            Console.Write("  >> Seleccione una opción: ");
            opcion = Console.ReadLine() ?? "0";

            switch (opcion)
            {
                case "1":
                    Console.Clear();
                    Tarea1_Colecciones();
                    break;
                case "2":
                    Console.Clear();
                    Tarea2_SintaxisConsultaVsMetodos();
                    break;
                case "3":
                    Console.Clear();
                    Tarea3_MetodosFundamentalesLINQ();
                    break;
                case "4":
                    Console.Clear();
                    Tarea4_EncadenamientoConsultas();
                    break;
                case "5":
                    Console.Clear();
                    Tarea5_ProblemasPracticos();
                    break;
                case "6":
                    Console.Clear();
                    MostrarTodasLasDemostraciones();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("\n✗ Opción no válida. Presione Enter para continuar...");
                    Console.ReadLine();
                    break;
            }
        } while (opcion != "0");
    }

    // ============================================================
    // TAREA 1: REFORZAR USO DE COLECCIONES EN C#
    // ============================================================
    private static void Tarea1_Colecciones()
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║    TAREA 1: REFORZAR USO DE COLECCIONES EN C#             ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");

        // 1. List<Mascota> - Almacenar y manipular mascotas
        Console.WriteLine("1️⃣ List<Mascota> - Almacenar mascotas:");
        Console.WriteLine($"   Total de mascotas: {mascotas.Count}");
        foreach (var mascota in mascotas.Take(3))
        {
            Console.WriteLine($"   • {mascota.Nombre} - {mascota.Especie}");
        }

        // 2. Dictionary<int, Mascota> - Acceso rápido por ID
        Console.WriteLine("\n2️⃣ Dictionary<int, Mascota> - Búsqueda rápida por ID:");
        int idBuscado = 1;
        if (mascotasPorId.TryGetValue(idBuscado, out var mascotaEncontrada))
        {
            Console.WriteLine($"   ✓ ID {idBuscado}: {mascotaEncontrada.Nombre}");
        }

        // 3. Dictionary<string, List<Mascota>> - Agrupar por especie
        Console.WriteLine("\n3️⃣ Dictionary<string, List<Mascota>> - Agrupar por especie:");
        foreach (var especie in mascotasPorEspecie)
        {
            Console.WriteLine($"   • {especie.Key.ToUpper()}: {especie.Value.Count} mascotas");
        }

        // 4. Agregar y eliminar elementos
        Console.WriteLine("\n4️⃣ Operaciones de Agregar/Eliminar:");
        var mascotaLista = mascotas.ToList();
        Console.WriteLine($"   Antes: {mascotaLista.Count} mascotas");
        var nuevaMascota = new Mascota("toby", "golden retriever", "perro", 15, 1, "Carlos", "555-1001");
        mascotaLista.Add(nuevaMascota);
        Console.WriteLine($"   Después de agregar: {mascotaLista.Count} mascotas");
        mascotaLista.Remove(nuevaMascota);
        Console.WriteLine($"   Después de eliminar: {mascotaLista.Count} mascotas");

        PausarConsola();
    }

    // ============================================================
    // TAREA 2: SINTAXIS DE CONSULTA VS SINTAXIS DE MÉTODOS
    // ============================================================
    private static void Tarea2_SintaxisConsultaVsMetodos()
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║   TAREA 2: SINTAXIS DE CONSULTA VS SINTAXIS DE MÉTODOS    ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");

        // EJEMPLO 1: WHERE (Filtrado)
        Console.WriteLine("➤ EJEMPLO 1: WHERE - Filtrar mascotas mayores de 24 meses");
        Console.WriteLine("────────────────────────────────────────────────────────\n");

        Console.WriteLine("Sintaxis de CONSULTA (Query):");
        var consultaMayores24 = from m in mascotas
                                where m.Edad > 24
                                select m;
        foreach (var m in consultaMayores24.Take(3))
        {
            Console.WriteLine($"  • {m.Nombre}: {m.Edad} meses");
        }

        Console.WriteLine("\nSintaxis de MÉTODOS (Method):");
        var metodoMayores24 = mascotas.Where(m => m.Edad > 24).Take(3);
        foreach (var m in metodoMayores24)
        {
            Console.WriteLine($"  • {m.Nombre}: {m.Edad} meses");
        }

        // EJEMPLO 2: SELECT (Proyección)
        Console.WriteLine("\n➤ EJEMPLO 2: SELECT - Proyectar solo nombres");
        Console.WriteLine("──────────────────────────────────────────\n");

        Console.WriteLine("Sintaxis de CONSULTA:");
        var consultaNombres = from m in mascotas
                              select m.Nombre.ToUpper();
        Console.WriteLine($"  {string.Join(" | ", consultaNombres.Take(5))}");

        Console.WriteLine("\nSintaxis de MÉTODOS:");
        var metodoNombres = mascotas.Select(m => m.Nombre.ToUpper()).Take(5);
        Console.WriteLine($"  {string.Join(" | ", metodoNombres)}");

        // EJEMPLO 3: OrderBy y OrderByDescending
        Console.WriteLine("\n➤ EJEMPLO 3: OrderBy/OrderByDescending - Ordenar por edad");
        Console.WriteLine("─────────────────────────────────────────────────────────\n");

        Console.WriteLine("Ordenado ASCENDENTE (menor a mayor):");
        var ordenadoAsc = mascotas.OrderBy(m => m.Edad).Take(4);
        foreach (var m in ordenadoAsc)
        {
            Console.WriteLine($"  • {m.Nombre}: {m.Edad} meses");
        }

        Console.WriteLine("\nOrdenado DESCENDENTE (mayor a menor):");
        var ordenadoDesc = mascotas.OrderByDescending(m => m.Edad).Take(4);
        foreach (var m in ordenadoDesc)
        {
            Console.WriteLine($"  • {m.Nombre}: {m.Edad} meses");
        }

        // EJEMPLO 4: GroupBy (Agrupación)
        Console.WriteLine("\n➤ EJEMPLO 4: GroupBy - Agrupar por especie");
        Console.WriteLine("──────────────────────────────────────────\n");

        var gruposConsulta = from m in mascotas
                             group m by m.Especie into especieGrupo
                             select new { Especie = especieGrupo.Key, Cantidad = especieGrupo.Count() };
        foreach (var grupo in gruposConsulta)
        {
            Console.WriteLine($"  • {grupo.Especie.ToUpper()}: {grupo.Cantidad} mascotas");
        }

        PausarConsola();
    }

    // ============================================================
    // TAREA 3: MÉTODOS FUNDAMENTALES DE LINQ
    // ============================================================
    private static void Tarea3_MetodosFundamentalesLINQ()
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║      TAREA 3: MÉTODOS FUNDAMENTALES DE LINQ               ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");

        // First() - Obtener primer elemento
        Console.WriteLine("➤ First() - Obtener el primer elemento:");
        var primera = mascotas.First();
        Console.WriteLine($"  Primera mascota: {primera.Nombre}\n");

        // FirstOrDefault() - Obtener primero o null
        Console.WriteLine("➤ FirstOrDefault() - Buscar con valor por defecto:");
        var encontrada = mascotas.FirstOrDefault(m => m.Nombre == "max");
        Console.WriteLine($"  Mascota 'max': {(encontrada != null ? encontrada.Nombre : "No encontrada")}\n");

        // Any() - Verificar si existe alguno que cumpla condición
        Console.WriteLine("➤ Any() - Verificar existencia:");
        bool existenPerros = mascotas.Any(m => m.Especie == "perro");
        Console.WriteLine($"  ¿Existen perros?: {(existenPerros ? "SÍ" : "NO")}");
        
        bool existenPajaros = mascotas.Any(m => m.Especie == "pajaro");
        Console.WriteLine($"  ¿Existen pájaros?: {(existenPajaros ? "SÍ" : "NO")}\n");

        // All() - Verificar si todos cumplen condición
        Console.WriteLine("➤ All() - Verificar condición en todos:");
        bool todasTienenNombre = mascotas.All(m => !string.IsNullOrEmpty(m.Nombre));
        Console.WriteLine($"  ¿Todas tienen nombre?: {(todasTienenNombre ? "SÍ" : "NO")}");
        
        bool todosConocidos = mascotas.All(m => m.Edad < 100);
        Console.WriteLine($"  ¿Todas menores de 100 meses?: {(todosConocidos ? "SÍ" : "NO")}\n");

        // Count() - Contar elementos
        Console.WriteLine("➤ Count() - Contar elementos:");
        int totalMascotas = mascotas.Count();
        int totalPerros = mascotas.Count(m => m.Especie == "perro");
        Console.WriteLine($"  Total de mascotas: {totalMascotas}");
        Console.WriteLine($"  Total de perros: {totalPerros}\n");

        PausarConsola();
    }

    // ============================================================
    // TAREA 4: ENCADENAMIENTO DE CONSULTAS LINQ
    // ============================================================
    private static void Tarea4_EncadenamientoConsultas()
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║    TAREA 4: ENCADENAMIENTO DE CONSULTAS LINQ              ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");

        // EJEMPLO 1: Filtrar → Ordenar → Proyectar
        Console.WriteLine("➤ EJEMPLO 1: Perros ordenados por edad (filtro → orden → proyección)");
        Console.WriteLine("──────────────────────────────────────────────────────────────────\n");

        var perrosOrdenados = mascotas
            .Where(m => m.Especie == "perro")      // Filtrar perros
            .OrderBy(m => m.Edad)                   // Ordenar por edad
            .Select(m => new { m.Nombre, m.Edad }) // Proyectar solo nombre y edad
            .ToList();

        foreach (var p in perrosOrdenados)
        {
            Console.WriteLine($"  🐕 {p.Nombre}: {p.Edad} meses");
        }

        // EJEMPLO 2: Agrupar → Contar → Proyectar
        Console.WriteLine("\n➤ EJEMPLO 2: Estadísticas de mascotas por especie");
        Console.WriteLine("─────────────────────────────────────────────────\n");

        var estadisticas = mascotas
            .GroupBy(m => m.Especie)
            .Select(g => new
            {
                Especie = g.Key.ToUpper(),
                Cantidad = g.Count(),
                PromedioEdad = g.Average(m => m.Edad)
            })
            .OrderByDescending(x => x.Cantidad)
            .ToList();

        foreach (var stat in estadisticas)
        {
            Console.WriteLine($"  {stat.Especie}: {stat.Cantidad} mascotas (edad promedio: {stat.PromedioEdad:F1} meses)");
        }

        // EJEMPLO 3: Filtrar → Filtrar → Ordenar
        Console.WriteLine("\n➤ EJEMPLO 3: Mascotas adultas ordenadas alfabéticamente");
        Console.WriteLine("────────────────────────────────────────────────────\n");

        var mascotasAdultas = mascotas
            .Where(m => m.Edad >= 24)           // Mayores de 24 meses
            .Where(m => m.Edad < 60)            // Menores de 60 meses
            .OrderBy(m => m.Nombre)             // Ordenar alfabéticamente
            .ToList();

        Console.WriteLine($"  Mascotas adultas ({mascotasAdultas.Count}):");
        foreach (var m in mascotasAdultas)
        {
            Console.WriteLine($"  • {m.Nombre} ({m.Edad} meses)");
        }

        PausarConsola();
    }

    // ============================================================
    // TAREA 5: PROBLEMAS PRÁCTICOS RESUELTOS CON LINQ
    // ============================================================
    private static void Tarea5_ProblemasPracticos()
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║    TAREA 5: PROBLEMAS PRÁCTICOS RESUELTOS CON LINQ        ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");

        // PROBLEMA 1: Encontrar mascota más joven y más vieja
        Console.WriteLine("✓ PROBLEMA 1: Mascota más joven y más vieja");
        Console.WriteLine("───────────────────────────────────────────\n");

        var mascotaMasJoven = mascotas.OrderBy(m => m.Edad).First();
        var mascotaMasVieja = mascotas.OrderByDescending(m => m.Edad).First();

        Console.WriteLine($"  Más joven: {mascotaMasJoven.Nombre} ({mascotaMasJoven.Edad} meses)");
        Console.WriteLine($"  Más vieja: {mascotaMasVieja.Nombre} ({mascotaMasVieja.Edad} meses)");

        // PROBLEMA 2: Contar mascotas por especie
        Console.WriteLine("\n✓ PROBLEMA 2: Contar mascotas por especie");
        Console.WriteLine("────────────────────────────────────────\n");

        var conteos = mascotas
            .GroupBy(m => m.Especie)
            .Select(g => new { Especie = g.Key.ToUpper(), Cantidad = g.Count() })
            .OrderByDescending(x => x.Cantidad);

        foreach (var item in conteos)
        {
            Console.WriteLine($"  {item.Especie}: {item.Cantidad}");
        }

        // PROBLEMA 3: Verificar si existe mascota sin raza definida
        Console.WriteLine("\n✓ PROBLEMA 3: ¿Existen mascotas sin raza definida?");
        Console.WriteLine("──────────────────────────────────────────────────\n");

        bool existeSinRaza = mascotas.Any(m => m.Raza == "desconocida");
        Console.WriteLine($"  Resultado: {(existeSinRaza ? "SÍ" : "NO")} existen mascotas sin raza definida");

        // PROBLEMA 4: Nombres en mayúsculas, ordenados alfabéticamente
        Console.WriteLine("\n✓ PROBLEMA 4: Nombres en MAYÚSCULAS, alfabéticamente");
        Console.WriteLine("──────────────────────────────────────────────────\n");

        var nombresOrdenados = mascotas
            .OrderBy(m => m.Nombre)
            .Select(m => m.Nombre.ToUpper())
            .ToList();

        Console.WriteLine($"  {string.Join(" | ", nombresOrdenados)}");

        // PROBLEMA 5: Mascota con el dueño más específico
        Console.WriteLine("\n✓ PROBLEMA 5: Mascotas por dueño");
        Console.WriteLine("────────────────────────────────\n");

        var mascotasPorDueno = mascotas
            .Where(m => !string.IsNullOrEmpty(m.Dueno))
            .GroupBy(m => m.Dueno)
            .Select(g => new { Dueno = g.Key, Cantidad = g.Count(), Mascotas = g.Select(m => m.Nombre).ToList() })
            .OrderByDescending(x => x.Cantidad)
            .ToList();

        foreach (var item in mascotasPorDueno.Take(3))
        {
            Console.WriteLine($"  {item.Dueno}: {item.Cantidad} mascota(s)");
            foreach (var mascota in item.Mascotas)
            {
                Console.WriteLine($"    • {mascota}");
            }
        }

        PausarConsola();
    }

    // ============================================================
    // MÉTODO AUXILIAR: MOSTRAR TODAS LAS DEMOSTRACIONES
    // ============================================================
    private static void MostrarTodasLasDemostraciones()
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║   TODAS LAS DEMOSTRACIONES - COLECCIONES Y LINQ           ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");

        Tarea1_Colecciones();
        Tarea2_SintaxisConsultaVsMetodos();
        Tarea3_MetodosFundamentalesLINQ();
        Tarea4_EncadenamientoConsultas();
        Tarea5_ProblemasPracticos();
    }

    // ============================================================
    // MÉTODOS AUXILIARES DE DATOS
    // ============================================================

    /// <summary>
    /// Crea y retorna una lista de mascotas de ejemplo para las demostraciones.
    /// </summary>
    private static List<Mascota> ObtenerMascotas()
    {
        return new()
        {
            new Mascota("max", "labrador", "perro", 24, 1, "Carlos", "555-1001", "Vacunación"),
            new Mascota("luna", "siamés", "gato", 36, 1, "Carlos", "555-1001", "Revisión"),
            new Mascota("buddy", "pastor alemán", "perro", 18, 2, "Maria", "555-1002", "Desparasitación"),
            new Mascota("whiskers", "persa", "gato", 48, 2, "Maria", "555-1002", "Limpieza dental"),
            new Mascota("rocky", "boxer", "perro", 12, 3, "Juan", "555-1003", "Vacunación"),
            new Mascota("felix", "bengalí", "gato", 24, 3, "Juan", "555-1003", "Revisión"),
            new Mascota("cooper", "poodle", "perro", 30, 4, "Ana", "555-1004", "Cirugía"),
            new Mascota("princess", "maine coon", "gato", 42, 4, "Ana", "555-1004", "Seguimiento"),
            new Mascota("spike", "bulldog", "perro", 60, 5, "Roberto", "555-1005", "Artritis"),
            new Mascota("mittens", "tabby", "gato", 18, 5, "Roberto", "555-1005", "Vacunación")
        };
    }

    /// <summary>
    /// Crea un diccionario de mascotas indexado por ID para búsqueda rápida.
    /// </summary>
    private static Dictionary<int, Mascota> ObtenerMascotasPorId()
    {
        var mascotas = ObtenerMascotas();
        var diccionario = new Dictionary<int, Mascota>();
        
        for (int i = 0; i < mascotas.Count; i++)
        {
            diccionario[i + 1] = mascotas[i];
        }
        
        return diccionario;
    }

    /// <summary>
    /// Crea un diccionario de mascotas agrupadas por especie.
    /// </summary>
    private static Dictionary<string, List<Mascota>> ObtenerMascotasPorEspecie()
    {
        return ObtenerMascotas()
            .GroupBy(m => m.Especie)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    /// <summary>
    /// Pausa la consola para que el usuario lea los resultados.
    /// </summary>
    private static void PausarConsola()
    {
        Console.WriteLine("\n\nPresione Enter para continuar...");
        Console.ReadLine();
    }
}
