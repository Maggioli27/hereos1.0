namespace hereos1._0.Monstre
{
    using hereos1._0.Tools;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Dragonnet : Personnage
    {
        public override int Or { get; set; }

        public override int Cuir { get; set; }
        // methode
        //test

        public Dragonnet() : base("Dragonnet", Personnage.CalculerStatistique() + 1, Personnage.CalculerStatistique())
        {
            De de4 = new De(1, 4);
            Cuir = de4.Lance();
            De de6 = new De(1, 6);
            Or = de6.Lance();
        }
    }
}
