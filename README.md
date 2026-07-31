# 🐾 Mascotas Felices

Sistema de consola desarrollado en **C# / .NET** para el registro y consulta de pacientes de la clínica veterinaria **Mascotas Felices**. El proyecto permite a los administradores llevar un control inicial de la información básica de los pacientes de forma rápida y sencilla.

## 📋 Descripción

Como administrador de la clínica, se necesita registrar y consultar pacientes desde consola para tener un control inicial de la información básica. Esta aplicación cubre ese flujo: alta de pacientes, listado y búsqueda por nombre, con validación de datos y manejo de errores.

## 🎯 Objetivo de la historia de usuario

> Como administrador de la clínica, quiero registrar y consultar pacientes desde consola para poder tener un control inicial de la información básica.

## 🛠️ Tecnologías utilizadas

- **Lenguaje:** C#
- **Framework:** .NET SDK
- **Tipo de proyecto:** Aplicación de consola
- **Editor:** Visual Studio Code

## 📁 Estructura del proyecto

```
MascotasFelices/
│
├── Models/
│   └── Paciente.cs        # Clase que define la entidad Paciente
│
├── Services/
│   └── PacienteService.cs # Lógica de negocio: registrar, listar y buscar pacientes
│
├── Program.cs              # Punto de entrada y menú principal
└── MascotasFelices.csproj
```

## ⚙️ Instalación y configuración

### Requisitos previos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado (versión compatible con C#).
- Editor de código: Visual Studio o VS Code.

### Pasos

1. Clonar o descargar el repositorio.
2. Verificar la instalación del SDK:
   ```bash
   dotnet --version
   ```
3. Restaurar dependencias y compilar el proyecto:
   ```bash
   dotnet build
   ```
4. Ejecutar la aplicación:
   ```bash
   dotnet run
   ```

## 🧩 Modelo de datos

### Clase `Paciente`

| Propiedad | Tipo   | Descripción                     |
|-----------|--------|----------------------------------|
| Id        | int    | Identificador único del paciente |
| Nombre    | string | Nombre del paciente              |
| Edad      | int    | Edad del paciente                |
| Sintoma   | string | Síntoma reportado                |

```csharp
public class Paciente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Sintoma { get; set; }
}
```

## 🖥️ Funcionalidades

El menú principal ofrece las siguientes opciones:

1. **Registrar paciente** – Solicita los datos por consola y agrega un nuevo paciente a la lista.
2. **Listar pacientes** – Recorre la lista de pacientes registrados y los muestra en pantalla.
3. **Buscar paciente** – Busca un paciente por nombre y muestra su información si existe.
4. **Salir** – Finaliza la ejecución del programa.

La lógica de estas operaciones se encuentra encapsulada en la clase `PacienteService`, separando responsabilidades del punto de entrada (`Program.cs`).

### Métodos principales de `PacienteService`

- `RegistrarPaciente(List<Paciente> lista)`
- `ListarPacientes(List<Paciente> lista)`
- `BuscarPacientePorNombre(List<Paciente> lista, string nombre)`

## ✅ Validaciones y manejo de errores

- Validación de campos vacíos o inválidos.
- Uso de `try-catch` para controlar errores de conversión (por ejemplo, `int.Parse` al ingresar la edad).
- Mensajes claros y amigables ante entradas incorrectas, evitando que el programa se detenga inesperadamente.

## 📌 Criterios de aceptación

- [x] El programa compila y se ejecuta sin errores.
- [x] El usuario puede ingresar los datos del paciente a través de la consola.
- [x] La información ingresada se valida correctamente (sin campos vacíos ni valores inválidos).
- [x] Los datos quedan almacenados en una colección (`List<Paciente>`).
- [x] El sistema muestra un resumen claro con la información registrada.
- [x] La lógica está organizada en métodos bien definidos, evitando código repetido.
- [x] El manejo de errores es adecuado y no interrumpe la ejecución del programa.

## 🚀 Uso

```bash
dotnet run
```

Sigue las instrucciones del menú en consola para registrar, listar o buscar pacientes.

## 👤 Autor

**Carlos Daniel Molina Ordoñez**

