using System.Security.Cryptography;

namespace ProyectoTienda;
public class Productos
{
    public static void iniciarProductos()
    {
        //se instancian los arreglos de los productos
        string[] productos = { "agua", "pera", "papas", "galletas" };
        double[] precio = { 2300, 3100, 4300, 6700 };
        int[] stock = { 8, 10, 7, 23 };
        
        //Se llama al metodo para comprar productos
        comprarProductos(productos, precio, stock);
        
        
    }

    public static void mostrarProductos(string[] productos, double[] precio, int[] stock)
    {
        Console.WriteLine("--- tienda de Ana ---\nProductos: ");
        for (int i = 0; i < productos.Length; i++)
        {
            Console.WriteLine($"{i+1}. {productos[i]}: {precio[i]} - Stock: {stock[i]}");
        }
    }

    public static void comprarProductos(string[] productos, double[] precio, int[] stock, double total = 0)
    {
        mostrarProductos(productos, precio, stock);
        while (true)
        {
            Console.WriteLine("Ingrese que productos desea comprar: ");
            int opcion = int.Parse(Console.ReadLine());
            int cantidad = 0;

            if (opcion <= productos.Length)
            {
                for (int i = 0; i < productos.Length; i++)
                {
                    if (opcion == i + 1)
                    {
                        Console.WriteLine($"hay en stock: {stock[i]}");
                        while (true)
                        {
                            Console.WriteLine($"Ingrese la cantidad de productos que llevara: ");
                            cantidad = int.Parse(Console.ReadLine());

                            if (cantidad <= stock[i])
                            {
                                stock[i] -= cantidad;
                                double subTotal = cantidad * precio[i];
                                Console.WriteLine($"El valor subTotal de {productos[i]} es {subTotal}");
                                total += subTotal;
                                Console.WriteLine("Quieres comprar algo mas? S/N");
                                string comprarOtraVez = Console.ReadLine().ToLower();
                                if (comprarOtraVez == "s" || comprarOtraVez == "si")
                                {
                                    comprarProductos(productos, precio, stock, total);
                                }
                                else
                                {
                                    Console.WriteLine($"El valor Total es {total}");

                                }
                                return;

                            }
                            else
                            {
                                Console.WriteLine(
                                    "Error: La cantidad no puede superar el stock del producto, intente de nuevo.");
                            }
                        }
                    }
                }
                break;
            }
            else
            {
                Console.WriteLine("El numero del producto seleccionado no existe, quieres intentarlo nuevamente? S/N");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta == "n" || respuesta == "no")
                {
                    break;
                }
            }
        }
    }
}