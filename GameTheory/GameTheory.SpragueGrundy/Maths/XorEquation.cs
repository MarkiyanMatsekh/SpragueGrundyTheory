using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory.SpragueGrundy.Maths
{
    public class XorEquation
    {
        public List<int> Operands { get; private set; }

        public XorEquation(List<int> operands)
        {
            Operands = operands;
        }

        public XorEquation(params int[] operands)
        {
            Operands = new List<int>();
            if (operands != null)
                Operands.AddRange(operands);
        }

        public int Sum()
        {
            return Sum(exceptIndex: -1);
        }

        private int Sum(int exceptIndex)
        {
            return Operands.Where((t, i) => i != exceptIndex).Aggregate(0, (current, t) => current ^ t);
        }

        public List<ZeroResult> FindZeroResults( )
        {
            var result = new List<ZeroResult>();

            for (int i = 0; i < Operands.Count; i++)
            {
                var xorSum = Sum(i);
                if (xorSum < Operands[i])
                    result.Add(new ZeroResult(i, Operands[i], xorSum));
            }

            return result;
        }

        public XorEquation DoReplacement(ZeroResult zero)
        {
            var xorEquation = new XorEquation(Operands.ToArray());
            xorEquation.Operands[zero.Index] = zero.Replacement;
            return xorEquation;
        }

        public class ZeroResult
        {
            public int Index;
            public int OriginalNumber;
            public int Replacement;

            public ZeroResult(int index, int originalNumber, int replacement)
            {
                Index = index;
                OriginalNumber = originalNumber;
                Replacement = replacement;
            }
        }
    }
}
