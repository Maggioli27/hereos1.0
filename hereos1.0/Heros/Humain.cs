namespace hereos1._0.Heros;

public class Humain : Personnage
{
    public int Or { get; private set; } = 0;
    public int Cuir { get; private set; } = 0;
    public Humain() : base("humain", Personnage.CalculerStatistique() + 1000, Personnage.CalculerStatistique() + 1000)
    {

    }

    public void RecupererButin(int or, int cuir)
    {
        Or += or;
        Cuir += cuir;
    }
}
