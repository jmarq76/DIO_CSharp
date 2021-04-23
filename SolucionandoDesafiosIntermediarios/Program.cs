using System;

namespace SolucionandoDesafiosIntermediarios
{
    class Program
    {
        static void Main(string[] args)
        {
            //NotasMoedas();
            //TeoremaDivisaoEuclidian();
            FormulaBHaskara();
        }

        public static void TesteSelecao1()
        {
            string [] selections = Console.ReadLine().Split(' ');
            int A = int.Parse(selections[0]);
            int B = int.Parse(selections[1]);
            int C = int.Parse(selections[2]);
            int D = int.Parse(selections[3]);

            if (B > C && D > A && (C+D) > (A+B) && C > 0 && D > 0 && (A % 2) == 0)
            {
                Console.WriteLine("Valores aceitos");
            } else
            {
                Console.WriteLine("Valores nao aceitos");
            }
        }

        public static void Triangulo()
        {
            double a, b, c;
            string[] valor = Console.ReadLine().Split();
            a = Convert.ToDouble(valor[0]);
            b = Convert.ToDouble(valor[1]);
            c = Convert.ToDouble(valor[2]);

            if(( (a + b) > c ) && ( (a + c) > b ) && ( (b + c) > a )) //complete a condicional
            {
                Console.WriteLine("Perimetro = {0:0.0}",  a + b + c  ); //complete a saida
            }
            else
            {
                Console.WriteLine("Area = {0:0.0}",  ((a + b) / 2) * c ); //complete a saida
            }
        }

        public static void NotasMoedas()
        {
            double valor;
            int inteiro, auxNotas, auxMoedas;

            
            valor = Convert.ToDouble(Console.ReadLine());

            inteiro = (int)valor;
            valor *= 100;
            auxMoedas = (int)valor;


            Console.WriteLine("NOTAS:");
            Console.WriteLine("{0} nota(s) de R$ 100.00", inteiro/100);
            auxNotas = (inteiro % 100);
            Console.WriteLine("{0} nota(s) de R$ 50.00", auxNotas/50);
            auxNotas = (auxNotas % 50);
            Console.WriteLine("{0} nota(s) de R$ 20.00", auxNotas/20);
            auxNotas = (auxNotas % 20);
            Console.WriteLine("{0} nota(s) de R$ 10.00", auxNotas/10);
            auxNotas = (auxNotas % 10);
            Console.WriteLine("{0} nota(s) de R$ 5.00", auxNotas/5);
            auxNotas = (auxNotas % 5);
            Console.WriteLine("{0} nota(s) de R$ 2.00", auxNotas/2);
            auxNotas = (auxNotas % 2);
            

            Console.WriteLine("MOEDAS:");
            Console.WriteLine("{0} moeda(s) de R$ 1.00", auxNotas / 1);
            auxMoedas %= 100;
            Console.WriteLine("{0} moeda(s) de R$ 0.50", auxMoedas / 50);
            auxMoedas %= 50;
            Console.WriteLine("{0} moeda(s) de R$ 0.25", auxMoedas / 25);
            auxMoedas %= 25;
            Console.WriteLine("{0} moeda(s) de R$ 0.10", auxMoedas / 10);
            auxMoedas %= 10;
            Console.WriteLine("{0} moeda(s) de R$ 0.05", auxMoedas / 5);
            auxMoedas %= 5;
            Console.WriteLine("{0} moeda(s) de R$ 0.01", auxMoedas / 1);
            auxMoedas %= 1;
            

        }

        public static void TeoremaDivisaoEuclidian()
        {
            string[] valores = Console.ReadLine().Split(' ');
            int a = int.Parse(valores[0]);
            int b = int.Parse(valores[1]);
            int q, r;

           q = a / b;

           r = (a % b);

           if (r < 0)
           {
               double q1, r1 = 0.0;

               r1 = r + Math.Sqrt(b * b);
               q1 = (a - r1) / b;

               Console.WriteLine("{0} {1}", q1, r1);
           } else
           {
               Console.WriteLine("{0} {1}", q, r);
           }
        }

        public static void FormulaBHaskara()
        {
            double a, b, c, delta, r1, r2;
            string[] valor = Console.ReadLine().Split(' ');

            a = Convert.ToDouble(valor[0]);
            b = Convert.ToDouble(valor[1]);
            c = Convert.ToDouble(valor[2]);

            delta = (Math.Pow(b, 2) - (4 * a * c));
            r1 = (-b + Math.Sqrt(delta)) / (2 * a);
            r2 = (-b - Math.Sqrt(delta)) / (2 * a);

            if (a != 0 && delta > 0 )
            {
              Console.WriteLine("R1 = {0:0.00000}", r1);
              Console.WriteLine("R2 = {0:0.00000}", r2);
            }
            else
            {
                Console.WriteLine("Impossivel calcular");
            }
        }
    }
}
