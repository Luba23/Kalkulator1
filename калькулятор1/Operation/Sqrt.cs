using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1.Operation
{
    public sealed class Sqrt : Operation
    {
        public Sqrt() : base("Квадратный корень")
        {

        }

        public override double Run(params double[] numbers)
        {
            return Math.Sqrt(numbers[0]);
        }
    }
}
