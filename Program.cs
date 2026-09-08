using System;

public class Program
{
    public static void Main(string[] args)
    {
        int opcion = 0;

        do
        {
            Console.WriteLine("====================================");
            Console.WriteLine("      SISTEMA DE GESTION DE");
            Console.WriteLine("             BIBLIOTECA");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Registrar usuario");
            Console.WriteLine("3. Listar libros");
            Console.WriteLine("4. Buscar libro");
            Console.WriteLine("5. Eliminar libro");
            Console.WriteLine("6. Registrar prestamo");
            Console.WriteLine("7. Registrar devolucion");
            Console.WriteLine("8. Consultar libros disponibles");
            Console.WriteLine("9. Buscar por autor o categoria");
            Console.WriteLine("10. Listar libros ordenados por titulo");
            Console.WriteLine("11. Consultar prestamos activos");
            Console.WriteLine("0. Salir");
            Console.WriteLine("====================================");
            Console.Write("Ingrese una opcion: ");
        } while (opcion != 0);
    }
}