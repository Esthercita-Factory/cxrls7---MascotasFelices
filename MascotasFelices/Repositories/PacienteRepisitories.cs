using MascotasFelices.Models;

namespace MascotasFelices.Repositories;

public static class PacienteRepositories
{
    public static List<Paciente> Pacientes { get; set; }

    static PacienteRepositories()
    {
        var paciente1 = new Paciente("Carlos Ramirez", 34, "Av. Siempre Viva 123", "0991234567");
        paciente1.AgregarMascota(new Mascota("Firulais", "perro", "Criollo", 36));

        var paciente2 = new Paciente("Maria Lopez", 28, "Calle Los Pinos 45", "0987654321");
        paciente2.AgregarMascota(new Mascota("Michi", "gato", "Siames", 24));

        Pacientes =
        [
            paciente1,
            paciente2,
        ];
    }

    // CREATE
    public static void RegistrarPaciente(Paciente pacienteNuevo)
    {
        Pacientes.Add(pacienteNuevo);
    }

    // READ
    public static List<Paciente> ListPacientes()
    {
        return Pacientes;
    }

    // SEARCH
    public static List<Paciente> BuscarPaciente(string nombre)
    {
        return Pacientes.Where(p => p.Nombre.ToLower().Contains(nombre.ToLower())).ToList();
    }

    // EDIT
    public static Paciente EditarPaciente(string nombre)
    {
        foreach (var paciente in Pacientes)
        {
            if (paciente.Nombre.ToLower() == nombre.ToLower())
            {
                return paciente;
            }
        }

        return null;
    }

    // DELETE
    public static void EliminarPaciente(Paciente paciente)
    {
        Pacientes.Remove(paciente);
    }
}