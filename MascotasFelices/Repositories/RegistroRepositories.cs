using MascotasFelices.Models;

namespace MascotasFelices.Repositories;

public static class RegistroRepositories
{
    public static List<RegistroActividad> Registros { get; set; } = new();

    public static void Agregar(string mensaje)
    {
        Registros.Add(new RegistroActividad(mensaje));
    }

    public static List<RegistroActividad> ListRegistros()
    {
        return Registros.OrderByDescending(r => r.Fecha).ToList();
    }
}