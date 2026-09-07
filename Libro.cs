using System;

public class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Categoria { get; set; }
    public int Codigo { get; set; }
    public bool Disponible { get; set; }

    public Libro(string titulo, string autor, string categoria, int codigo)
    {
        Titulo = titulo;
        Autor = autor;
        Categoria = categoria;
        Codigo = codigo;
        Disponible = true;
    }

    public void Mostrar()
    {
        Console.WriteLine("Codigo: " + Codigo);
        Console.WriteLine("Titulo: " + Titulo);
        Console.WriteLine("Autor: " + Autor);
        Console.WriteLine("Categoria: " + Categoria);
        Console.WriteLine("Disponible: " + (Disponible ? "Si" : "No"));
    }
}