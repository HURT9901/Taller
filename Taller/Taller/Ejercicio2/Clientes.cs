using System.Runtime.InteropServices;

class clientes
{


    public string nombre { get; set; }
    public string Genero { get; set; }
    public string numerocuenta { get; set; }
    public string tipocuenta { get; set; }
    public double Saldo { get; set; }


}
class Program
{
    static void Main(string[] args)
    {
        List<clientes> Clientes = new List<clientes>();

        Clientes.Add(new clientes { nombre = "Juan", Genero = "Masculino", numerocuenta = " 9123456789", tipocuenta = "Ahorro", Saldo = 1000000 });
        Clientes.Add(new clientes { nombre = "Marcela ", Genero = "Femenino", numerocuenta = "0310456789", tipocuenta = "Corriente", Saldo = -50000 });
        Clientes.Add(new clientes { nombre = "Juanito", Genero = "Masculino", numerocuenta = "0310383879", tipocuenta = "Ahorro", Saldo = 284000 });
        Clientes.Add(new clientes { nombre = "Gabriel", Genero = "Masculino", numerocuenta = "0320456678", tipocuenta = "Ahorro", Saldo = 5000000 });
        Clientes.Add(new clientes { nombre = "Francisco", Genero = "Masculino", numerocuenta = "0310383206", tipocuenta = "Corriente", Saldo = 900000 });
        Clientes.Add(new clientes { nombre = "Julieta", Genero = "Femenino", numerocuenta = "0305319254", tipocuenta = "Ahorro", Saldo = 500000 });
        Clientes.Add(new clientes { nombre = "Salome", Genero = "Femenino", numerocuenta = "9125677890", tipocuenta = "Corriente", Saldo = 100000 });

        string Tipocuenta = "";
        double saldototal = 0;
        string Nomayor = "";
        string Numayor = "";
        string Nomenor = "";
        string Numenor = "";
        double mayorsaldo = 0;
        double menorsaldo = 0;
        int cantHombres = 0;
        int cantMujeres = 0;
        double TotalM = 0;
        double TotalH = 0;
        double saldorojo = 0;
        double saldopositivo = 0;

        foreach (clientes cliente in Clientes)
        {
            saldototal = +cliente.Saldo;

            if (cliente.Saldo <= 0)
            {
                saldorojo++;

            }
            else
            {
                saldopositivo++;
            }
            if (cliente.Saldo > mayorsaldo)
            {
                mayorsaldo = cliente.Saldo;
                Nomayor = cliente.nombre;
                Numayor = cliente.numerocuenta;
                Tipocuenta = cliente.tipocuenta;


            }
            if (cliente.Saldo < menorsaldo)
            {
                menorsaldo = cliente.Saldo;
                Nomenor = cliente.nombre;

            }
            if (cliente.Genero == "Masculino")
            {
                TotalH += cliente.Saldo;
                cantHombres++;

            }
            else if (cliente.Genero == "Femenino")
                TotalM += cliente.Saldo;
            cantMujeres++;



        }
        double SaldoPromedio = saldototal / Clientes.Count;
        double PROMEDIOH = TotalH / cantHombres;
        double PromedioM = TotalM / cantMujeres;
        Console.WriteLine("");
        Console.WriteLine("El saldo promedio es de   :  " + SaldoPromedio);
        Console.WriteLine("El sado rojo o negativo es de   :    " + saldorojo);
        Console.WriteLine("El saldo positivo es de   :  " + saldopositivo);
        Console.WriteLine("La cuenta con menor saldo es de  :   " + menorsaldo + "   nombre   :   " + Nomenor + "   tipocuenta   :   " + Tipocuenta);
        Console.WriteLine("La cuenta con mayor saldo es de  : " + mayorsaldo + "   nombre    :   " + Nomayor + "   numerocuenta   :   " + Numayor + "  tipocuenta: " + Tipocuenta);
        Console.WriteLine("Promedio de saldos de hombres es de   : " + PROMEDIOH);
        Console.WriteLine("Promedio de saldos de mujeres es de   : " + PromedioM);
        Console.WriteLine("Total de hombres con cuenta bancaria   :    " + cantHombres + "  tipocuenta :" + Tipocuenta);

    }

}