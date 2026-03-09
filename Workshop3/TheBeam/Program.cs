using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Ingrese la viga: ");
            string viga = Console.ReadLine();

            char baseViga = viga[0];

            int resistencia = 0;

            switch (baseViga)
            {
                case '%': resistencia = 10; break;
                case '&': resistencia = 30; break;
                case '#': resistencia = 90; break;
                default:
                    Console.WriteLine("Base inválida");
                    continue;
            }

            int pesoTotal = 0;
            int conexionesSeguidas = 0;
            bool malConstruida = false;

            for (int i = 1; i < viga.Length; i++)
            {
                char c = viga[i];

                if (c == '=')
                {
                    pesoTotal += 1;
                    conexionesSeguidas = 0;
                }
                else if (c == '*')
                {
                    conexionesSeguidas++;

                    if (conexionesSeguidas > 2)
                    {
                        malConstruida = true;
                        break;
                    }
                }
                else
                {
                    malConstruida = true;
                    break;
                }
            }

            if (malConstruida)
            {
                Console.WriteLine("La viga está mal construida!");
            }
            else if (pesoTotal <= resistencia)
            {
                Console.WriteLine("La viga soporta el peso!");
            }
            else
            {
                Console.WriteLine("La viga NO soporta el peso!");
            }

            Console.WriteLine();
        }
    }
}