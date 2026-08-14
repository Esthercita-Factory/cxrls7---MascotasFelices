using MascotasFelices.Models;

namespace MascotasFelices.Services;

public class ConsultaGeneral : ServicioVeterinario
{
    public ConsultaGeneral(Mascota mascotaAtendida) : base("Consulta General", mascotaAtendida)
    {
    }

    public override void Atender()
    {
        Console.WriteLine($"🩺 Realizando {NombreServicio} a {MascotaAtendida.Nombre}...");
        Console.WriteLine($"   Se revisan signos vitales, peso y estado general de {MascotaAtendida.Nombre}.");
    }
}