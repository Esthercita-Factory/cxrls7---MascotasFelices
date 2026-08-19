using MascotasFelices.Models;
using MascotasFelices.Repositories;

namespace MascotasFelices.UI;

// Esta clase agrupa las funcionalidades de programacion asincrona del sistema.
// Se usa async/await y Task para simular procesos que en un sistema real (base de datos,
// red, servicios externos) tomarian tiempo, sin bloquear el hilo principal de la aplicacion.
//
// Regla general que seguimos aqui: NUNCA usamos .Result o .Wait() para esperar una Task,
// porque eso bloquea el hilo que la llama y anula el beneficio de la asincronia.
// Siempre se espera con 'await'.
public class ManagerAsync
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
                Console.WriteLine("⚠️ Entrada invalida. Ingrese un numero entero.");
            }
        }
    }

    // TASK 2: registro asincrono de una sola mascota, mostrando el flujo
    // antes -> durante -> despues para visualizar que la ejecucion no se congela.
    public static async Task RegistrarMascotaAsyncMenu()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("---------- REGISTRAR MASCOTA (ASINCRONO) ----------");

            Console.Write("\n-Ingrese el nombre de la mascota: ");
            var nombre = Console.ReadLine();

            Console.Write("\n-Ingrese la especie de la mascota: ");
            var especie = Console.ReadLine();

            Console.Write("\n-Ingrese la raza de la mascota: ");
            var raza = Console.ReadLine();

            var edad = LeerEnteroIntParse("\n-Ingrese la edad (en meses): ");

            var mascotaNueva = new Mascota(nombre, especie, raza, edad);

            Console.WriteLine($"\n[ANTES]   Iniciando el registro de '{nombre}'...");
            Console.WriteLine("[DURANTE] Guardando datos, por favor espere...");

            // 'await' entrega el control mientras se simula la escritura en base de datos;
            // el programa no queda congelado, solo esta operacion espera su turno.
            await MascotaRepositories.RegistrarMascotaAsync(mascotaNueva);

            RegistroRepositories.Agregar($"Mascota '{nombre}' registrada de forma asincrona.");
            Console.WriteLine($"[DESPUES] Mascota '{nombre}' registrada con exito.");

            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nOcurrio un error al registrar la mascota: {ex.Message}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    // TASK 3: tres procesos de clinica corriendo en paralelo (historial, cita, notificacion).
    // Task.Run lanza cada uno en un hilo del threadpool para que avancen al mismo tiempo,
    // y Task.WhenAll espera a que los 3 terminen sin bloquear el hilo principal.
    public static async Task ProcesarLlegadaDeMascotaAsync()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("---------- PROCESAR LLEGADA DE MASCOTA ----------");
            Console.Write("\n-Ingrese el nombre de la mascota que llego a la clinica: ");
            var nombreMascota = Console.ReadLine();

            Console.WriteLine($"\nIniciando 3 procesos en paralelo para '{nombreMascota}'...\n");

            var tareaHistorial = CargarHistorialClinicoAsync(nombreMascota);
            var tareaCita = AgendarCitaAsync(nombreMascota);
            var tareaNotificacion = EnviarNotificacionAsync(nombreMascota);

            await Task.WhenAll(tareaHistorial, tareaCita, tareaNotificacion);

            RegistroRepositories.Agregar($"Se completaron los procesos de llegada para '{nombreMascota}'.");
            Console.WriteLine($"\n✔ Los 3 procesos para '{nombreMascota}' finalizaron correctamente.");

            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nOcurrio un error al procesar la llegada: {ex.Message}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    private static Task CargarHistorialClinicoAsync(string nombreMascota)
    {
        return Task.Run(() =>
        {
            Thread.Sleep(2000);
            Console.WriteLine($"  [Historial] Historial clinico de '{nombreMascota}' cargado.");
        });
    }

    private static Task AgendarCitaAsync(string nombreMascota)
    {
        return Task.Run(() =>
        {
            Thread.Sleep(1200);
            Console.WriteLine($"  [Cita] Cita agendada para '{nombreMascota}'.");
        });
    }

    private static Task EnviarNotificacionAsync(string nombreMascota)
    {
        return Task.Run(() =>
        {
            Thread.Sleep(800);
            Console.WriteLine($"  [Notificacion] Notificacion enviada al dueno de '{nombreMascota}'.");
        });
    }

    // TASK 4: registrar varias mascotas al mismo tiempo (concurrentes) y avisar
    // cuando TODAS hayan terminado, usando Task.WhenAll sobre una lista de tareas.
    public static async Task RegistrarVariasMascotasSimultaneamenteAsync()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("---------- REGISTRO MASIVO DE MASCOTAS (PARALELO) ----------");

            var cantidad = LeerEnteroIntParse("\n-Cuantas mascotas desea registrar al mismo tiempo?: ");

            if (cantidad <= 0)
            {
                Console.WriteLine("\nDebe ingresar al menos 1 mascota.");
            }
            else
            {
                var mascotasNuevas = new List<Mascota>();

                for (int i = 1; i <= cantidad; i++)
                {
                    Console.WriteLine($"\n--- Datos de la mascota #{i} ---");

                    Console.Write("-Nombre: ");
                    var nombre = Console.ReadLine();

                    Console.Write("-Especie: ");
                    var especie = Console.ReadLine();

                    Console.Write("-Raza: ");
                    var raza = Console.ReadLine();

                    var edad = LeerEnteroIntParse("-Edad (en meses): ");

                    mascotasNuevas.Add(new Mascota(nombre, especie, raza, edad));
                }

                Console.WriteLine("\nRegistrando todas las mascotas al mismo tiempo...\n");

                // Se lanza una tarea de registro por cada mascota; todas corren en paralelo
                // en lugar de esperar a que cada registro termine antes de iniciar el siguiente.
                var tareasRegistro = mascotasNuevas
                    .Select(mascota => MascotaRepositories.RegistrarMascotaAsync(mascota))
                    .ToList();

                await Task.WhenAll(tareasRegistro);

                foreach (var mascota in mascotasNuevas)
                {
                    RegistroRepositories.Agregar($"Mascota '{mascota.Nombre}' registrada en lote paralelo.");
                }

                Console.WriteLine($"\n✔ Las {cantidad} mascotas fueron registradas con exito.");
            }

            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nOcurrio un error en el registro masivo: {ex.Message}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    // TASK 4: comparativa practica entre Task.WhenAny y Task.WhenAll.
    // Se atienden 3 pacientes con tiempos distintos para que uno termine antes que los otros.
    public static async Task CompararWhenAllYWhenAnyAsync()
    {
        Console.Clear();
        Console.WriteLine("---------- COMPARACION: Task.WhenAny vs Task.WhenAll ----------\n");
        Console.WriteLine("Se van a atender 3 pacientes en paralelo, cada uno con un tiempo distinto.\n");

        var tareaPacienteA = AtenderPacienteAsync("Paciente A", 3000);
        var tareaPacienteB = AtenderPacienteAsync("Paciente B", 1000);
        var tareaPacienteC = AtenderPacienteAsync("Paciente C", 2000);

        var tareas = new List<Task> { tareaPacienteA, tareaPacienteB, tareaPacienteC };

        // Task.WhenAny devuelve la PRIMERA tarea que termina, sin esperar a las demas.
        // Util cuando solo interesa reaccionar en cuanto haya un resultado disponible.
        await Task.WhenAny(tareas);
        Console.WriteLine("\n>> Task.WhenAny detecto que un paciente ya fue atendido, seguimos esperando al resto...\n");

        // Task.WhenAll espera a que TODAS las tareas terminen antes de continuar.
        // Util cuando el siguiente paso depende de que todo el trabajo haya finalizado.
        await Task.WhenAll(tareas);
        Console.WriteLine("\n>> Task.WhenAll confirma que los 3 pacientes ya fueron atendidos.");

        Console.Write("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }

    private static Task AtenderPacienteAsync(string nombrePaciente, int milisegundos)
    {
        return Task.Run(() =>
        {
            Thread.Sleep(milisegundos);
            Console.WriteLine($"  [Atencion] {nombrePaciente} fue atendido en {milisegundos} ms.");
        });
    }
}