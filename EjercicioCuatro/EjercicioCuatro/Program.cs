/*Realizar  un  programa  para  una  editorial  que  publica  libros  y  periódicos,
 * en  el  programa  se  deben  manejar  las  siguientes  variables:
 * Número  de  hojas,  valor  hoja,  hojas  a  color,  titulo,  tipo  de  portada,
 * nombre autor, nombre periódico y fecha. Emplear una superclase publicaciones,
 * dos subclases libro y periódico La clase principal o editorial debe crear objetos
 * tanto libro como periódico y calcular el costo que  se  obtiene  de:
 * el  valor  de  la  hoja,  el  tipo  de  portada  (sus  valores  son
 * lujo  =  10.000$,  normal  =  5.000$ y económica = 3.000$)
 * y si es a color cada hoja vales 200$ más que a blanco y negro 
 */
class Publicacion
{
    //
    public int NumHojas { get; set; }
    public string HojasColor { get; set; }
    public double ValorHoja { get; set; }
    public Publicacion(int numHojas, string hojasColor, double valorHoja )
    {
        NumHojas = numHojas;
        HojasColor = hojasColor;
        ValorHoja = valorHoja;
    }
    public double PrecioCalcular()
    {
        double precioH = NumHojas * ValorHoja;
        double precioP = 0;
        if ( HojasColor.ToLower() == "si" )
        {
            precioH += NumHojas * 200;
        }
        return precioH + precioP;
    }
}
class Libro : Publicacion
{
    public string Titulo { get; set; }
    public string TipoPortada { get; set; }
    public string NombreAutor { get; set; }
    public Libro(int numHojas, string hojasColor, double valorHoja, string titulo, string tipoPortada, string nombreAutor)
        : base(numHojas, hojasColor, valorHoja)
    {
        Titulo = titulo;
        TipoPortada = tipoPortada;
        NombreAutor = nombreAutor;
    }
    public double PrecioCalcular()
    {
        double precioP = 0;
        switch (TipoPortada.ToLower()) 
        {
            case "lujo":
                precioP = 10000;
                break;
            case "normal":
                precioP = 5000;
                break;
            case "economica":
                precioP = 3000;
                break;
            default:
                Console.WriteLine("No es valido el tipo de portada.");
                break;
        }
        return base.PrecioCalcular() + precioP;
    }
}
class Periodico : Publicacion
{
    public string NomPeriodico { get; set; }
    public string Fecha { get; set; }

    public Periodico(int numHojas, string hojasColor, double valorHoja, string nomPeriodico, string fecha)
        : base(numHojas, hojasColor, valorHoja)
    {
        NomPeriodico = nomPeriodico;
        Fecha = fecha;
    }
}
class Principal
{
    static void Main(string[] args)
    {
        Validaciones obj = new Validaciones();
        //Variables para LIBROS
        //---------------------------------------
        string tituloL, tipoPL, nomAutorL, hojasCoL;
        int numHojL;
        double valorHojL;
        //---------------------------------------
        //variables para PERIODICO
        //---------------------------------------
        string nomP, fechaP, hojasCoP;
        int numHojP;
        double valorHojP;
        /*----------------------------------------------------------------------------------------
         ----------------------------------------------------------------------------------------*/
        Console.WriteLine("Factuaracion de la Editorial\n\nInformacion sobre el libro\n\nTitulo:");
        tituloL = Console.ReadLine();
        Console.WriteLine("Numero de hojas: ");
        numHojL = obj.ValidarIntPos();
        Console.WriteLine("Valor de cada hoja: ");
        valorHojL = obj.ValidarDoublePos();
        Console.WriteLine("Hojas a color( si o no ): ");
        hojasCoL = obj.ValidarOpcion();
        Console.WriteLine("Tipo de portada (lujo/normal/economica): ");
        tipoPL = Console.ReadLine();
        Console.WriteLine("Nombre del autor: ");
        nomAutorL = Console.ReadLine();
        Libro libro = new Libro(numHojL,hojasCoL,valorHojL,tituloL,tipoPL,nomAutorL);
        /*------------------------------------------------------------------------------------------
         ------------------------------------------------------------------------------------------*/
        Console.WriteLine("\nDatos del periodico\n\nNombre del periodico: ");
        nomP = Console.ReadLine();
        Console.WriteLine("Numero de hojas: ");
        numHojP = obj.ValidarIntPos();
        Console.WriteLine("Valor por hoja: ");
        valorHojP = obj.ValidarDoublePos() ;
        Console.WriteLine("Hojas a color( si o no): ");
        hojasCoP = obj.ValidarOpcion();
        Console.WriteLine("Fecha del periodico(dd/mm/yyyy)");
        fechaP = Console.ReadLine();

        Periodico periodico = new Periodico(numHojP,hojasCoP,valorHojP,nomP,fechaP);
        /*-----------------------------------------------------------------------------------------
         ------------------------------------------------------------------------------------------*/
        Console.WriteLine("\nESTE ES EL TOTAL A PAGAR POR CADA ARTICULO:\n");
        Console.WriteLine("\nPrecio del libro: "+ libro.PrecioCalcular());
        Console.WriteLine("\nPrecio del periodico: "+ periodico.PrecioCalcular());    
    }
}

//Esta clase es solo para hacer validaciones. IGNORAR.
class Validaciones
{
    public Validaciones() { }
    public int ValidarIntPos()
    {
        int x;
        do
        {
            x = Convert.ToInt32(Console.ReadLine());
            if (x >= 0)
            {
                return x;
            }
            else
            {
                Console.WriteLine("Numero debe ser postivo. Intente de nuevo.");
            }
        }while(true);
    }
    public double ValidarDoublePos()
    {
        double x;
        do
        {
            x = Convert.ToDouble(Console.ReadLine());
            if (x >= 0)
            {
                return x;
            }
            else
            {
                Console.WriteLine("Numero debe ser postivo. Intente de nuevo.");
            }
        } while (true);
    }
    public string ValidarOpcion()
    {
        string x;
        do
        {
            x = Convert.ToString(Console.ReadLine());
            if (x.ToLower()=="si" || x.ToLower()=="no")
            {
                return x;
            }
            else
            {
                Console.WriteLine("Por favor, responda si o no.");
            }
        }while (true);
    }
}
