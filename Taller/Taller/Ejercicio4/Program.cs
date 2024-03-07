// Realizar un programa para una editorial que publica libros y periódicos, en el programa se deben 
//manejar las siguientes variables: Número de hojas, valor hoja, hojas a color, titulo, tipo de portada,
//nombre autor, nombre periódico y fecha. Emplear una superclase publicaciones, dos subclases libro y 
//periódico La clase principal o editorial debe crear objetos tanto libro como periódico y calcular el costo 
//que se obtiene de: el valor de la hoja, el tipo de portada (sus valores son lujo = 10.000$, normal =
//5.000$ y económica = 3.000$) y si es a color cada hoja vales 200$ más que a blanco y negro



using System.ComponentModel.Design;
using static editorialpublicos.Libro;
using static editorialpublicos;

class editorialpublicos
{
    public int numeroHojas { get; set; }
    public double valorHojas { get; set; }



    public editorialpublicos(int Numerohojas, double Valorhojas)
    {

        numeroHojas = Numerohojas;
        valorHojas = Valorhojas;





    }
    public virtual double CalcularCosto() // metodo virtual se utiliza para modificar la forma en la que se declara el metodo 
    {
        return numeroHojas * valorHojas;
    }
    public class Libro : editorialpublicos
    {
        public int HojasColor { get; set; }
        public string Titulo { get; set; }
        public string tipoPortada { get; set; }
        public string Autor { get; set; }

        public Libro(int Numerohojas, double Valorhojas, int Hojascolor, string titulo, string Tipoportada, string autor) : base(Numerohojas, Valorhojas)
        //recordar que la base se utiliza para recordar los datos que se derivan de otra clase en este caso la clase editorialpublicos 
        {
            HojasColor = Hojascolor;
            Titulo = titulo;
            tipoPortada = Tipoportada;
            Autor = autor;
        }

        public class Periodico : editorialpublicos
        {

            public string Nombreperiodico { get; set; }
            public DateTime fecha { get; set; }


            public Periodico(int Numerohojas, double Valorhojas, string nombreperiodico, DateTime Fecha) : base(Numerohojas, Valorhojas)
            {
                Nombreperiodico = nombreperiodico;
                fecha = Fecha;
            }


        }
        public override double CalcularCosto()
        {
            double costoBase = base.CalcularCosto();
            double costoP = 0;

            switch (tipoPortada)
            {
                case "lujo":
                    costoP = 10000;
                    break;
                case "normal":
                    costoP = 5000;
                    break;
                case "economico":
                    costoP = 3000;
                    break;
            }

            double costoColor = HojasColor * 200;

            return costoBase + costoP + costoColor;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            // Creacion 
            Libro libro = new Libro(280, 2.1, 50, "Satanas", "lujo", "Mario Mendoza");
            Periodico periodico = new Periodico(50, 10, "El colombiano", DateTime.Now);
            Libro libro1 = new Libro(144, 13, 100, "Luces de bohemia", "economico", "de Ramón del Valle-Inclán");
            Periodico periodico2 = new Periodico(10, 21, "Espectador", DateTime.Now);

            // Calcular costo de la publicación
            double costol = libro.CalcularCosto();
            double costoP = periodico.CalcularCosto();
            double costo = libro1.CalcularCosto();
            double costop = periodico2.CalcularCosto();

            Console.WriteLine("El libro  satanas tiene un costo de : $" + costol);
            Console.WriteLine("El periodico  el colombiano tiene un costo de  : $" + costoP);
            Console.WriteLine("El libro  luces de bohemia tiene un costo de : $" + costo);
            Console.WriteLine("El periodico  el espectador tiene un costo de  : $" + costop);

        }
    }
}


