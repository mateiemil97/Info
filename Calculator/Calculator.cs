using System;

namespace Calculator
{
    public class Calcul : ICalculator
    {
        private ICalculator _clc;

        public Calcul(ICalculator clc)
        {
            _clc = clc;
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
