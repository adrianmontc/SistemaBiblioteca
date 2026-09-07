using System;

public class Usuario
{
    public int Identificador { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }

    public Usuario(int identificador, string nombre, string correo)
    {
        Identificador = identificador;
        Nombre = nombre;
        Correo = correo;
    }

    public void Mostrar()
    {
        Console.WriteLine("Identificador: " + Identificador);
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Correo: " + Correo);
    }
}