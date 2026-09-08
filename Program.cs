using System;

public class Program
{
    public static void Main(string[] args)
    {
        BibliotecaService biblioteca = new BibliotecaService();
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
            try
            {
                opcion = int.Parse(Console.ReadLine() ?? "");
                switch (opcion)
                {
                    case 1:
                        biblioteca.RegistrarLibro();
                        break;
                    case 2:
                        biblioteca.RegistrarUsuario();
                        break;
                    case 3:
                        biblioteca.ListarLibros();
                        break;
                    case 4:
                        biblioteca.BuscarLibro();
                        break;
                    case 5:
                        biblioteca.EliminarLibro();
                        break;
                    case 6:
                        biblioteca.RegistrarPrestamo();
                        break;
                    case 7:
                        biblioteca.RegistrarDevolucion();
                        break;
                    case 8:
                        biblioteca.ConsultarLibrosDisponibles();
                        break;
                    case 9:
                        biblioteca.ConsultarPorAutorOCategoria();
                        break;
                    case 10:
                        biblioteca.ConsultarLibrosOrdenados();
                        break;
                    case 11:
                        biblioteca.ConsultarPrestamosActivos();
                        break;
                    case 0:
                        Console.WriteLine("Programa finalizado.");
                        break;
                    default:
                        Console.WriteLine("La opcion no es valida.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: debe ingresar un dato valido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            if (opcion != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Presione ENTER para continuar...");
                Console.ReadLine();
            }

        } while (opcion != 0);
    }
}