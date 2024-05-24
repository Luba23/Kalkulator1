using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1.Operation
{
    public sealed class Sin : Operation
    {
        public Sin() : base("Синус")
        {

        }

        public override double Run(params double[] numbers)
        {
            return Math.Sin(numbers[0]);
        }
    }

}
