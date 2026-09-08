using System;
using System.Collections.Generic;
using System.Linq;

public class BibliotecaService : IRepositorio<Libro>
{
    private List<Libro> libros;
    private List<Usuario> usuarios;
    private List<Prestamo> prestamos;

    private string[] categorias = {"Novela","Ciencia","Historia","Tecnologia","Educacion"};

    public BibliotecaService()
    {
        libros = new List<Libro>();
        usuarios = new List<Usuario>();
        prestamos = new List<Prestamo>();
    }
    public void Agregar(Libro libro)
    {
        libros.Add(libro);
    }

    public List<Libro> Listar()
    {
        return libros;
    }

    public void Eliminar(Libro libro)
    {
        libros.Remove(libro);
    }

    public void RegistrarLibro()
    {
        Console.WriteLine("REGISTRAR LIBRO");

        Console.Write("Titulo: ");
        string titulo = Console.ReadLine() ?? "";

        Console.Write("Autor: ");
        string autor = Console.ReadLine() ?? "";

        Console.WriteLine("Categorias disponibles:");

        for (int i = 0; i < categorias.Length; i++)
        {
            Console.WriteLine((i + 1) + ". " + categorias[i]);
        }

        Console.Write("Seleccione una categoria: ");
        int opcionCategoria = int.Parse(Console.ReadLine() ?? "");

        if (opcionCategoria < 1 || opcionCategoria > categorias.Length)
        {
            throw new Exception("La categoria seleccionada no existe.");
        }

        string categoria = categorias[opcionCategoria - 1];

        Console.Write("Codigo: ");
        int codigo = int.Parse(Console.ReadLine() ?? "");

        Libro? libroExistente = libros.FirstOrDefault(l => l.Codigo == codigo);

        if (libroExistente != null)
        {
            throw new Exception("Ya existe un libro con ese codigo.");
        }

        Libro nuevoLibro = new Libro(titulo, autor, categoria, codigo);
        Agregar(nuevoLibro);

        Console.WriteLine("Libro registrado correctamente.");
    }

    public void RegistrarUsuario()
    {
        Console.WriteLine("REGISTRAR USUARIO");

        Console.Write("Identificador: ");
        int identificador = int.Parse(Console.ReadLine() ?? "");

        Usuario? usuarioExistente = usuarios.FirstOrDefault(u => u.Identificador == identificador);

        if (usuarioExistente != null)
        {
            throw new Exception("Ya existe un usuario con ese identificador.");
        }

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";

        Console.Write("Correo: ");
        string correo = Console.ReadLine() ?? "";

        Usuario nuevoUsuario = new Usuario(identificador, nombre, correo);
        usuarios.Add(nuevoUsuario);

        Console.WriteLine("Usuario registrado correctamente.");
    }
    public void ListarLibros()
    {
        Console.WriteLine("LISTA DE LIBROS");

        if (libros.Count == 0)
        {
            Console.WriteLine("No existen libros registrados.");
            return;
        }

        foreach (Libro libro in libros)
        {
            libro.Mostrar();
            Console.WriteLine("----------------------");
        }
    }

    public void BuscarLibro()
    {
        Console.Write("Ingrese el codigo del libro: ");
        int codigo = int.Parse(Console.ReadLine() ?? "");

        Libro? libro = libros.FirstOrDefault(l => l.Codigo == codigo);

        if (libro == null)
        {
            throw new Exception("No se encontro el libro.");
        }

        libro.Mostrar();
    }

