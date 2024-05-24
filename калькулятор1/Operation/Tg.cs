using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1.Operation
{
    public sealed class Tg : Operation
    {
        public Tg() : base("Тангенс")
        {

        }

        public override double Run(params double[] numbers)
        {
            return Math.Tan(numbers[0]);
        }
    }
}
