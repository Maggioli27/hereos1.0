using hereos1._0.Fight;
using hereos1._0.Tools;

namespace hereos1._0;

public class Games
{
    public static void Start()
    {
        do
        {
            Console.Write("Choisissez un héros (Humain/Nain) : ");
            string Name = Console.ReadLine();
            Carte carte = new Carte(Name);
            Console.CursorVisible = false;

            while (carte.Joueur.EstVivant() && carte.Monstres.Count > 0)
            {
                Console.Clear();
                // Réaffichage des informations du héros
                Console.WriteLine($"Vous avez choisi un {Name}");
                Console.WriteLine();
                Console.WriteLine("\nStats de votre héros :");
                carte.Joueur.AfficherStats();
                Console.WriteLine();
                carte.AfficherCarte();
                carte.VerifierRamassage();
                Console.WriteLine();
                Console.WriteLine("Utilisez les flèches directionnelles pour vous déplacer. ");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Deplacement.DeplacerHeros(carte, keyInfo.Key);

                Personnage ennemi = null;
                foreach (Personnage monstre in carte.Monstres)
                {
                    if (monstre.X == carte.Joueur.X && monstre.Y == carte.Joueur.Y)
                    {
                        ennemi = monstre;
                        break; // Sortir dès qu'un monstre est trouvé
                    }
                }


                if (ennemi != null)
                {
                    Combat.Combattre(carte, ennemi);
                    Console.WriteLine("Appuyez sur une touche pour continuer...");
                    Console.ReadKey(); // Permet au joueur de voir le combat avant l'effacement
                }
            }

            Console.WriteLine();
            Console.WriteLine(carte.Joueur.EstVivant() ? "Vous avez battu tous les monstres ! ⭐" : "Vous êtes mort 💀...");
            Console.WriteLine();

            Console.WriteLine("Voulez-vous rejouer ? (Oui/Non)");
            Console.WriteLine();
            string choix = Console.ReadLine()?.ToUpper();
            if (choix != "OUI")
            {
                break;
            }

        } while (true);

        Console.WriteLine();
        Console.WriteLine("Merci d'avoir joué !");
    }
}
