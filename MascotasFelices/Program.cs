using MascotasFelices.UI;
using MascotasFelices.Helpers;

string opcion;
do
{
    ManagerUser.MostraMenu();

    opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Clear();
            ManagerMascotas.CrearUnaMascota();
            break;
        case "2":
            Console.Clear();
            ManagerMascotas.MostrarTodasLasMascotas();
            break;
        case "3":
            Console.Clear();
            ManagerMascotas.BuscarMascota();
            break;
        case "4":
            Console.Clear();
            ManagerMascotas.EditarMascota();
            break;
        case "5":
            Console.Clear();
            ManagerMascotas.EliminarMascota();
             break;
        
        case "6":
            Console.Clear();
            LINQDemostraciones.MostrarMenuDemostraciones();
            break;

        case "0":
            Console.Clear();
            Console.WriteLine("Hasta luego...");
            break;
        default:
            Console.WriteLine("Opcion no valida!");
            break;
    }
}while(opcion != "0");

