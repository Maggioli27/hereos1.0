namespace hereos1._0.Tools
{
    using hereos1._0.Monstre;
    using System;
    using System.Collections.Generic;
    using static Carte;

        public class Generateur
    {
                private const int Taille = 15;

                public static void GenererMonstres(List<Personnage> monstres, Personnage joueur)
        {
            Random rand = new Random();

            while (monstres.Count < 10)
            {
                int x, y;
                bool positionValide;

                do
                {
                    x = rand.Next(Taille);
                    y = rand.Next(Taille);

                    positionValide = true;

                    foreach (Personnage monstre in monstres)
                    {
                        if (Math.Abs(monstre.X - x) < 2 && Math.Abs(monstre.Y - y) < 2)
                        {
                            positionValide = false;
                            break;
                        }
                    }

                    if (x == joueur.X && y == joueur.Y)
                    {
                        positionValide = false;
                    }

                } while (!positionValide);

                monstres.Add(CreerMonstreAleatoire(rand.Next(3), x, y));
            }
        }

                public static void GenererPotionsEtBonus(List<Potion> potions, List<Bonus> bonus, List<Personnage> monstres, Personnage joueur)
        {
            Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                int x, y;
                bool positionValide;

                do
                {
                    x = rand.Next(Taille);
                    y = rand.Next(Taille);
                    positionValide = true;

                    foreach (Potion potion in potions)
                    {
                        if (potion.X == x && potion.Y == y)
                        {
                            positionValide = false;
                            break;
                        }
                    }

                    foreach (Bonus b in bonus)
                    {
                        if (b.X == x && b.Y == y)
                        {
                            positionValide = false;
                            break;
                        }
                    }

                    foreach (Personnage monstre in monstres)
                    {
                        if (monstre.X == x && monstre.Y == y)
                        {
                            positionValide = false;
                            break;
                        }
                    }

                    if (x == joueur.X && y == joueur.Y)
                    {
                        positionValide = false;
                    }

                } while (!positionValide);

                potions.Add(new Potion(x, y));
            }

            for (int i = 0; i < 3; i++)
            {
                int x, y;
                bool positionValide;

                do
                {
                    x = rand.Next(Taille);
                    y = rand.Next(Taille);
                    positionValide = true;

                    foreach (Potion potion in potions)
                    {
                        if (potion.X == x && potion.Y == y)
                        {
                            positionValide = false;
                            break;
                        }
                    }

                    foreach (Bonus Bonus in bonus)
                    {
                        if (Bonus.X == x && Bonus.Y == y)
                        {
                            positionValide = false;
                            break;
                        }
                    }

                    foreach (Personnage monstre in monstres)
                    {
                        if (monstre.X == x && monstre.Y == y)
                        {
                            positionValide = false;
                            break;
                        }
                    }

                    if (x == joueur.X && y == joueur.Y)
                    {
                        positionValide = false;
                    }

                } while (!positionValide);

                bonus.Add(new Bonus(x, y));
            }
        }

                private static Personnage CreerMonstreAleatoire(int choix, int x, int y)
        {
            Personnage monstre;

            if (choix == 0)
            {
                monstre = new Loup();
            }
            else if (choix == 1)
            {
                monstre = new Orc();
            }
            else
            {
                monstre = new Dragonnet();
            }

            monstre.X = x;
            monstre.Y = y;
            return monstre;
        }
    }
}
