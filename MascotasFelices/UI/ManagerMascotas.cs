using MascotasFelices.Models;
using MascotasFelices.Repositories;

namespace MascotasFelices.UI;

public class ManagerMascotas
{
        
    private static int LeerEdadIntParse()
    {
        while (true)
        {
            try
            {
                string entrada = Console.ReadLine();
                return int.Parse(entrada);
            }
            catch (FormatException)
            {
                Console.Write("⚠️ Entrada inválida. Ingrese un número entero para la edad: ");
            }
            catch (OverflowException)
            {
                Console.Write("⚠️ El número ingresado es demasiado grande. Intente de nuevo: ");
            }
        }
    }

    public static void CrearUnaMascota()
    {
        try
        {
            Console.WriteLine("-----------AGREGAR MASCOTAS-----------");

            Console.Write("\n-Ingrese el nombre de la mascota a agregar: ");
            var nombre = Console.ReadLine();

            Console.Write("\n-Ingrese la especie de la mascota (perro/gato/ave/etc): ");
            var especie = Console.ReadLine();

            Console.Write("\n-Ingrese la raza de la mascota a agregar: ");
            var raza = Console.ReadLine();

            Console.Write("\n-Ingrese la edad (en meses) de la mascota a agregar: ");
            var edad = LeerEdadIntParse();


            var mascotaNueva = new Mascota(nombre, especie, raza, edad);
            MascotaRepositories.RegistrarMascota(mascotaNueva);
            mascotaNueva.Registrar();
            RegistroRepositories.Agregar($"Mascota '{nombre}' ({especie}) registrada en el sistema.");

            Console.WriteLine($"\nMascota {nombre} agregada con exito.");
            Console.Write("\nDesea agregar otra mascota(si/no): ");
            var agregarOtra = Console.ReadLine();

            if (agregarOtra == "si")
            {
                Console.Clear();
                CrearUnaMascota();
            }
            else
            {
                Console.Clear();
            }
        }
        catch (FormatException)
        {
            Console.WriteLine($"\nIngresa el formato correcto");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    public static void MostrarTodasLasMascotas()
    {
        try
        {
            Console.Clear();
            var mascotasLista = MascotaRepositories.ListMascotas();
            Console.WriteLine("----------LISTADO DE MASCOTAS-----------");

            if (mascotasLista.Count == 0)
            {
                Console.WriteLine("\nNo hay mascotas registradas.");
            }
            else
            {
                foreach (var mascotas in mascotasLista)
                {
                    Console.WriteLine($"\n{mascotas.Nombre} - {mascotas.Raza}");
                    Console.WriteLine("-------------------------------");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nOcurrió un error al mostrar las mascotas: {ex.Message}");
        }
        finally
        {
            Console.Write("\nPresione cualquier tecla para regresar al menú principal...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    public static void BuscarMascota()
    {
        try
        {
            Console.WriteLine("-------BUSQUEDAS MASCOTAS--------");
            Console.Write("\n-Ingrese el nombre de la mascota a buscar: ");
            var nombre = Console.ReadLine();

            var resultados = MascotaRepositories.BuscarMascota(nombre);

            if (resultados.Count == 0)
            {
                Console.WriteLine("\nNo se encontró ninguna mascota con ese nombre.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("--- MASCOTAS ENCONTRADAS ---");
                foreach (var mascota in resultados)
                {
                    Console.WriteLine($"\n- {mascota.Nombre} - {mascota.Raza} - ({mascota.Edad} meses)");
                }
            }

            Console.Write("\n¿Desea hacer otra busqueda?(si/no): ");
            var buscarOtra = Console.ReadLine();

            if (buscarOtra == "si")
            {
                Console.Clear();
                BuscarMascota();
            }
            else
            {
                Console.Clear();
            }

            Console.Clear();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nOcurrió un error durante la búsqueda: {ex.Message}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    public static void EditarMascota()
    {
        try
        {
            Console.WriteLine("----------EDITAR MASCOTA----------");
            Console.Write("-Ingrese el nombre de la mascota a editar: ");
            var nombreBuscar = Console.ReadLine();

            var mascota = MascotaRepositories.EditarMascota(nombreBuscar);

            if (mascota == null)
            {
                Console.WriteLine("\nNo se encontró ninguna mascota con ese nombre.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("--- Ingrese los nuevos datos ---");

                Console.Write("-Nuevo nombre: ");
                var nuevoNombre = Console.ReadLine();

                Console.Write("-Nueva especie: ");
                var nuevaEspecie = Console.ReadLine();

                Console.Write("-Nueva raza: ");
                var nuevaRaza = Console.ReadLine();

                Console.Write("-Nueva edad (en meses): ");
                var nuevaEdad = LeerEdadIntParse();

                mascota.Nombre = nuevoNombre;
                mascota.Especie = nuevaEspecie;
                mascota.Raza = nuevaRaza;
                mascota.Edad = nuevaEdad;

                Console.WriteLine("\n¡Mascota editada con éxito!");
            }

            Console.Write("\n¿Desea editar otra mascota?(si/no): ");

            if (Console.ReadLine() == "si")
            {
                Console.Clear();
                EditarMascota();
            }
            else 
            {
                Console.Clear();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nOcurrió un error al editar la mascota: {ex.Message}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
    public static void EliminarMascota()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("---------- ELIMINAR MASCOTA ----------");
            Console.Write("-Ingrese el nombre de la mascota a eliminar: ");
            var nombreBuscar = Console.ReadLine();

            var mascota = MascotaRepositories.EditarMascota(nombreBuscar);

            if (mascota == null)
            {
                Console.WriteLine("\nNo se encontró ninguna mascota con ese nombre.");
            }
            else
            {
                MascotaRepositories.EliminarMascota(mascota);
                Console.WriteLine($"\n¡La mascota '{mascota.Nombre}' fue eliminada con éxito!");
            }

            Console.Write("\n¿Desea eliminar otra mascota?(si/no): ");

            if (Console.ReadLine() == "si")
            {
                Console.Clear();
                EliminarMascota();
            }
            else 
            {
                Console.Clear();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nOcurrió un error al eliminar la mascota: {ex.Message}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

    }

    public static void VerFichaCompleta()
    {
        Console.Clear();
        Console.WriteLine("---------- FICHA COMPLETA DE LA MASCOTA ----------");
        Console.Write("\n-Ingrese el nombre de la mascota: ");
        var nombre = Console.ReadLine();

        var mascota = MascotaRepositories.EditarMascota(nombre);

        if (mascota == null)
        {
            Console.WriteLine("\nNo se encontró ninguna mascota con ese nombre.");
        }
        else
        {
            Console.WriteLine();
            mascota.MostrarDetalles(); // usa el override de Mascota (polimorfismo)

            Console.Write("\nComportamiento: ");
            mascota.EmitirSonido(); // usa el override segun la especie

            Console.WriteLine($"\nHistorial de atenciones ({mascota.HistorialAtenciones.Count}):");
            if (mascota.HistorialAtenciones.Count == 0)
            {
                Console.WriteLine("  Sin atenciones registradas todavia.");
            }
            else
            {
                foreach (var atencion in mascota.HistorialAtenciones.OrderByDescending(a => a.Fecha))
                {
                    var detalle = atencion is Services.Vacunacion vacuna ? $" - Vacuna: {vacuna.TipoVacuna}" : "";
                    Console.WriteLine($"  - {atencion.Fecha:dd/MM/yyyy HH:mm} | {atencion.NombreServicio}{detalle}");
                }
            }
        }

        Console.Write("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }
}