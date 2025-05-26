namespace hereos1._0.Heros
{
        public class Nain : Personnage
    {
                public int Or { get; private set; } = 0;

                public int Cuir { get; private set; } = 0;

                public Nain() : base("nain", Personnage.CalculerStatistique() + 2, Personnage.CalculerStatistique())
        {
        }

                public void RecupererButin(int or, int cuir)
        {
            Or += or;
            Cuir += cuir;
        }
    }
}
