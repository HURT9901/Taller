/*Un cajero electrónico por lo general determinar la cantidad mínima
* de billetes que le va a entregar, necesita un programa con solo la opción
* de retiro, que diga la cantidad de billetes y la denominación va a entregar
* al cliente. El cajero posee billetes de 50.000, 20.000, 10.000 y 5.000 pesos.
* La cantidad por retirar se debe digitar y el monto máximo a retirar es de 600.000 pesos.
* Si el valor restante está entre  4.999  y  2.500  pesos  se  aproxima  a  5.000  pesos
* y  si  es  de  2.499  a  1  se  trunca  a  0.    El  usuario  requiere registrarse al inicio
* del programa con el nombre y la clave para poder ingresar*/
class Cajero
{
    static void Main(string[] args)
    {
        /*En este caso el MAIN hará la toma de los datos e invocará
         * el validador de datos y demas metodos que se requieran.
         */
        string name, key;
        Console.WriteLine("Hola. Ingresa tus datos para poder continuar: \nNombre: ");
        name = Console.ReadLine();
        Console.WriteLine("Clave: ");
        key = Console.ReadLine();
        //Se "validan" los datos tomados para ingresar al cajero
        if (!validacionUsuario(name, key)) //si es falso entra
        {
            Console.WriteLine("Datos incorrectos. Intente mas tarde.\nHasta pronto.");
            return;//Termina el programa al no ser validos.
        }
        else
        {
            Retiro();//Invoca nuestro metodo para hacer retiros.
        }
    }
    static bool validacionUsuario(string n, string k)
    {
        /*Decido hacer este metodo porque se podria implentar una logica
         * de validacion, sin embargo en este caso siempre retornará
         * verdadero dado que el ejercicio no lo pide, pero es bueno
         * tenerlo en cuenta.
         */
        return true;
    }

    //Metodo para los retiros
    static void Retiro()
    {
        //declara un vector con la denomicacion de los billetes
        int[] billetes = new int[] { 50000, 20000, 10000, 5000 };
        string ext;
        int retiro;
        Console.WriteLine("Ingrese la cantidad a retirar (Maximo $600.000 por retiro): ");
        retiro = validacionIntPos();
        //Condicion para detenerminar si el retiro es valido o no
        if (retiro <= 0 || retiro > 600000)
        {
            /*Si no es valido el monto, entonces doy al usuario oportunidad de nuevo
             * intento, si asi no lo desea, puede cancelar la operacion.
             */
            Console.WriteLine("Monto no permitido. Intente nuevamente o cancele ingreando: '0' ");
            ext = Console.ReadLine();
            if (ext == "0")
            {
                Console.WriteLine("Hasta pronto.");
                return;//termina el programa
            }
            else
            {
                Retiro();//Se vuelve a llamar el metodo si el usuario deseo un nuevo intento
            }
        }
        else
        {
            //Variables para dar con el mensaje de cuales y que cantidad de billetes se daran
            int cantTemp = retiro, cantBill, i = 0;
            string mensaje = "|| Cantidad || ||  Denominación  ||: \n";
            //Mientras haya dinero que descontar
            while (cantTemp > 0)
            {
                /*divide el dinero entre la denominacion del billete y toma el entero
                 y asi damos con la cantidad de billetes de dicha denominacion
                 */
                cantBill = cantTemp / billetes[i];
                //se multiplica la cantidad por el billete y se le resta al dinero que tenemos
                //asi quedamos con el restante para dar con una nueva denominacion
                cantTemp = cantTemp - (cantBill * billetes[i]);
                if (cantBill > 0)
                {
                    mensaje += "||    " + cantBill + "    || ||   $" + billetes[i] + "      ||\n";
                    if (cantTemp >= 2500 && cantTemp <= 4999)//rango para redondear a 5000
                    {
                        mensaje += "||    1     || ||     5000     ||  (por redondeo positivo) ";
                        cantTemp = 0;
                    }
                    else if (cantTemp > 0 && cantTemp < 2500)//rango para redondear a 0
                    {

                        mensaje += "El valor restante se aproximó a 0 por redondeo negativo";
                        cantTemp = 0;
                    }
                }
                i++;
            }
            Console.WriteLine(mensaje + "\nEn un retiro de $" + retiro);
            Console.ReadKey();
            Console.WriteLine("Gracias por usar el cajero electronico. Vuelva pronto.");

            //Solucion alterna, IGNORAR.
            /*string mensaje = "Se daran: ";
            foreach (int i in billetes)
            {
                int cantBill = retiro / i;
                retiro %= i;
                if (cantBill > 0)
                {
                    mensaje += cantBill + " de " + i+"\n";
                }
            }*/
        }

    }
    static int validacionIntPos()
    {
        int i = 0;
        bool bandera = true;
        do
        {
            i = int.Parse(Console.ReadLine());
            if (i > 0)
            {
                bandera = false;
            }
            else
            {
                Console.WriteLine("Valor debe ser positivo. Intente de nuevo");
            }

        } while (bandera);
        return i;
    }
}
