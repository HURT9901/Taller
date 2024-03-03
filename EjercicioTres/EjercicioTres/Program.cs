/*Realizar un programa para la facturación de un almacén. Los artículos deben manejasen con un vector de objetos
 * con los atributos código, nombre, valor y cantidad existente. El usuario solo debe ingresar el código
 * del articulo y la cantidad, al finalizar el proceso de compra se debe imprimir la factura con los datos
 * por artículo de: código, nombre, valor, cantidad, IVA y si posee descuento, el subtotal y el total a pagar por la factura.
 */
 
using System;

class Producto
{
    //Atributos de cada producto
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
        new Producto("1", "Leche", 3500, 12),
        new Producto("2", "Arroz", 3000, 25),
        new Producto("3", "Panela", 2000, 15),
        new Producto("4", "Huevos", 800, 40),
        new Producto("5", "Aceite", 4000, 9),
        new Producto("6", "Marihuana", 5000, 14),
        new Producto("7", "Atún", 6500, 11)
        //separar por "," cada uno de los productos
    };

    static void Main(string[] args)
    {
        //el main unicamente invoca el proceso de compra en este caso
        ProcesoCompra();
    }
    static void ProductosDisponibles()
    {
        //Este metodo muestra la lista de productos disponibles
        Console.WriteLine("\nLista de artículos disponibles:");
        Console.WriteLine("Código\tNombre\t\t\tValor\t\t\tCantidad Existente");

        for (int i = 0; i < productos.Length; i++)
        {
            //Recorre cada objeto y toma cada uno de sus atributos
            Console.WriteLine("{0}\t{1}\t\t\t{2}\t\t\t{3}", productos[i].Codigo, productos[i].Nombre, productos[i].Valor, productos[i].CantidadExistente);
        }
    }
    static void ProcesoCompra()
    {
        /*Aqui se da el proceso el cual indica lo que se va a comprar
         * si desea hacer mas compras o si quieres detenerse
         */
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
            //esta linea usa condicional ternario para asignar el valor del descuento
            double descuento = subtotal >= 100000 ? subtotal * 0.1 : 0; // 10% de descuento si subtotal es mayor o igual a 100000
            double totalProducto = subtotal + iva - descuento;
            
            //Invocamos el metodo que da lugar a la facturacion
            Facturar(subtotal, iva, descuento, totalProducto, cantidadCompra, articuloSeleccionado);

            //se acumula los valores que se pagaran o descontaran
            totalAPagar += totalProducto;
            totalIVA += iva;
            totalDescuento += descuento;

            //Aqui se reduce la cantidad existente del producto que se compró
            articuloSeleccionado.CantidadExistente -= cantidadCompra;
        }

        //Y por ultimo se muestra el resumen de la factura que es el acumulado de todas los costos y descuentos
        Console.WriteLine("\nResumen de la factura:");
        Console.WriteLine("Total a pagar: {0}", totalAPagar);
        Console.WriteLine("Total IVA: {0}", totalIVA);
        Console.WriteLine("Total descuento: {0}", totalDescuento);
    }
    static void Facturar(double subT, double iva, double dest, double totalProc, int CantC, Producto articuloSeleccionado)
    {
        //Este metodo me imprime la facturacion parcial de cada producto

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
    //El codigo del ejercio pudo ser mas corto haciendo concatenaciones, sin embargo funciona
    //En un futuro vere si reduzco el ejercicio

}
