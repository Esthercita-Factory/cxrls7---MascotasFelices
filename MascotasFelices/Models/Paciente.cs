using MascotasFelices.Interfaces;

namespace MascotasFelices.Models;

public class Paciente : IRegistrable
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Direccion { get; set; }

    private string telefono;
    public string Telefono
    {
        get => telefono;
        private set => telefono = value;
    }

    public List<Mascota> Mascotas { get; set; }

    public Paciente(string nombre, int edad, string direccion, string telefono)
    {
        Id = Guid.NewGuid();
        Nombre = nombre.Trim().ToLower();
        Edad = edad;
        Direccion = direccion.Trim().ToLower();
        this.telefono = telefono.Trim();
        Mascotas = new List<Mascota>();
    }

  
    public void ActualizarTelefono(string nuevoTelefono)
    {
        telefono = nuevoTelefono.Trim();
    }

  
    public void AgregarMascota(Mascota mascota)
    {
        mascota.Dueño = this;
        Mascotas.Add(mascota);
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Edad: {Edad} años");
        Console.WriteLine($"Direccion: {Direccion}");
        Console.WriteLine($"Telefono: {OcultarTelefono()}");
        Console.WriteLine($"Cantidad de mascotas: {Mascotas.Count}");

        if (Mascotas.Count > 0)
        {
            Console.WriteLine("Mascotas asociadas:");
            foreach (var mascota in Mascotas)
            {
                Console.WriteLine($"   - {mascota.Nombre} ({mascota.Especie} - {mascota.Raza})");
            }
        }
    }

    private string OcultarTelefono()
    {
        if (string.IsNullOrEmpty(telefono) || telefono.Length < 4)
            return "****";

        return new string('*', telefono.Length - 4) + telefono.Substring(telefono.Length - 4);
    }

    public void Registrar()
    {
        Console.WriteLine($"✔ Paciente '{Nombre}' registrado correctamente en el sistema.");
    }
}