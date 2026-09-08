# Sistema de una Biblioteca

## Descripción

Aplicación de consola desarrollada en C# y .NET 10 para administrar libros,usuarios y préstamos de una biblioteca.

## Funcionalidades

* Registrar libros.
* Registrar usuarios.
* Listar libros.
* Buscar libros por código.
* Eliminar libros.
* Registrar préstamos.
* Registrar devoluciones.
* Consultar libros disponibles.
* Buscar libros por autor o categoría.
* Ordenar libros por título.
* Consultar préstamos activos.
* Validar datos y controlar errores.

## Requisitos Previos
* Tener instalado el SDK de .NET 10.
* Git instalado en el sistema.

## Ejecución

1. Abre una terminal o consola de comandos.
2. Clonar el repositorio en su máquina local ejecutando:
   `git clone https://github.com/adrianmontc/SistemaBiblioteca`
3. Navegar hacia la carpeta principal del proyecto:
   `cd SistemaBiblioteca`
4. Ejecutar la aplicación con el siguiente comando:
   `dotnet run`

## Estructura

* `Program.cs`: menú principal.
* `Libro.cs`: clase que representa los libros.
* `Usuario.cs`: clase que representa los usuarios.
* `Prestamo.cs`: record utilizado para representar los préstamos.
* `IRepositorio.cs`: interfaz genérica.
* `BibliotecaService.cs`: lógica principal del sistema.

## LINQ

El proyecto utiliza las operaciones `Where`, `FirstOrDefault`, `OrderBy` y `Select` para realizar las consultas solicitadas.

## Manejo de errores

El programa utiliza `try/catch` para controlar datos inválidos y errores relacionados con libros, usuarios y préstamos, permitiendo que el programa continúe funcionando.
