namespace hereos1._0
{
    using hereos1._0.Tools;
    using System;

    public class Personnage
    {
        public int endurance;

        public int force;

        private int pointsDeVie;

        public int Pv
        {
            get { return pointsDeVie; }
            private set { pointsDeVie = Math.Max(0, value); }
        }

        public virtual int Or { get; set; }

        public virtual int Cuir { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public string Name { get; }

        public static int CalculerStatistique()
        {
            De de = new De(1, 6);
            int[] lancers = { de.Lance(), de.Lance(), de.Lance(), de.Lance() };
            Array.Sort(lancers);
            return lancers[1] + lancers[2] + lancers[3];
        }

        public static int CalculerModificateur(int valeur)
        {
            if (valeur < 5) return -1;
            if (valeur < 10) return 0;
            if (valeur < 15) return 1;
            return 2;
        }

        public Personnage(string name, int bonusEndurance = 0, int bonusForce = 0)
        {
            Name = name;
            endurance = CalculerStatistique() + bonusEndurance;
            force = CalculerStatistique() + bonusForce;
            Pv = endurance * 2 + CalculerModificateur(endurance);
        }

        public int Frapper()
        {
            De d4 = new De(1, 4);
            return d4.Lance() + CalculerModificateur(force);
        }

        public void RecevoirDommage(int degats)
        {
            Pv -= degats;
        }

        public bool EstVivant()
        {
            return Pv > 0;
        }

        public void RecupererButin(int or, int cuir)
        {
            this.Or += or;
            this.Cuir += cuir;
        }

        public void AfficherStats()
        {
            Console.WriteLine($"⚡: {endurance}");
            Console.WriteLine($"💪 : {force}");
            Console.WriteLine($"❤️‍ : {Pv}");
        }

        public void RamasserPotion()
        {
            Pv = endurance * 2 + CalculerModificateur(endurance);
            Console.WriteLine("Vous avez bu la potion, vous avez récupéré toute votre vie !");
        }

        public void GagnerBonus()
        {
            Random rand = new Random();
            if (rand.Next(2) == 0)
            {
                force += 3;
                Console.WriteLine("Votre force a augmenté de 3 !");
            }
            else
            {
                Pv += 40;
                Console.WriteLine("Vos Hp ont augmenté de 40 !");
            }
        }
    }
}
