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
}