using MascotasFelices.UI;

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
            ConsultasLINQ.MostrarMenuConsultas();
            break;

        case "7":
            Console.Clear();
            ManagerPacientes.CrearUnPaciente();
            break;
        case "8":
            Console.Clear();
            ManagerPacientes.MostrarTodosLosPacientes();
            break;
        case "9":
            Console.Clear();
            ManagerPacientes.BuscarPaciente();
            break;
        case "10":
            Console.Clear();
            ManagerPacientes.EditarPaciente();
            break;
        case "11":
            Console.Clear();
            ManagerPacientes.EliminarPaciente();
            break;
        case "12":
            Console.Clear();
            ManagerPacientes.AsociarMascotaAPaciente();
            break;
        case "13":
            Console.Clear();
            ManagerMascotas.VerFichaCompleta();
            break;
        case "14":
            Console.Clear();
            ManagerPacientes.AtenderMascota();
            break;
        case "15":
            Console.Clear();
            ManagerPacientes.VerRegistroActividad();
            break;
        case "16":
            Console.Clear();
            await ManagerAsync.RegistrarMascotaAsyncMenu();
            break;
        case "17":
            Console.Clear();
            await ManagerAsync.ProcesarLlegadaDeMascotaAsync();
            break;
        case "18":
            Console.Clear();
            await ManagerAsync.RegistrarVariasMascotasSimultaneamenteAsync();
            break;
        case "19":
            Console.Clear();
            await ManagerAsync.CompararWhenAllYWhenAnyAsync();
            break;
        case "0":
            Console.Clear();
            Console.WriteLine("Hasta luego...");
            break;
        default:
            Console.WriteLine("Opcion no valida!");
            break;
    }
} while (opcion != "0");