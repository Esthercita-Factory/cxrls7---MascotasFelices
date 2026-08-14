namespace MascotasFelices.Models;

public class RegistroActividad
{
    public DateTime Fecha { get; set; }
    public string Mensaje { get; set; }

    public RegistroActividad(string mensaje)
    {
        Fecha = DateTime.Now;
        Mensaje = mensaje;
    }
}