using System;
using AcademyG.Week2.Lib;


namespace Academy.Week2.NumeriComplessi
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Parte Reale: ");
            string num1RealString = Console.ReadLine();
            double.TryParse(num1RealString, out double num1Real);

            Console.WriteLine("Parte Immaginaria: ");
            string num1ImgString = Console.ReadLine();
            double.TryParse(num1ImgString, out double num1Img);

            Console.WriteLine("Parte Reale: ");
            string num2RealString = Console.ReadLine();
            double.TryParse(num2RealString, out double num2Real);

            Console.WriteLine("Parte Immaginaria: ");
            string num2ImgString = Console.ReadLine();
            double.TryParse(num2ImgString, out double num2Img);

            Console.Write("Operazione (+, -, *, /): ");
            string operation = Console.ReadLine();

            ComplexNumber compl1 = ComplexNumber.CreateComplex(num1Real, num1Img);
            ComplexNumber compl2 = new ComplexNumber(num2Real, num2Img);
            ComplexNumber result;

            switch (operation)
            {
                case "+":
                    result = compl1.Sum(compl2);
                    Console.WriteLine($"Sum: ({result.ParteReale}, {result.ParteImmaginaria})");
                    break;
                case "-":
                    result = compl1.Difference(compl2);
                    Console.WriteLine($"Difference: ({result.ParteReale}, {result.ParteImmaginaria})");
                    break;
                case "*":
                    result = compl1.Product(compl2);
                    Console.WriteLine($"Product: ({result.ParteReale}, {result.ParteImmaginaria})");
                    break;
                case "/":
                    result = compl1.Division(compl2);
                    Console.WriteLine($"Division: ({result.ParteReale}, {result.ParteImmaginaria})");
                    break;
                default:
                    Console.WriteLine("Operazione non valida");
                    break;
            }

            Console.WriteLine($"Modulo di ({compl1.ParteReale}, {compl1.ParteImmaginaria}): {compl1.Modulo}");
            Console.WriteLine($"Coniugato di ({compl2.ParteReale}, {compl2.ParteImmaginaria}): ({compl2.Coniugato.ParteReale}, {compl2.Coniugato.ParteImmaginaria})");

            //string prova = "ciao";
            //string p = prova.Remove(0, 1);
            //string p2 = p.Remove(p.Length-1, 1);
            //Console.WriteLine(p2);

            ComplexNumber compl3 = new ComplexNumber("(1,2)");
            ComplexNumber compl4 = new ComplexNumber("(3,4)");

            ComplexNumber complOp = compl3 + compl4;
            Console.WriteLine($"Sum: ({complOp.ParteReale}, {complOp.ParteImmaginaria})");
            double d = (double)compl3; 
            Console.WriteLine($"Explicit cast compl3: {d}");
            d = 5;
            ComplexNumber compl5 = d;
            Console.WriteLine($"Implicit cast compl5: ({compl5.ParteReale},{compl5.ParteImmaginaria})");

        }
    }
}
