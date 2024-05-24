using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1.Operation
{
    public sealed class Addition : Operation
    {
        public Addition() : base("Сложение")
        {

        }

        public override double Run(params double[] numbers)
        {
            return numbers.Sum();
        }
    }
}
