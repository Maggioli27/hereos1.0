namespace hereos1._0.Monstre
{
    using hereos1._0.Tools;

    public class Loup : Personnage
    {
        public override int Cuir { get; set; }

        public Loup() : base("Loup", Personnage.CalculerStatistique(), Personnage.CalculerStatistique())
        {
            De de4 = new De(1, 4);
            Cuir = de4.Lance();

        }
    }
}
