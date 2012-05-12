using System;
using System.Collections.Generic;

namespace GameTheory.UI.Parser.Expressions
{
    public class FullExpressionWithIterator : ExpressionWithIterator, IEquatable<FullExpressionWithIterator>
    {
        public SimpleExpression IterateFrom;
        public SimpleExpression IterateTo;

        public FullExpressionWithIterator(ExpressionWithIterator exp)
        {
            this.Argument = exp.Argument;
            this.HasVariable = exp.HasVariable;
            this.HasArgument = exp.HasArgument;
            this.Operation = exp.Operation;
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

        public override string ToString()
        {
            return string.Format("{0}{1}i{2}{3},{4}..{5}",
                                 HasVariable ? "x" : string.Empty,
                                 OperationOnIterator.Show(),
                                 Operation.Show(),
                                 HasArgument ? Argument.ToString() : string.Empty,
                                 IterateFrom,
                                 IterateTo);
        }
    }
}