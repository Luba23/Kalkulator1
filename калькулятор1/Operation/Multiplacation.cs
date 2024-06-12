using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1.Operation
{
    public sealed class Multiplacation : Operation
    {
        public Multiplacation() : base("Умножение")
        {

        }
    
    public override double Run(params double[] numbers)
        {
        double result = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            result *= numbers[i];
        }
        return result;
        }
    }
}
