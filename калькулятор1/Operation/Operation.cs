using CalculatorCsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculator1.Operation
{
    public abstract class Operation : IOperation
    {
        public Operation(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract double Run(params double[] numbers);
    }

}
