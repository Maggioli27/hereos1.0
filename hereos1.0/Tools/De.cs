namespace hereos1._0.Tools
{
    using System;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

        internal class De
    {
                public int Minimum { get; }

                public int Maximum { get; }

                private Random random = new Random();

                public De(int min, int max)
        {
            Minimum = min;
            Maximum = max;
        }

                public int Lance()
        {
            return random.Next(Minimum, Maximum + 1);
        }
    }

}
