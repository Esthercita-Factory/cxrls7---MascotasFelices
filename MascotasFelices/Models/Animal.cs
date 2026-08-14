namespace MascotasFelices.Models;

public class Animal
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Especie { get; set; }
    public int Edad { get; set; }

    public Animal(string nombre, string especie, int edad)
    {
        Id = Guid.NewGuid();
        Nombre = nombre.Trim().ToLower();
        Especie = especie.Trim().ToLower();
        Edad = edad;
    }

    
    public virtual void EmitirSonido()
    {
        Console.WriteLine($"{Nombre} emite un sonido generico de animal.");
    }

    public virtual void MostrarDetalles()
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Especie: {Especie}");
        Console.WriteLine($"Edad en Meses: {Edad}");
    }
}