    public void EliminarLibro()
    {
        Console.Write("Ingrese el codigo del libro: ");
        int codigo = int.Parse(Console.ReadLine() ?? "");

        Libro? libro = libros.FirstOrDefault(l => l.Codigo == codigo);

        if (libro == null)
        {
            throw new Exception("No se encontro el libro.");
        }

        Eliminar(libro);

        Console.WriteLine("Libro eliminado correctamente.");
    }
    public void RegistrarPrestamo()
    {
        Console.WriteLine("REGISTRAR PRESTAMO");

        Console.Write("Codigo del libro: ");
        int codigoLibro = int.Parse(Console.ReadLine() ?? "");

        Libro? libro = libros.FirstOrDefault(l => l.Codigo == codigoLibro);

        if (libro == null)
        {
            throw new Exception("No se encontro el libro.");
        }

        if (!libro.Disponible)
        {
            throw new Exception("El libro no esta disponible.");
        }

        Console.Write("Identificador del usuario: ");
        int identificadorUsuario = int.Parse(Console.ReadLine() ?? "");

        Usuario? usuario = usuarios.FirstOrDefault(u => u.Identificador == identificadorUsuario);

        if (usuario == null)
        {
            throw new Exception("No se encontro el usuario.");
        }

        Prestamo nuevoPrestamo = new Prestamo(
            codigoLibro,
            identificadorUsuario,
            DateTime.Now,
            true
        );

        prestamos.Add(nuevoPrestamo);
        libro.Disponible = false;

        Console.WriteLine("Prestamo registrado correctamente.");
    }

    public void RegistrarDevolucion()
    {
        Console.WriteLine("REGISTRAR DEVOLUCION");

        Console.Write("Codigo del libro: ");
        int codigoLibro = int.Parse(Console.ReadLine() ?? "");

        int posicion = prestamos.FindIndex(p =>
            p.CodigoLibro == codigoLibro && p.Activo);

        if (posicion == -1)
        {
            throw new Exception("No existe un prestamo activo para ese libro.");
        }

        Prestamo prestamo = prestamos[posicion];

        prestamos[posicion] = prestamo with
        {
            Activo = false
        };

        Libro? libro = libros.FirstOrDefault(l => l.Codigo == codigoLibro);

        if (libro != null)
        {
            libro.Disponible = true;
        }

        Console.WriteLine("Devolucion registrada correctamente.");
    }
    public void ConsultarLibrosDisponibles()
    {
        Console.WriteLine("LIBROS DISPONIBLES");

        var disponibles = libros
            .Where(l => l.Disponible)
            .ToList();

        if (disponibles.Count == 0)
        {
            Console.WriteLine("No existen libros disponibles.");
            return;
        }

        foreach (Libro libro in disponibles)
        {
            libro.Mostrar();
            Console.WriteLine("----------------------");
        }
    }
    public void ConsultarPorAutorOCategoria()
    {
        Console.Write("Ingrese autor o categoria: ");
        string texto = Console.ReadLine() ?? "";

        var resultados = libros
            .Where(l =>
                l.Autor.ToLower() == texto.ToLower() ||
                l.Categoria.ToLower() == texto.ToLower())
            .ToList();

        if (resultados.Count == 0)
        {
            Console.WriteLine("No se encontraron libros.");
            return;
        }

        foreach (Libro libro in resultados)
        {
            libro.Mostrar();
            Console.WriteLine("----------------------");
        }
    }
    public void ConsultarLibrosOrdenados()
    {
        Console.WriteLine("LIBROS ORDENADOS POR TITULO");

        var resultados = libros
            .OrderBy(l => l.Titulo)
            .ToList();

        if (resultados.Count == 0)
        {
            Console.WriteLine("No existen libros registrados.");
            return;
        }

        foreach (Libro libro in resultados)
        {
            libro.Mostrar();
            Console.WriteLine("----------------------");
        }
    }
    public void ConsultarPrestamosActivos()
    {
        Console.WriteLine("PRESTAMOS ACTIVOS");

        var resultados = prestamos
            .Where(p => p.Activo)
            .Select(p => new
            {
                CodigoLibro = p.CodigoLibro,
                IdentificadorUsuario = p.IdentificadorUsuario,
                Fecha = p.FechaPrestamo
            })
            .ToList();

        if (resultados.Count == 0)
        {
            Console.WriteLine("No existen prestamos activos.");
            return;
        }

        foreach (var prestamo in resultados)
        {
            Console.WriteLine("Codigo del libro: " + prestamo.CodigoLibro);
            Console.WriteLine("Usuario: " + prestamo.IdentificadorUsuario);
            Console.WriteLine("Fecha: " + prestamo.Fecha);
            Console.WriteLine("----------------------");
        }
    }
}