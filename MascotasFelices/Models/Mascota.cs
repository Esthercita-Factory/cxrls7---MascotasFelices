namespace MascotasFelices.Models;

public class Mascota
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Raza { get; set; }
    public int Edad { get; set; }
    
    public Mascota(string Nombre, string Raza, int Edad )
    {
        Id = Guid.NewGuid();
        this.Nombre = Nombre.Trim().ToLower();
        this.Raza = Raza.Trim().ToLower();
        this.Edad = Edad;
    }

    public void MostrarDetalles()
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Raza: {Raza}");
        Console.WriteLine($"Edad en Meses: {Edad}");
    }

}

        