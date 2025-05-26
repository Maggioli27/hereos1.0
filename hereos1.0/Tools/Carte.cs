using hereos1._0;
using hereos1._0.Heros;
using hereos1._0.Tools;

public class Carte
{

    private const int Taille = 15;

    public List<Personnage> Monstres { get; private set; }

    public Personnage Joueur { get; private set; }

    public List<Potion> Potions { get; private set; }

    public List<Bonus> Effet { get; private set; }

    public class Potion
    {
        public int X { get; }

        public int Y { get; }

        public Potion(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Bonus
    {
        public int X { get; }

        public int Y { get; }

        public Bonus(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public Carte(string typeHeros)
    {
        if (typeHeros == "Humain")
        {
            Joueur = new Humain();
        }
        else
        {
            Joueur = new Nain();
        }

        Joueur.X = Taille / 2;
        Joueur.Y = Taille / 2;

        Monstres = new List<Personnage>();
        Potions = new List<Potion>();
        Effet = new List<Bonus>();

        Generateur.GenererMonstres(Monstres, Joueur);
        Generateur.GenererPotionsEtBonus(Potions, Effet, Monstres, Joueur);
    }

    public void AfficherCarte()
    {
        for (int i = 0; i < Taille; i++)
        {
            for (int j = 0; j < Taille; j++)
            {
                if (Joueur.X == i && Joueur.Y == j)
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("🦸‍   ");
                    Console.ResetColor();
                }
                else
                {
                    bool affiché = false;

                    foreach (Personnage monstre in Monstres)
                    {
                        if (monstre.X == i && monstre.Y == j && EstAdjacent(Joueur, monstre.X, monstre.Y))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(Abreviation(monstre.Name) + "   ");
                            Console.ResetColor();
                            affiché = true;
                            break;
                        }
                    }

                    if (!affiché)
                    {
                        foreach (Potion potion in Potions)
                        {
                            if (potion.X == i && potion.Y == j && EstAdjacent(Joueur, potion.X, potion.Y))
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("🧉   ");
                                Console.ResetColor();
                                affiché = true;
                                break;
                            }
                        }
                    }

                    if (!affiché)
                    {
                        foreach (Bonus bonus in Effet)
                        {
                            if (bonus.X == i && bonus.Y == j && EstAdjacent(Joueur, bonus.X, bonus.Y))
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("🅱️   ");
                                Console.ResetColor();
                                affiché = true;
                                break;
                            }
                        }
                    }

                    if (!affiché)
                    {
                        Console.Write("▫️   ");
                    }
                }
            }
            Console.WriteLine();
        }
    }

    private bool EstAdjacent(Personnage heros, int x, int y)
    {

        int distanceX = Math.Abs(heros.X - x);
        int distanceY = Math.Abs(heros.Y - y);

        return distanceX == 1 && distanceY == 1 || distanceX == 0 && distanceY == 1 || distanceX == 1 && distanceY == 0;
    }

    public void VerifierRamassage()
    {
        Potion potionARamasser = null;
        foreach (Potion potion in Potions)
        {
            if (potion.X == Joueur.X && potion.Y == Joueur.Y)
            {
                potionARamasser = potion;
                break;
            }
        }

        if (potionARamasser != null)
        {
            Joueur.RamasserPotion();
            Potions.Remove(potionARamasser);

        }

        Bonus bonusARamasser = null;
        foreach (Bonus bonus in Effet)
        {
            if (bonus.X == Joueur.X && bonus.Y == Joueur.Y)
            {
                bonusARamasser = bonus;
                break;
            }
        }

        if (bonusARamasser != null)
        {
            Joueur.GagnerBonus();
            Effet.Remove(bonusARamasser);

        }
    }

    public Personnage VerifierCombat()
    {
        foreach (Personnage monstre in Monstres)
        {
            if (monstre.X == Joueur.X && monstre.Y == Joueur.Y)
            {
                return monstre;
            }
        }
        return null;
    }

    private string Abreviation(string type)
    {
        if (type == "Loup")
        {
            return "🐺";
        }
        if (type == "Orc")
        {
            return "👹";
        }
        if (type == "Dragonnet")
        {
            return "🐲";
        }
        return "?";
    }
}
