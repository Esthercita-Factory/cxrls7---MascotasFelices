using MascotasFelices.Models;
using System.Threading.Tasks;

namespace MascotasFelices.Repositories;

public static class MascotaRepositories
{
    public static List<Mascota> Mascotas { get; set; }

    static MascotaRepositories()
    {
        Mascotas =
        [
            new Mascota("Firulais", "perro", "Criollo", 36),
            new Mascota("Luna", "perro", "Labrador Retriever", 18),
            new Mascota("Rocky", "perro", "Bulldog Frances", 42),
            new Mascota("Michi", "gato", "Siames", 24),
        ];
    }

    // CREATE
    public static void RegistrarMascota(Mascota mascotaNueva)
    {
        Mascotas.Add(mascotaNueva);
    }

    //  metodo asincrono que simula el registro de una mascota con una espera real,
    // como si estuviera guardando en una base de datos externa.
    // Usamos async/await aqui porque esta operacion "tarda": mientras espera, el hilo
    // principal queda libre para seguir atendiendo la aplicacion en vez de congelarse.
    public static async Task RegistrarMascotaAsync(Mascota mascotaNueva)
    {
        await Task.Delay(1500); // simula la latencia de guardar en una base de datos
        Mascotas.Add(mascotaNueva);
    }
    
    // READ
    public static List<Mascota> ListMascotas()
    {
        return Mascotas;
    }
    
    //SEARCH

    public static List<Mascota> BuscarMascota(string nombre)
    {
        return Mascotas.Where(m => m.Nombre.ToLower().Contains(nombre.ToLower())).ToList();
    }

    //EDIT

    public static Mascota EditarMascota(string nombre)
    {
        foreach (var mascota in Mascotas)
        {
            if (mascota.Nombre.ToLower() == nombre.ToLower())
            {
                return mascota; // 
            }
        }

        return null; 
    }
    //DELETE
// DELETE
    public static void EliminarMascota(Mascota mascota)
    {
        Mascotas.Remove(mascota);
    }
}