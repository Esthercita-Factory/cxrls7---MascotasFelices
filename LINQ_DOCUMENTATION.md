# 📊 Demostraciones de LINQ - Sistema Veterinario "Mascotas Felices"

## 📋 Descripción General

Este proyecto implementa todas las **TAREAS de LINQ y Colecciones** solicitadas en la historia de usuario. El código está organizado de forma limpia, con el `Program.cs` conteniendo solo el menú principal, mientras que todas las demostraciones de LINQ se encuentran en una clase separada (`LINQDemostraciones.cs`) para mejor mantenibilidad.

---

## ✅ Tareas Completadas

### ✨ TAREA 1: Reforzar el uso de Colecciones en C#

**Archivo:** `/Helpers/LINQDemostraciones.cs` → `Tarea1_Colecciones()`

Se implementaron las siguientes colecciones:

1. **List<Mascota>** - Almacenar y manipular mascotas
   - Agregar elementos con `.Add()`
   - Eliminar elementos con `.Remove()`
   - Contar con `.Count`

2. **Dictionary<int, Mascota>** - Acceso rápido por ID
   - Búsqueda O(1) usando `TryGetValue()`
   - Ideal para buscas frecuentes por identificador

3. **Dictionary<string, List<Mascota>>** - Agrupar por especie
   - Organización de datos por categorías
   - Uso de `GroupBy()` para crear la estructura

**Ejemplo de código:**
```csharp
// List<Mascota>
List<Mascota> mascotas = new() { ... };

// Dictionary para acceso rápido
Dictionary<int, Mascota> mascotasPorId = mascotas
    .Select((m, i) => new { Id = i + 1, Mascota = m })
    .ToDictionary(x => x.Id, x => x.Mascota);

// Dictionary para agrupación
Dictionary<string, List<Mascota>> mascotasPorEspecie = mascotas
    .GroupBy(m => m.Especie)
    .ToDictionary(g => g.Key, g => g.ToList());
```

---

### ✨ TAREA 2: Diferencia entre Sintaxis de Consulta vs Sintaxis de Métodos

**Archivo:** `/Helpers/LINQDemostraciones.cs` → `Tarea2_SintaxisConsultaVsMetodos()`

Se compararon ambas sintaxis con ejemplos prácticos:

#### Ejemplo 1: WHERE (Filtrado)
```csharp
// Sintaxis de CONSULTA
var consultaMayores24 = from m in mascotas
                        where m.Edad > 24
                        select m;

// Sintaxis de MÉTODOS
var metodoMayores24 = mascotas.Where(m => m.Edad > 24);
```

#### Ejemplo 2: SELECT (Proyección)
```csharp
// Sintaxis de CONSULTA
var consultaNombres = from m in mascotas
                      select m.Nombre.ToUpper();

// Sintaxis de MÉTODOS
var metodoNombres = mascotas.Select(m => m.Nombre.ToUpper());
```

#### Ejemplo 3: OrderBy y OrderByDescending
```csharp
// Ordenar ASCENDENTE
var ordenadoAsc = mascotas.OrderBy(m => m.Edad);

// Ordenar DESCENDENTE
var ordenadoDesc = mascotas.OrderByDescending(m => m.Edad);
```

#### Ejemplo 4: GroupBy (Agrupación)
```csharp
// Sintaxis de CONSULTA
var grupos = from m in mascotas
             group m by m.Especie into especieGrupo
             select new { Especie = especieGrupo.Key, Cantidad = especieGrupo.Count() };
```

---

### ✨ TAREA 3: Métodos Fundamentales de LINQ

**Archivo:** `/Helpers/LINQDemostraciones.cs` → `Tarea3_MetodosFundamentalesLINQ()`

Se implementaron los siguientes métodos:

