using MascotasFelices.Interfaces;
using MascotasFelices.Services;

namespace MascotasFelices.Models;

public class Mascota : Animal, IRegistrable
{
    public string Raza { get; set; }
    public Paciente Dueño { get; set; }
    public List<ServicioVeterinario> HistorialAtenciones { get; set; } = new();

    public Mascota(string nombre, string especie, string raza, int edad, Paciente dueño = null)
        : base(nombre, especie, edad)
    {
        Raza = raza.Trim().ToLower();
        Dueño = dueño;
    }
    

    public override void EmitirSonido()
    {
        switch (Especie)
        {
            case "perro":
                Console.WriteLine($"{Nombre} dice: ¡Guau Guau!");
                break;
            case "gato":
                Console.WriteLine($"{Nombre} dice: ¡Miau!");
                break;
            case "ave":
                Console.WriteLine($"{Nombre} dice: ¡Pio Pio!");
                break;
            case "conejo":
                Console.WriteLine($"{Nombre} no hace mucho ruido, pero mueve la naricita.");
                break;
            default:
                base.EmitirSonido();
                break;
        }
    }

    public override void MostrarDetalles()
    {
        base.MostrarDetalles();
        Console.WriteLine($"Raza: {Raza}");
        Console.WriteLine($"Dueño: {(Dueño != null ? Dueño.Nombre : "Sin asignar")}");
    }

    public void Registrar()
    {
        Console.WriteLine($"✔ Mascota '{Nombre}' registrada correctamente en el sistema.");
    }
}