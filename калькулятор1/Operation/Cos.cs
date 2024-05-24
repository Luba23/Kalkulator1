using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1.Operation
{
    public sealed class Cos : Operation
    {
        public Cos() : base("Косинус")
        {

        }

        public override double Run(params double[] numbers)
        {
            return Math.Cos(numbers[0]);
        }
    }
}
