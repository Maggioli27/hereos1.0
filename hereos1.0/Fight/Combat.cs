namespace hereos1._0.Fight
{
    internal class Combat
    {
        public static void Combattre(Carte carte, Personnage monstre)
        {

            Console.WriteLine($"\n ⚔️ Combat contre un {monstre.Name} !");
            Console.WriteLine();
            while (carte.Joueur.EstVivant() && monstre.EstVivant())
            {
                int degatsHeros = carte.Joueur.Frapper();
                monstre.RecevoirDommage(degatsHeros);
                Console.WriteLine($"Vous infligez ⚔️ {degatsHeros} dégâts. PV Monstre: ❤️‍ {monstre.Pv}");
                Console.WriteLine();

                if (!monstre.EstVivant()) break;

                int degatsMonstre = monstre.Frapper();
                carte.Joueur.RecevoirDommage(degatsMonstre);
                Console.WriteLine($"Le monstre riposte avec ⚔️ {degatsMonstre} dégâts. PV Héros: ❤️‍ {carte.Joueur.Pv}");
                Console.WriteLine();
            }

            if (carte.Joueur.EstVivant())
            {
                carte.Joueur.RecupererButin(monstre.Or, monstre.Cuir);
                Console.WriteLine("\nVous avez gagné le combat !");
                carte.Joueur.RecupererButin(monstre.Or, monstre.Cuir);
                Console.WriteLine($"Loot obtenu : {monstre.Or} or 🪙, {monstre.Cuir} cuir : 👜  ");
                Console.WriteLine();
                carte.Monstres.Remove(monstre);

            }
        }
    }

}
