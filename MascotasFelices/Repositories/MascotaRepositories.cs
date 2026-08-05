using MascotasFelices.Models;

namespace MascotasFelices.Repositories;

public static class MascotaRepositories
{
    public static List<Mascota> Mascotas { get; set; }

    static MascotaRepositories()
    {
        Mascotas =
        [
            new Mascota("Firulais", "Criollo", 36),
            new Mascota("Luna", "Labrador Retriever", 18),
            new Mascota("Rocky", "Bulldog Frances", 42),
            new Mascota("Michi", "Siames", 24),
        ];
    }

    // CREATE
    public static void RegistrarMascota(Mascota mascotaNueva)
    {
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