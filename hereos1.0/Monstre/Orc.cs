namespace hereos1._0.Monstre
{
    using hereos1._0.Tools;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

        public class Orc : Personnage
    {
                public override int Or { get; set; }

                public Orc() : base("Orc", Personnage.CalculerStatistique(), Personnage.CalculerStatistique() + 1)
        {
            De de6 = new De(1, 6);
            Or = de6.Lance();
        }
    }
}
