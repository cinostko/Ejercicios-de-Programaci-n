using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Programacion_Semana1_Ejercicio
{
    class rectangulo
    {
        private double _base;
        private double _altura;

        public rectangulo(double b, double a)
        {
            _base = b;
            _altura = a;
        }

        public double calcularArea()
        {
            return _base + _altura;
        }
    }

    class circulo
    {
        private double _radio;

        public circulo(double r)
        {
            _radio = r;
        }

        public double calcularArea()
        {
            double pi = 3.1416;
            return pi * _radio * _radio;
        }
    }

    class Triangulo
    {
        private double _base;
        private double _altura;

        public Triangulo(double b, double a)
        {
            _base = b;
            _altura = a;
        }

        public double CalcularArea()
        {
            return (_base * _altura) / 2;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Seleccione una figura para calcular el areaa:");
                Console.WriteLine("1. rectángulo");
                Console.WriteLine("2. círculo");
                Console.WriteLine("3. triángulo");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("ingresar la base del rectángulo: ");
                        double baseRect = Convert.ToDouble(Console.ReadLine());

                        Console.Write("ingresar la altura del rectángulo: ");
                        double alturaRect = Convert.ToDouble(Console.ReadLine());

                        rectangulo rect = new rectangulo(baseRect, alturaRect);
                        Console.WriteLine("area, del rectángulo: " + rect.calcularArea());
                        break;

                    case "2":
                        Console.Write("ingresar el radio del círculo: ");
                        double radio = Convert.ToDouble(Console.ReadLine());

                        circulo circ = new circulo(radio);
                        Console.WriteLine("area del círculo: " + circ.calcularArea());
                        break;

                    case "3":
                        Console.Write("ingresar la base del triángulo: ");
                        double baseTri = Convert.ToDouble(Console.ReadLine());

                        Console.Write("ingresar la altura del triángulo: ");
                        double alturaTri = Convert.ToDouble(Console.ReadLine());

                        Triangulo tri = new Triangulo(baseTri, alturaTri);
                        Console.WriteLine("area del triángulo: " + tri.CalcularArea());
                        break;

                    default:
                        Console.WriteLine("opcion invalida intenta nuevamente.");
                        break;
                }

                Console.Write("\n¿quieres calcular otra figura? (s/n): ");
                string respuesta = Console.ReadLine().ToLower();

                if (respuesta != "s")
                {
                    continuar = false;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Programa finalizadoo :D . Presione una tecla para salir");
            Console.ReadKey();
        }
    }


}
