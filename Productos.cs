namespace ProyectoTienda;
public class Productos
{
    
    private static List<string> historialProductos = new List<string>();
    private static List<int> historialCantidades = new List<int>();
    private static List<double> historialSubtotales = new List<double>();

    public static void iniciarProductos()
    {
        string[] productos = { "agua", "pera", "papas", "galletas" };
        double[] precio = { 2300, 3100, 4300, 6700 };
        int[] stock = { 8, 10, 7, 23 };
        
        
        comprarProductos(productos, precio, stock);
    }

    public static void mostrarProductos(string[] productos, double[] precio, int[] stock)
    {
        Console.WriteLine("--- Bienvenidos a la tienda de Ana ---\nProductos: ");
        for (int i = 0; i < productos.Length; i++)
        {
            Console.WriteLine($"{i+1}. {productos[i]}: {precio[i]} - Stock: {stock[i]}");
        }
    }

    public static void comprarProductos(string[] productos, double[] precio, int[] stock)
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
                                double total = cantidad * precio[i];
                                
                                purchaseHistory(productos[i], cantidad, total);

                                Console.WriteLine("Quieres comprar algo mas? S/N");
                                string comprarOtraVez = Console.ReadLine().ToLower();
                                if (comprarOtraVez == "s" || comprarOtraVez == "si")
                                {
                                    comprarProductos(productos, precio, stock);
                                }
                                else
                                {
                                    
                                    mostrarHistorial();
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
    
    public static void purchaseHistory(string nombre, int cantidad, double total = 0)
    {
        historialProductos.Add(nombre);
        historialCantidades.Add(cantidad);
        historialSubtotales.Add(total);

    }


    public static void mostrarHistorial()
    {
        Console.WriteLine("\n--- Historial de Compras ---");
        double totalAP = 0;
        double descuento = 0.0;
        for (int i = 0; i < historialProductos.Count; i++)
        {
            Console.WriteLine($"{i+1}. {historialProductos[i]} - Cantidad: {historialCantidades[i]} - total: {historialSubtotales[i]}");
            totalAP += historialSubtotales[i];
        }
        Console.WriteLine($"Subtotal: {totalAP}");
        if (totalAP > 10000 && totalAP < 20000)
        {
            descuento = totalAP * 0.10;
            totalAP -= descuento;
            Console.WriteLine($"Descuento del 10%: {descuento}");
            Console.WriteLine($"Total a pagar con descuentos: {totalAP}");
        }else if (totalAP > 20000)
        {
            descuento = totalAP * 0.20;
            totalAP -= descuento;
            Console.WriteLine($"Descuento del 20%: {descuento}");
            Console.WriteLine($"Total a pagar con descuentos: {totalAP}");
        }
        else if (totalAP > 0 && totalAP < 10000)
        {
            Console.WriteLine($"Descuento no aplica: 0%");
            Console.WriteLine($"Total a pagar: {totalAP}");
        }
        Console.WriteLine("Gracias por comprar en la tienda de Ana!");
    }
}