using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace hereos1._0.Tools;

class Deplacement
{

    public static void DeplacerHeros(Carte carte, ConsoleKey key)
    {
        int newX = carte.Joueur.X;
        int newY = carte.Joueur.Y;

        switch (key)
        {
            case ConsoleKey.UpArrow: newX = Math.Max(0, newX - 1); break;
            case ConsoleKey.DownArrow: newX = Math.Min(14, newX + 1); break;
            case ConsoleKey.LeftArrow: newY = Math.Max(0, newY - 1); break;
            case ConsoleKey.RightArrow: newY = Math.Min(14, newY + 1); break;
            default: return;
        }

        carte.Joueur.X = newX;
        carte.Joueur.Y = newY;
    }
}
