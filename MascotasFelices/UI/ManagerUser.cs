namespace MascotasFelices.UI;

public class ManagerUser
{
    public static void MostraMenu()
    {
        Console.WriteLine("╔════════════════════════════════════════════════╗");
        Console.WriteLine("║      CLINICA VETERINARIA PATITAS FELICES       ║");
        Console.WriteLine("║         Sistema de Gestion de Mascotas         ║");
        Console.WriteLine("╠════════════════════════════════════════════════╣");
        Console.WriteLine("║                                                ║");
        Console.WriteLine("║  [1]  Registrar una nueva mascota              ║");
        Console.WriteLine("║  [2]  Listar las mascotas registradas          ║");
        Console.WriteLine("║  [3]  Buscar una mascota                       ║");
        Console.WriteLine("║  [4]  Editar una mascota                       ║");
        Console.WriteLine("║  [5]  Eliminar una mascota                     ║");
        Console.WriteLine("║                                                ║");
        Console.WriteLine("║  [6]  🔍 Consultar y Filtrar (LINQ)            ║");
        Console.WriteLine("║                                                ║");
        Console.WriteLine("║  [7]  Registrar un nuevo paciente              ║");
        Console.WriteLine("║  [8]  Listar los pacientes registrados         ║");
        Console.WriteLine("║  [9]  Buscar un paciente                       ║");
        Console.WriteLine("║  [10] Editar un paciente                       ║");
        Console.WriteLine("║  [11] Eliminar un paciente                     ║");
        Console.WriteLine("║  [12] Asociar mascota a un paciente            ║");
        Console.WriteLine("║  [13] Ver ficha completa de una mascota        ║");
        Console.WriteLine("║  [14] Atender mascota (servicio veterinario)   ║");
        Console.WriteLine("║  [15] Ver registro de actividad del sistema    ║");
        Console.WriteLine("║  [16] Registrar mascota (async)                ║");
        Console.WriteLine("║  [17] Procesar llegada de mascota (paralelo)   ║");
        Console.WriteLine("║  [18] Registro masivo de mascotas (paralelo)   ║");
        Console.WriteLine("║  [19] Comparar WhenAll vs WhenAny              ║");
        Console.WriteLine("║                                                ║");
        Console.WriteLine("║  [0]  Salir del sistema                        ║");
        Console.WriteLine("╚════════════════════════════════════════════════╝");
        Console.WriteLine();
        Console.Write("  >> Seleccione una opcion: ");
    }
}