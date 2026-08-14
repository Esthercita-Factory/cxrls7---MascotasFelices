using MascotasFelices.Models;
using MascotasFelices.Repositories;
using MascotasFelices.Services;

namespace MascotasFelices.UI;

public class ManagerPacientes
{
    private static int LeerEnteroIntParse(string mensaje)
    {
        while (true)
        {
            try
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                return int.Parse(entrada);
            }
            catch (FormatException)
            {
                Console.WriteLine("⚠️ Entrada inválida. Ingrese un número entero.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("⚠️ El número ingresado es demasiado grande. Intente de nuevo.");
            }
        }
    }

    public static void CrearUnPaciente()
    {
        try
        {
            Console.WriteLine("-----------AGREGAR PACIENTE-----------");

            Console.Write("\n-Ingrese el nombre del paciente: ");
            var nombre = Console.ReadLine();

            var edad = LeerEnteroIntParse("\n-Ingrese la edad del paciente: ");

            Console.Write("\n-Ingrese la direccion del paciente: ");
            var direccion = Console.ReadLine();

            Console.Write("\n-Ingrese el telefono del paciente: ");
            var telefono = Console.ReadLine();

            var pacienteNuevo = new Paciente(nombre, edad, direccion, telefono);
            PacienteRepositories.RegistrarPaciente(pacienteNuevo);
            pacienteNuevo.Registrar();
            RegistroRepositories.Agregar($"Paciente '{nombre}' registrado en el sistema.");

            Console.WriteLine($"\nPaciente {nombre} agregado con exito.");
            Console.Write("\nDesea agregar otro paciente(si/no): ");
            var agregarOtro = Console.ReadLine();

            if (agregarOtro == "si")
            {
                Console.Clear();
                CrearUnPaciente();
            }
            else
            {
                Console.Clear();
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("\nIngresa el formato correcto");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    public static void MostrarTodosLosPacientes()
    {
        try
        {
            Console.Clear();
            var pacientesLista = PacienteRepositories.ListPacientes();
            Console.WriteLine("----------LISTADO DE PACIENTES-----------");

            if (pacientesLista.Count == 0)
            {
                Console.WriteLine("\nNo hay pacientes registrados.");
            }
            else
            {
                foreach (var paciente in pacientesLista)
                {
                    Console.WriteLine();
                    paciente.MostrarInformacion();
                    Console.WriteLine("-------------------------------");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nOcurrió un error al mostrar los pacientes: {ex.Message}");
        }
        finally
        {
            Console.Write("\nPresione cualquier tecla para regresar al menú principal...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    public static void BuscarPaciente()
    {
        try
        {
            Console.WriteLine("-------BUSQUEDAS PACIENTES--------");
            Console.Write("\n-Ingrese el nombre del paciente a buscar: ");
            var nombre = Console.ReadLine();

            var resultados = PacienteRepositories.BuscarPaciente(nombre);

            if (resultados.Count == 0)
            {
                Console.WriteLine("\nNo se encontró ningún paciente con ese nombre.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("--- PACIENTES ENCONTRADOS ---");
                foreach (var paciente in resultados)
                {
                    Console.WriteLine();
                    paciente.MostrarInformacion();
                }
            }

            Console.Write("\n¿Desea hacer otra busqueda?(si/no): ");
            var buscarOtra = Console.ReadLine();

            if (buscarOtra == "si")
            {
                Console.Clear();
                BuscarPaciente();
            }
            else
            {
                Console.Clear();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nOcurrió un error durante la búsqueda: {ex.Message}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    public static void EditarPaciente()
    {
        try
        {
            Console.WriteLine("----------EDITAR PACIENTE----------");
            Console.Write("-Ingrese el nombre del paciente a editar: ");
            var nombreBuscar = Console.ReadLine();

            var paciente = PacienteRepositories.EditarPaciente(nombreBuscar);

            if (paciente == null)
            {
                Console.WriteLine("\nNo se encontró ningún paciente con ese nombre.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("--- Ingrese los nuevos datos ---");

                Console.Write("-Nuevo nombre: ");
                paciente.Nombre = Console.ReadLine();

                paciente.Edad = LeerEnteroIntParse("-Nueva edad: ");

                Console.Write("-Nueva direccion: ");
                paciente.Direccion = Console.ReadLine();

                Console.Write("-Nuevo telefono: ");
                paciente.ActualizarTelefono(Console.ReadLine());

                Console.WriteLine("\n¡Paciente editado con éxito!");
            }

            Console.Write("\n¿Desea editar otro paciente?(si/no): ");

            if (Console.ReadLine() == "si")
            {
                Console.Clear();
                EditarPaciente();
            }
            else
            {
                Console.Clear();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nOcurrió un error al editar el paciente: {ex.Message}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    public static void EliminarPaciente()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("---------- ELIMINAR PACIENTE ----------");
            Console.Write("-Ingrese el nombre del paciente a eliminar: ");
            var nombreBuscar = Console.ReadLine();

            var paciente = PacienteRepositories.EditarPaciente(nombreBuscar);

            if (paciente == null)
            {
                Console.WriteLine("\nNo se encontró ningún paciente con ese nombre.");
            }
            else
            {
                PacienteRepositories.EliminarPaciente(paciente);
                Console.WriteLine($"\n¡El paciente '{paciente.Nombre}' fue eliminado con éxito!");
            }

            Console.Write("\n¿Desea eliminar otro paciente?(si/no): ");

            if (Console.ReadLine() == "si")
            {
                Console.Clear();
                EliminarPaciente();
            }
            else
            {
                Console.Clear();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nOcurrió un error al eliminar el paciente: {ex.Message}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }


    public static void AsociarMascotaAPaciente()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("---------- ASOCIAR MASCOTA A PACIENTE ----------");
            Console.Write("-Ingrese el nombre del paciente: ");
            var nombrePaciente = Console.ReadLine();

            var paciente = PacienteRepositories.EditarPaciente(nombrePaciente);

            if (paciente == null)
            {
                Console.WriteLine("\nNo se encontró ningún paciente con ese nombre.");
            }
            else
            {
                Console.Write("\n-Ingrese el nombre de la mascota que desea asociar: ");
                var nombreMascota = Console.ReadLine();

                var mascota = MascotaRepositories.EditarMascota(nombreMascota);

                if (mascota == null)
                {
                    Console.WriteLine("\nNo se encontró ninguna mascota con ese nombre.");
                }
                else
                {
                    paciente.AgregarMascota(mascota);
                    RegistroRepositories.Agregar($"Mascota '{mascota.Nombre}' asociada al paciente '{paciente.Nombre}'.");
                    Console.WriteLine($"\n✔ La mascota '{mascota.Nombre}' fue asociada al paciente '{paciente.Nombre}'.");
           
                }
            }

            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nOcurrió un error al asociar la mascota: {ex.Message}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

 
    
    public static void AtenderMascota()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("---------- ATENDER MASCOTA ----------");
            Console.Write("-Ingrese el nombre de la mascota a atender: ");
            var nombreMascota = Console.ReadLine();

            var mascota = MascotaRepositories.EditarMascota(nombreMascota);

            if (mascota == null)
            {
                Console.WriteLine("\nNo se encontró ninguna mascota con ese nombre.");
            }
            else
            {
                Console.WriteLine("\n[1] Consulta General");
                Console.WriteLine("[2] Vacunacion");
                Console.Write("\nSeleccione el tipo de servicio: ");
                var opcion = Console.ReadLine();

                ServicioVeterinario servicio;

                if (opcion == "2")
                {
                    Console.Write("-Ingrese el tipo de vacuna: ");
                    var tipoVacuna = Console.ReadLine();
                    servicio = new Vacunacion(mascota, tipoVacuna);
                }
                else
                {
                    servicio = new ConsultaGeneral(mascota);
                }

                Console.WriteLine();
                servicio.Atender(); // se llama el metodo abstracto, la clase real decide el comportamiento
            }

            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nOcurrió un error al atender la mascota: {ex.Message}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    public static void VerRegistroActividad()
    {
        Console.Clear();
        Console.WriteLine("---------- REGISTRO DE ACTIVIDAD DEL SISTEMA ----------\n");

        var registros = RegistroRepositories.ListRegistros();

        if (registros.Count == 0)
        {
            Console.WriteLine("Aun no hay actividad registrada.");
        }
        else
        {
            foreach (var registro in registros)
            {
                Console.WriteLine($"  [{registro.Fecha:dd/MM/yyyy HH:mm:ss}] {registro.Mensaje}");
            }
        }

        Console.Write("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }
}