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

        Libro libroExistente = libros.FirstOrDefault(l => l.Codigo == codigo);

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

        Usuario usuarioExistente = usuarios.FirstOrDefault(u => u.Identificador == identificador);

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
}