| Método | Descripción | Ejemplo |
|--------|-------------|---------|
| `First()` | Obtiene el primer elemento | `mascotas.First()` |
| `FirstOrDefault()` | Obtiene primero o null | `mascotas.FirstOrDefault(m => m.Nombre == "max")` |
| `Any()` | Verifica si existe alguno | `mascotas.Any(m => m.Especie == "perro")` |
| `All()` | Verifica si todos cumplen | `mascotas.All(m => !string.IsNullOrEmpty(m.Nombre))` |
| `Count()` | Cuenta elementos | `mascotas.Count(m => m.Especie == "perro")` |

**Clase Mascota mejorada:**
```csharp
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
    // ... constructores y métodos
}
```

---

### ✨ TAREA 4: Encadenamiento de Consultas LINQ

**Archivo:** `/Helpers/LINQDemostraciones.cs` → `Tarea4_EncadenamientoConsultas()`

Se implementaron consultas complejas y expresivas:

#### Ejemplo 1: Filtrar → Ordenar → Proyectar
```csharp
var perrosOrdenados = mascotas
    .Where(m => m.Especie == "perro")      // Filtrar
    .OrderBy(m => m.Edad)                   // Ordenar
    .Select(m => new { m.Nombre, m.Edad }) // Proyectar
    .ToList();
```

#### Ejemplo 2: Agrupar → Contar → Estadísticas
```csharp
var estadisticas = mascotas
    .GroupBy(m => m.Especie)
    .Select(g => new
    {
        Especie = g.Key.ToUpper(),
        Cantidad = g.Count(),
        PromedioEdad = g.Average(m => m.Edad)
    })
    .OrderByDescending(x => x.Cantidad)
    .ToList();
```

#### Ejemplo 3: Múltiples Filtros
```csharp
var mascotasAdultas = mascotas
    .Where(m => m.Edad >= 24)           // Mayor a 24 meses
    .Where(m => m.Edad < 60)            // Menor a 60 meses
    .OrderBy(m => m.Nombre)             // Alfabéticamente
    .ToList();
```

---

### ✨ TAREA 5: Problemas Prácticos Resueltos con LINQ

**Archivo:** `/Helpers/LINQDemostraciones.cs` → `Tarea5_ProblemasPracticos()`

#### Problema 1: Mascota más joven y más vieja
```csharp
var mascotaMasJoven = mascotas.OrderBy(m => m.Edad).First();
var mascotaMasVieja = mascotas.OrderByDescending(m => m.Edad).First();
```

#### Problema 2: Contar mascotas por especie
```csharp
var conteos = mascotas
    .GroupBy(m => m.Especie)
    .Select(g => new { Especie = g.Key.ToUpper(), Cantidad = g.Count() })
    .OrderByDescending(x => x.Cantidad);
```

#### Problema 3: Verificar existencia de mascota sin raza definida
```csharp
bool existeSinRaza = mascotas.Any(m => m.Raza == "desconocida");
```

#### Problema 4: Nombres en MAYÚSCULAS, ordenados alfabéticamente
```csharp
var nombresOrdenados = mascotas
    .OrderBy(m => m.Nombre)
    .Select(m => m.Nombre.ToUpper())
    .ToList();
```

#### Problema 5: Mascotas por dueño
```csharp
var mascotasPorDueno = mascotas
    .Where(m => !string.IsNullOrEmpty(m.Dueno))
    .GroupBy(m => m.Dueno)
    .Select(g => new 
    { 
        Dueno = g.Key, 
        Cantidad = g.Count(), 
        Mascotas = g.Select(m => m.Nombre).ToList() 
    })
    .OrderByDescending(x => x.Cantidad)
    .ToList();
```

---

## 🏗️ Estructura del Proyecto

```
MascotasFelices/
├── Models/
│   └── Mascota.cs                    ← Clase actualizada con Especie y propiedades adicionales
├── Helpers/
│   └── LINQDemostraciones.cs         ← ⭐ TODAS las demostraciones de LINQ (19KB)
├── Repositories/
│   └── MascotaRepositories.cs
├── UI/
│   ├── ManagerUser.cs                ← Menú actualizado con opción [6] LINQ
│   └── ManagerMascotas.cs
├── Program.cs                        ← ✨ LIMPIO - Solo menú y llamadas
└── MascotasFelices.csproj
```

