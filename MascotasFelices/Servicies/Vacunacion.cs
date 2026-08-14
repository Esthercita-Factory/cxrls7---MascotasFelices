using MascotasFelices.Models;

namespace MascotasFelices.Services;

public class Vacunacion : ServicioVeterinario
{
    public string TipoVacuna { get; set; }

    public Vacunacion(Mascota mascotaAtendida, string tipoVacuna) : base("Vacunacion", mascotaAtendida)
    {
        TipoVacuna = tipoVacuna;
    }

    public override void Atender()
    {
        Console.WriteLine($" Aplicando {NombreServicio} ({TipoVacuna}) a {MascotaAtendida.Nombre}...");
        Console.WriteLine($"   {MascotaAtendida.Nombre} ha sido vacunado(a) correctamente.");
    }
}