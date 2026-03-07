using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese ubicación de los caballos: ");
        string entrada = Console.ReadLine();

        string[] caballos = entrada.Split(',');

        Dictionary<string, (int x, int y)> posiciones = new Dictionary<string, (int, int)>();

        foreach (string c in caballos)
        {
            int x = char.ToUpper(c[0]) - 'A';
            int y = int.Parse(c[1].ToString()) - 1;

            posiciones[c.ToUpper()] = (x, y);
        }

        int[][] movimientos = new int[][]
        {
            new int[] {2,1},
            new int[] {2,-1},
            new int[] {-2,1},
            new int[] {-2,-1},
            new int[] {1,2},
            new int[] {1,-2},
            new int[] {-1,2},
            new int[] {-1,-2}
        };

        foreach (var caballo in posiciones)
        {
            List<string> conflictos = new List<string>();

            foreach (var otro in posiciones)
            {
                if (caballo.Key == otro.Key)
                    continue;

                foreach (var m in movimientos)
                {
                    int nx = caballo.Value.x + m[0];
                    int ny = caballo.Value.y + m[1];

                    if (nx == otro.Value.x && ny == otro.Value.y)
                    {
                        conflictos.Add(otro.Key);
                    }
                }
            }

            if (conflictos.Count == 0)
            {
                Console.WriteLine($"Analizando Caballo en {caballo.Key} => Conflicto con ninguno");
            }
            else
            {
                Console.WriteLine($"Analizando Caballo en {caballo.Key} => Conflicto con {string.Join(", ", conflictos)}");
            }
        }
    }
}