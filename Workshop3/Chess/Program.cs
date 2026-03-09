using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese ubicación de los caballos: ");
        string input = Console.ReadLine().ToUpper();

        string[] posiciones = input.Split(',');

        Dictionary<string, (int x, int y)> caballos = new Dictionary<string, (int, int)>();

        foreach (var pos in posiciones)
        {
            int x = pos[0] - 'A';        
            int y = int.Parse(pos[1].ToString()) - 1; 
            caballos[pos] = (x, y);
        }

        int[,] movimientos =
        {
            {2,1},{2,-1},{-2,1},{-2,-1},
            {1,2},{1,-2},{-1,2},{-1,-2}
        };

        foreach (var caballo in caballos)
        {
            List<string> conflictos = new List<string>();

            foreach (var otro in caballos)
            {
                if (caballo.Key == otro.Key)
                    continue;

                int dx = otro.Value.x - caballo.Value.x;
                int dy = otro.Value.y - caballo.Value.y;

                for (int i = 0; i < movimientos.GetLength(0); i++)
                {
                    if (dx == movimientos[i, 0] && dy == movimientos[i, 1])
                    {
                        conflictos.Add(otro.Key);
                    }
                }
            }

            if (conflictos.Count > 0)
                Console.WriteLine($"Analizando Caballo en {caballo.Key} => Conflicto con {string.Join(", ", conflictos)}");
            else
                Console.WriteLine($"Analizando Caballo en {caballo.Key} => Conflicto con ninguno");
        }
    }
}