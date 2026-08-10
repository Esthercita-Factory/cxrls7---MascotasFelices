namespace MascotasFelices.Models;

/// <summary>
/// Modelo que representa una mascota (paciente) en la clínica veterinaria.
/// Nota: En este contexto, "Mascota" es el paciente de la clínica.
/// </summary>
public class Mascota
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Raza { get; set; }
    public string Especie { get; set; }
    public int Edad { get; set; }
    public int PacienteId { get; set; }
    public string Dueno { get; set; }
    public string Telefono { get; set; }
    public string Sintoma { get; set; }
    
    // Constructor principal con todas las propiedades
    public Mascota(string nombre, string raza, string especie, int edad, int pacienteId = 0, 
                   string dueno = "", string telefono = "", string sintoma = "")
    {
        Id = Guid.NewGuid();
        this.Nombre = nombre.Trim().ToLower();
        this.Raza = raza.Trim().ToLower();
        this.Especie = especie.Trim().ToLower();
        this.Edad = edad;
        this.PacienteId = pacienteId;
        this.Dueno = dueno.Trim();
        this.Telefono = telefono.Trim();
        this.Sintoma = sintoma.Trim();
    }

    // Constructor alternativo para compatibilidad con código existente
    public Mascota(string nombre, string raza, int edad)
    {
        Id = Guid.NewGuid();
        this.Nombre = nombre.Trim().ToLower();
        this.Raza = raza.Trim().ToLower();
        this.Edad = edad;
        this.Especie = "desconocida";
        this.PacienteId = 0;
        this.Dueno = "";
        this.Telefono = "";
        this.Sintoma = "";
    }

    public void MostrarDetalles()
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Especie: {Especie}");
        Console.WriteLine($"Raza: {Raza}");
        Console.WriteLine($"Edad en Meses: {Edad}");
        if (!string.IsNullOrEmpty(Dueno))
            Console.WriteLine($"Dueño: {Dueno}");
        if (!string.IsNullOrEmpty(Sintoma))
            Console.WriteLine($"Síntoma: {Sintoma}");
    }

    public override string ToString()
    {
        return $"{Nombre} ({Especie}) - Raza: {Raza}";
    }

}
        