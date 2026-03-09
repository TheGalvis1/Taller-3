using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese la viga: ");
        string? viga = Console.ReadLine();


        char baseViga = viga[0];

        int resistencia = 0;

        switch (baseViga)
        {
            case '%': resistencia = 10; break;
            case '&': resistencia = 30; break;
            case '#': resistencia = 90; break;
            default:
                Console.WriteLine("Base inválida");
                return;
        }

        int pesoTotal = 0;
        int secuenciaLargueros = 0;
        int conexionesSeguidas = 0;

        for (int i = 1; i < viga.Length; i++)
        {
            char c = viga[i];

            if (c == '=')
            {
                secuenciaLargueros++;
                conexionesSeguidas = 0;
                pesoTotal += secuenciaLargueros;
            }
            else if (c == '*')
            {
                conexionesSeguidas++;

                if (conexionesSeguidas > 2)
                {
                    Console.WriteLine("La viga está mal construida!");
                    return;
                }

                pesoTotal += secuenciaLargueros * 2;
            }
            else
            {
                Console.WriteLine("Carácter inválido");
                return;
            }
        }

        if (pesoTotal <= resistencia)
            Console.WriteLine("La viga soporta el peso!");
        else
            Console.WriteLine("La viga NO soporta el peso!");
    }
}
