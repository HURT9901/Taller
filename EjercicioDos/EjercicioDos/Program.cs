/*Una  entidad  bancaria  requiere  analizar  en  comportamiento  de  sus  ahorradores,
 * por  cada  cliente  se  posee: el saldo, el número de la cuenta, el género y nombre.
 * Se solita hallar las siguientes estadísticas:
 * • Saldo promedio.
 * • Cuántos tienen saldo rojo o negativo.
 * • Cuántos tienen saldo positivo o mayor o igual a cero.
 * • Cuál es el menor saldo y su nombre.
 * • Cuál es el mayor saldo, el nombre y número de cuenta
 * • Promedio de saldos de los hombres y de las mujeres. 
 */
class Cliente
{
    //Atributos de CLIENTES
    public string NumeroCuenta { get; set; }
    public string Nombre { get; set; }
    public string Genero { get; set; }
    public double Saldo { get; set; }
    
    public Cliente(string numeroCuenta, string nombre, string genero, double saldo)
    {
        NumeroCuenta = numeroCuenta;
        Nombre = nombre;
        Genero = genero;
        Saldo = saldo;
    }
}
class Banco
{
    //Vector donde almacenaremos cada cliente
    public Cliente[] clientes;
    public int CantClientes;
    public Banco(int tamaño)
    {
        clientes = new Cliente[tamaño];
        CantClientes = 0;
    }
    //Este metodo añade un cliente, en este caso lo llenamos manualmente en el codigo
    public void AddCliente(Cliente cliente)
    {
        clientes[CantClientes] = cliente;
        CantClientes++;
    }
    
    public double CalcularPromedio()
    {
        double AcumSaldos = 0;
        for (int i = 0; i < CantClientes; i++)
        {
            AcumSaldos += clientes[i].Saldo;
        }
        //Operador ternario para evitar la division por 0
        return CantClientes > 0 ? AcumSaldos/CantClientes: 0;
    }
    public int NegativosContar()
    {
        int cont = 0;
        for (int i = 0; i < CantClientes; i++)
        {
            if (clientes[i].Saldo < 0)
            {
                cont++;
            }
        }
        return cont;
    }
    public int PositivosContar()
    {
        int cont = 0;
        for (int i = 0; i< CantClientes; i++)
        {
            if (clientes[i].Saldo >= 0) 
            {
                cont++;
            }
        }
        return cont;
    }
    public Cliente MenorSaldo()
    {
        Cliente MenorSaldo = clientes[0];
        for (int i = 1; i < CantClientes; i++)
        {
            if (clientes[i].Saldo < MenorSaldo.Saldo)
            {
                MenorSaldo = clientes[i];
            }
        }
        return MenorSaldo;
    }
    public Cliente MayorSaldo()
    {
        Cliente MayorSaldo = clientes[0];
        for (int i = 1; i < CantClientes; i++)
        {
            if (clientes[i].Saldo > MayorSaldo.Saldo)
            {
                MayorSaldo = clientes[i];
            }
        }
        return MayorSaldo;
    }

    //Este metodo toma cada mujer y/u hombre para tomar cada saldo y sacar sus promedios
    public double PromSaldosGenero(string genero)
    {
        double acumSaldos = 0;
        int cont = 0;
        for (int i = 1; i < CantClientes; i++)
        {
            if (clientes[i].Genero.Equals(genero))
            {
                acumSaldos += clientes[i].Saldo;
                cont++;
            }
        }
        //Ternario para evitar division por 0
        return cont > 0 ? acumSaldos/cont : 0;
    }
}
class Principal
{
    static void Main(string[] args)
    {
        string opc;
        Console.WriteLine("\t\tBienvenido. Este programa analiza el comportamiento de tus ahorradorres\n\t\tRECUERDA que cada cliente se encuentra en el sistema\n" +
            "¿Deseas continuar?(si o no)");
        opc = Console.ReadLine();
        if(opc.ToLower() == "si")
        {
            Proceso();
        }
        else
        {
            Console.WriteLine("Hasta pronto.");
            Console.ReadKey();
        }
    }
    static void Proceso()
    {
        /*Aqui la estancia de la clase BANCO,
         * en este caso le envio el 20 la cual
         * es la cantidad de clientes pero
         * perfectamente puede ser el tamaño que 
         * se desee
        */
        Banco objBanco = new Banco(20);

        //Aqui podemos agregar clientes
        objBanco.AddCliente(new Cliente("001", "Julian", "Masculino", 100000));
        objBanco.AddCliente(new Cliente("002", "Arturo", "Masculino", 200000));
        objBanco.AddCliente(new Cliente("003", "Maria", "Femenino", 20000));
        objBanco.AddCliente(new Cliente("004", "Marta", "Femenino", -1200));
        objBanco.AddCliente(new Cliente("005", "Carla", "Femenino", -2000));
        objBanco.AddCliente(new Cliente("006", "Daniel", "Masculino", -8000));
        objBanco.AddCliente(new Cliente("007", "Brayan", "Masculino", 2000000));
        objBanco.AddCliente(new Cliente("008", "Santiago", "Maculino", -1000000));
        objBanco.AddCliente(new Cliente("009", "Luisa", "Femenino", 120000));
        objBanco.AddCliente(new Cliente("010", "Elizabeth", "Femenino", 1100));
        objBanco.AddCliente(new Cliente("011", "Sebastian", "Masculino", 55500));
        objBanco.AddCliente(new Cliente("012", "laura", "Femenino", 300000));
        objBanco.AddCliente(new Cliente("013", "Tomás", "Masculino", 100000));
        //...
        //y aqui hacemos uso de nuestros metodos
        Console.WriteLine("Saldo Promedio: "+ objBanco.CalcularPromedio());
        Console.WriteLine("Clientes con saldo NEGATIVO: "+ objBanco.NegativosContar());
        Console.WriteLine("Clientes con saldo POSITIVO o IGUAL a CERO: " + objBanco.PositivosContar());

        Cliente menor = objBanco.MenorSaldo();
        Console.WriteLine("Cliente con el saldo MENOR: "+ menor.Nombre + " con $"+ menor.Saldo);

        Cliente mayor = objBanco.MayorSaldo();
        Console.WriteLine("Cliente con el saldo MAYOR: "+ mayor.Nombre + " con $"+ mayor.Saldo);

        Console.WriteLine("Promedio del saldo de los HOMBRES: " + objBanco.PromSaldosGenero("Masculino"));
        Console.WriteLine("Promedio del saldo de las MUJERES: " + objBanco.PromSaldosGenero("Femenino"));
    }
}