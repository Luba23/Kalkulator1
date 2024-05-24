using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1.Operation
{
    public sealed class Substraction : Operation
    {
        public Substraction() : base("Вычитание")
        {

        }

        public override double Run(params double[] numbers)
        {
            double result = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                result -= numbers[i];
            }
            return result;
        }
    }
}
