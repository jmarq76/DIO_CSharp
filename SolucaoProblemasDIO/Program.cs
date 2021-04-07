using System;

namespace SolucaoProblemasDIO
{
    class Program
    {
        static void Main(string[] args)
        {
            //VisitaFeira();
            //Tuitando();
            ValidacaoNota();
        }

        public static void VisitaFeira()
        {
            int a, b, x;
            string input;

            input = Console.ReadLine();

            var separte = input.Split(' ');

            a = int.Parse(separte[0]);
            b = int.Parse(separte[1]);

            x = a + b; //complete o código de acordo com o cálculo esperado

            Console.WriteLine("X = {0}", x);
        }

        public static void Tuitando()
        {
            string input = Console.ReadLine();
            int length = input.Length;

            if (length <= 140)
                {
                    Console.WriteLine("TWEET");
                }
            else
                {
                    Console.WriteLine("MUTE");
                }

        }

        public static void ValidacaoNota()
        {
            double nota = 0, soma = 0;
            int qtdNum = 0;
            
            while (qtdNum != 2)
            {
                nota = Convert.ToDouble(Console.ReadLine());

                if (nota >= 0 && nota <= 10)
                {
                    soma += nota;
                    qtdNum++;
                }
                else
                {
                    Console.WriteLine("nota invalida");
                }
            }
            Console.WriteLine("media = {0:0.00}", (soma/2));
        }
    }
}
