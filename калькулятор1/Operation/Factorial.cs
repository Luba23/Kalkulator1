using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1.Operation
{
        public sealed class Factorial : Operation
    {
        public Factorial() : base("Факториал")
        {

        }

        public override double Run(params double[] numbers)
        {
            double result = 1;
            for (int i = 1; i <= numbers[0]; i++)
            {
                result *= i;
            }
            return result;
          
        }
    }
}
