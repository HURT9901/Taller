/*Realizar un programa para la facturación de un almacén. Los artículos deben manejasen con un vector de objetos
 * con los atributos código, nombre, valor y cantidad existente. El usuario solo debe ingresar el código
 * del articulo y la cantidad, al finalizar el proceso de compra se debe imprimir la factura con los datos
 * por artículo de: código, nombre, valor, cantidad, IVA y si posee descuento, el subtotal y el total a pagar por la factura.
 */
 
using System;

class Producto
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public double Valor { get; set; }
    public int CantidadExistente { get; set; }

    public Producto(string codigo, string nombre, double valor, int cantidadExistente)
    {
        Codigo = codigo;
        Nombre = nombre;
        Valor = valor;
        CantidadExistente = cantidadExistente;
    }
}

class Program
{
    static Producto[] productos = new Producto[]
    {
        //Aqui se pueden ingresar cuantos productos sean necesarios
        new Producto("1", "Leche", 1000, 1),
        new Producto("2", "Arroz", 2000, 7),
        new Producto("3", "Panela", 3000, 13),
        new Producto("4", "Huevos", 4000, 4),
        new Producto("5", "Aceite", 5000, 6),
        new Producto("6", "Marihuana", 6000, 14),
        new Producto("7", "Atún", 7000, 11)
    };

    static void Main(string[] args)
    {
        ProcesoCompra();
    }
    static void ProductosDisponibles()
    {
        Console.WriteLine("\nLista de artículos disponibles:");
        Console.WriteLine("Código\tNombre\t\t\tValor\t\t\tCantidad Existente");

        for (int i = 0; i < productos.Length; i++)
        {
            Console.WriteLine("{0}\t{1}\t\t\t{2}\t\t\t{3}", productos[i].Codigo, productos[i].Nombre, productos[i].Valor, productos[i].CantidadExistente);
        }
    }
    static void ProcesoCompra()
    {
        Console.WriteLine("Bienvenido a la facturación del almacén");

        double totalAPagar = 0, totalIVA = 0, totalDescuento = 0;

        while (true)
        {
            ProductosDisponibles();

            Console.Write("\nIngrese el código del artículo (0 para finalizar): ");
            string codigoArticulo = Console.ReadLine();

            if (codigoArticulo == "0")
                break;

            Producto articuloSeleccionado = null;
            for (int i = 0; i < productos.Length; i++)
            {
                if (productos[i].Codigo == codigoArticulo)
                {
                    articuloSeleccionado = productos[i];
                    break;
                }
            }

            if (articuloSeleccionado == null)
            {
                Console.WriteLine("Código de artículo inválido.");
                continue;
            }

            Console.Write("Ingrese la cantidad a comprar: ");
            int cantidadCompra = Convert.ToInt32(Console.ReadLine());

            if (cantidadCompra > articuloSeleccionado.CantidadExistente)
            {
                Console.WriteLine("La cantidad ingresada supera la cantidad existente en el almacén.");
                continue;
            }

            double subtotal = articuloSeleccionado.Valor * cantidadCompra;
            double iva = subtotal * 0.19; // 19% de IVA
            double descuento = subtotal >= 1000 ? subtotal * 0.1 : 0; // 10% de descuento si subtotal es mayor o igual a 1000
            double totalProducto = subtotal + iva - descuento;

            Facturar(subtotal, iva, descuento, totalProducto, cantidadCompra, articuloSeleccionado);

            totalAPagar += totalProducto;
            totalIVA += iva;
            totalDescuento += descuento;

            articuloSeleccionado.CantidadExistente -= cantidadCompra;
        }

        Console.WriteLine("\nResumen de la factura:");
        Console.WriteLine("Total a pagar: {0}", totalAPagar);
        Console.WriteLine("Total IVA: {0}", totalIVA);
        Console.WriteLine("Total descuento: {0}", totalDescuento);
    }
    static void Facturar(double subT, double iva, double dest, double totalProc, int CantC, Producto articuloSeleccionado)
    {
        Console.WriteLine("\nFactura para el artículo seleccionado:");
        Console.WriteLine("Código: {0}", articuloSeleccionado.Codigo);
        Console.WriteLine("Nombre: {0}", articuloSeleccionado.Nombre);
        Console.WriteLine("Valor unitario: {0}", articuloSeleccionado.Valor);
        Console.WriteLine("Cantidad: {0}", CantC);
        Console.WriteLine("IVA: {0}", iva);
        if (dest > 0)
            Console.WriteLine("Descuento: {0}", dest);
        Console.WriteLine("Subtotal: {0}", subT);
        Console.WriteLine("Total a pagar: {0}", totalProc);
    }

}
