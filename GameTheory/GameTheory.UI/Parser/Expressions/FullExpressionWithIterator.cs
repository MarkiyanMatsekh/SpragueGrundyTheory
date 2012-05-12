using System;
using System.Collections.Generic;

namespace GameTheory.UI
{
    public class FullExpressionWithIterator : ExpressionWithIterator, IEquatable<FullExpressionWithIterator>
    {
        public SimpleExpression IterateFrom;
        public SimpleExpression IterateTo;

        public FullExpressionWithIterator(ExpressionWithIterator exp)
        {
            this.Argument = exp.Argument;
            this.HasVariable = exp.HasVariable;
            this.Operation = exp.OperationOnIterator;
            this.OperationOnIterator = exp.OperationOnIterator;
        }

        public FullExpressionWithIterator()
        {
        }

        public List<int> Evaluate(int n)
        {
            var result = new List<int>();
            int arg1 = HasVariable ? n : 0;

            for (int i = IterateFrom.Evaluate(n); i <= IterateTo.Evaluate(n); i++)
            {
                result.Add(Evaluate(arg1, OperationOnIterator, Evaluate(i, Operation, Argument)));
            }

            return result;
        }

        public bool Equals(FullExpressionWithIterator other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IterateFrom.Equals(IterateFrom) && other.IterateTo.Equals(IterateTo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as FullExpressionWithIterator);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IterateFrom.GetHashCode();
                result = (result*397) ^ IterateTo.GetHashCode();
                return result;
            }
        }
    }
}