# ⚽ Simulador de la Liga BetPlay en Consola con C#

## 📌 Información General

**Nombre del proyecto:** Simulador de la Liga BetPlay
**Lenguaje:** C#
**Tipo de aplicación:** Consola (.NET)
**Paradigma:** Programación Orientada a Objetos (POO)
**Autor:** [Tu nombre]
**Fecha:** 2026

---

## 🧾 Descripción del Proyecto

Este proyecto consiste en el desarrollo de una aplicación de consola en C# que simula el funcionamiento de una liga de fútbol profesional basada en la Liga BetPlay.

El sistema permite gestionar equipos, simular partidos, generar un calendario de competición (fixture), calcular automáticamente estadísticas y mostrar la tabla de posiciones en tiempo real.

Se implementa un enfoque práctico para aplicar conceptos fundamentales de desarrollo de software como estructuras de datos en memoria, consultas con LINQ, simulación de eventos y persistencia de datos en formato JSON.

---

## 🎯 Objetivos

### ✅ Objetivo General

Desarrollar una aplicación de consola que permita simular y gestionar un torneo de fútbol aplicando principios de programación orientada a objetos y procesamiento de datos.

### 🎯 Objetivos Específicos

* Modelar entidades del dominio (Equipos, Torneo, Jornadas).
* Implementar lógica de simulación de partidos.
* Automatizar el cálculo de estadísticas deportivas.
* Generar una tabla de posiciones ordenada dinámicamente.
* Aplicar consultas avanzadas mediante LINQ.
* Persistir la información del sistema en archivos JSON.
* Diseñar un sistema modular, organizado y escalable.

---

## ⚙️ Funcionalidades Principales

### 🟢 Gestión de Equipos

* Registro de equipos en memoria
* Listado de equipos registrados
* Búsqueda de equipos por nombre

### ⚽ Simulación de Partidos

* Simulación manual de resultados
* Simulación automática con generación aleatoria de goles
* Actualización automática de estadísticas

### 🏟️ Sistema de Fixture

* Generación automática de calendario (Round-Robin)
* Organización de partidos por jornadas
* Simulación de jornadas específicas

### 📊 Tabla de Posiciones

* Ordenamiento por:

  * Puntos
  * Diferencia de gol
  * Goles a favor
  * Nombre
* Visualización estructurada en consola

### 📈 Estadísticas Avanzadas (LINQ)

* Líder del torneo
* Equipo con más goles a favor
* Mejor defensa
* Equipos invictos
* Equipos sin victorias
* Top 3 / Top 5
* Promedios y totales del torneo

### 💾 Persistencia de Datos

* Guardado del estado del torneo en archivo JSON
* Carga automática al iniciar el sistema

### 🧾 Reporte Final

* Campeón del torneo
* Mejor ataque y defensa
* Resumen estadístico general

---

## 🧠 Arquitectura del Sistema

El proyecto sigue una arquitectura modular basada en separación de responsabilidades:

```
LigaBetPlaySimulador/
│
├── Models/
│   ├── Equipo.cs
│   ├── Torneo.cs
│   └── Jornada.cs
│
├── Services/
│   └── TorneoService.cs
│
├── Program.cs
```

### 📌 Descripción de capas

* **Models:** Representación de entidades del dominio.
* **Services:** Contiene la lógica de negocio y operaciones del sistema.
* **Program.cs:** Punto de entrada y control del flujo de la aplicación.

---

## 🔍 Tecnologías Utilizadas

* **C# (.NET)**
* **LINQ (Language Integrated Query)**
* **System.Text.Json**
* **Visual Studio Code**

---

## 🧮 Lógica de Negocio

El sistema implementa las siguientes reglas:

* Victoria: +3 puntos
* Empate: +1 punto
* Derrota: 0 puntos
* Diferencia de gol = GF - GC

Las estadísticas se actualizan automáticamente tras cada partido.

---

## 🎲 Simulación

El sistema incluye simulación probabilística mediante generación de números aleatorios para representar los goles de cada equipo.

---

## 💾 Persistencia

Los datos del torneo se almacenan en un archivo:

```
torneo.json
```

Esto permite mantener el estado del sistema entre ejecuciones.

---

## 🚀 Ejecución del Proyecto

### 🔧 Requisitos

* .NET SDK instalado
* Visual Studio Code

### ▶️ Comandos

```bash
dotnet build
dotnet run
```

---

## 📌 Ejemplo de Flujo de Uso

1. Registrar equipos
2. Generar fixture
3. Simular jornadas
4. Consultar tabla de posiciones
5. Analizar estadísticas
6. Generar reporte final

---

## 📊 Ejemplo de Salida

```
Equipo        PJ  PG  PE  PP  GF  GC  DG  PTS
Nacional      5   3   1   1   8   4   4   10
Millonarios   5   3   0   2   7   5   2   9
```

---

## 🧪 Posibles Mejoras

* Interfaz gráfica (GUI)
* Conexión a base de datos (MySQL, SQL Server)
* Sistema de jugadores y goleadores
* Exportación de reportes
* API REST

---

## 🎓 Conclusión

El desarrollo de este proyecto permitió aplicar de forma práctica conceptos fundamentales de programación en C#, fortaleciendo habilidades en modelado de datos, lógica de negocio, uso de LINQ y simulación de sistemas.

Además, se construyó una base sólida que puede ser extendida hacia aplicaciones más complejas en el futuro.

---

## 👨‍💻 Autor

[Sergio Andres Abril]

Proyecto académico – 2026
