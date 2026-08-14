using MascotasFelices.Models;

namespace MascotasFelices.Services;

public abstract class ServicioVeterinario
{
    public string NombreServicio { get; set; }
    public Mascota MascotaAtendida { get; set; }
    public DateTime Fecha { get; set; }

    protected ServicioVeterinario(string nombreServicio, Mascota mascotaAtendida)
    {
        NombreServicio = nombreServicio;
        MascotaAtendida = mascotaAtendida;
        Fecha = DateTime.Now;
    }

    public abstract void Atender();
}