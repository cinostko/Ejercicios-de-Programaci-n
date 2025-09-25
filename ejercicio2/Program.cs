using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2
{
    abstract class Figura
    {
        public string pepito { get; set; }

        public Figura(string xd)
        {
            pepito = pepito;
        }

        public abstract double CalcularArea();

        public override string ToString()
        {
            return $"{pepito}, Área: {CalcularArea():0.00}";
        }
    }

    class Rectangulo : Figura
    {
        public double baserectangulo { get; set; }
        public double Altura { get; set; }

        public Rectangulo(double baseRect, double altura) : base("rectángulo")
        {
            baserectangulo = baseRect;
            Altura = altura;
        }

        public override double CalcularArea()
        {
            return baserectangulo * Altura;
        }
    }
    class Cuadrado : Rectangulo
    {
        public Cuadrado(double lado) : base(lado, lado)
        {
            pepito = "cuadrado";
        }
    }
    class Circulo : Figura
    {
        public double Radio { get; set; }

        public Circulo(double radio) : base("circulo")
        {
            Radio = radio;
        }

        public override double CalcularArea()
        {
            return Math.PI * Math.Pow(Radio, 2);
        }
    }

    class Triangulo : Figura
    {
        public double BaseTriangulo { get; set; }
        public double Altura { get; set; }

        public Triangulo(double baseTri, double altura) : base("triungulo")
        {
            BaseTriangulo = baseTri;
            Altura = altura;
        }

        public override double CalcularArea()
        {
            return (BaseTriangulo * Altura) / 2;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Figura> figuras = new List<Figura>();
            int opcion;

            do
            {
                Console.WriteLine("\n--- menu de figuras ---");
                Console.WriteLine("1. agregar rectngulo");
                Console.WriteLine("2. agregar cuadrado");
                Console.WriteLine("3. agregar circulo");
                Console.WriteLine("4. agregar triángulo");
                Console.WriteLine("5. ver todas las figuras");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine(" ingrese un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("base: ");
                        double baseR = double.Parse(Console.ReadLine());
                        Console.Write("altura: ");
                        double alturaR = double.Parse(Console.ReadLine());
                        figuras.Add(new Rectangulo(baseR, alturaR));
                        break;

                    case 2:
                        Console.Write("lado: ");
                        double lado = double.Parse(Console.ReadLine());
                        figuras.Add(new Cuadrado(lado));
                        break;

                    case 3:
                        Console.Write("radio: ");
                        double radio = double.Parse(Console.ReadLine());
                        figuras.Add(new Circulo(radio));
                        break;

                    case 4:
                        Console.Write("base: ");
                        double baseT = double.Parse(Console.ReadLine());
                        Console.Write("altura: ");
                        double alturaT = double.Parse(Console.ReadLine());
                        figuras.Add(new Triangulo(baseT, alturaT));
                        break;

                    case 5:
                        Console.WriteLine("\n--- listado de figuras ---");
                        foreach (var figura in figuras)
                        {
                            Console.WriteLine(figura);
                        }
                        break;

                    case 6:
                        Console.WriteLine("saliendo");
                        break;

                    default:
                        Console.WriteLine("opción no valiida D:.");
                        break;
                }

            } while (opcion != 6);
        }
    }


}