---

## 🎯 Características Principales

### ✅ Código Limpio
- **Program.cs** contiene SOLO el menú principal y las opciones
- Todas las lógicas de LINQ están centralizadas en `LINQDemostraciones.cs`
- Separación de responsabilidades clara

### ✅ Menú Interactivo
```
[1] Registrar una nueva mascota
[2] Listar las mascotas registradas
[3] Buscar una mascota
[4] Editar una mascota
[5] Eliminar una mascota
[6] 📊 Demostraciones LINQ (Colecciones)    ← NUEVA OPCIÓN
[0] Salir del sistema
```

### ✅ Submenu LINQ
```
[1] Tarea 1: Reforzar uso de Colecciones
[2] Tarea 2: Sintaxis de Consulta vs Métodos
[3] Tarea 3: Métodos Fundamentales de LINQ
[4] Tarea 4: Encadenamiento de Consultas
[5] Tarea 5: Problemas Prácticos con LINQ
[6] Ver todas las demostraciones
[0] Volver al menú principal
```

---

## 🚀 Cómo Ejecutar

```bash
cd "/home/cohorte5/Carlos .net/cxrls7---MascotasFelices/MascotasFelices"
dotnet run
```

Luego selecciona la opción `6` para ver todas las demostraciones de LINQ.

---

## ✨ Ejemplos de Salida

### Tarea 1 - Colecciones:
```
1️⃣ List<Mascota> - Almacenar mascotas:
   Total de mascotas: 10
   • max - perro
   • luna - gato
   • buddy - perro

2️⃣ Dictionary<int, Mascota> - Búsqueda rápida por ID:
   ✓ ID 1: max

3️⃣ Dictionary<string, List<Mascota>> - Agrupar por especie:
   • PERRO: 5 mascotas
   • GATO: 5 mascotas
```

### Tarea 3 - Métodos Fundamentales:
```
➤ First() - Obtener el primer elemento:
  Primera mascota: max

➤ Any() - Verificar existencia:
  ¿Existen perros?: SÍ
  ¿Existen pájaros?: NO

➤ Count() - Contar elementos:
  Total de mascotas: 10
  Total de perros: 5
```

### Tarea 5 - Problemas Prácticos:
```
✓ PROBLEMA 1: Mascota más joven y más vieja
  Más joven: rocky (12 meses)
  Más vieja: spike (60 meses)

✓ PROBLEMA 2: Contar mascotas por especie
  PERRO: 5
  GATO: 5
```

---

## 📝 Criterios de Aceptación - COMPLETADOS ✅

- ✅ Los pacientes y sus mascotas están organizados en colecciones (List y Dictionary)
- ✅ Se pueden realizar consultas usando LINQ en ambas sintaxis (consulta y métodos)
- ✅ Las consultas permiten filtrar, ordenar, agrupar y proyectar datos correctamente
- ✅ Se han utilizado métodos clave: Where, Select, OrderBy, GroupBy, First, Any, Count
- ✅ Existen ejemplos de consultas encadenadas que devuelven resultados complejos
- ✅ Los problemas prácticos se resuelven con consultas LINQ sin errores
- ✅ El código es legible y cuenta con comentarios explicativos

---

## 💡 Notas Adicionales

- La clase `Mascota` representa tanto la mascota como el "paciente" de la clínica
- Se añadieron propiedades como `Especie`, `Dueno`, `Telefono` y `Sintoma` para las demostraciones
- Todos los constructores antiguas siguen siendo funcionales para compatibilidad hacia atrás
- El archivo `LINQDemostraciones.cs` puede ser utilizado como referencia educativa para futuros desarrolladores

---

**Proyecto completado exitosamente** ✨
