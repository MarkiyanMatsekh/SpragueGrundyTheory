using System;
using System.Collections.Generic;

namespace GameTheory.UI.Parser.Expressions
{
    public class FullIteratorExpression : EvaluatableExpression, IEquatable<FullIteratorExpression>
    {
        public SimpleExpression IterateFrom { get;  private set; }
        public SimpleExpression IterateTo { get; private set; }
        public IteratorExpression IteratorExpression { get; private set; }

        public FullIteratorExpression(IteratorExpression iteratorExpression, SimpleExpression iterateFrom, SimpleExpression iterateTo)
        {
            IteratorExpression = iteratorExpression;
            IterateFrom = iterateFrom;
            IterateTo = iterateTo;
        }

        public override List<int> Evaluate(int n)
        {
            var result = new List<int>();
            int arg1 = IteratorExpression.HasVariable ? n : 0;

            int from = IterateFrom.Evaluate(n)[0],
                to = IterateTo.Evaluate(n)[0];

            for (int i = from; i <= to; i++)
            {
                result.Add(EvaluateSimpleOperation(arg1, IteratorExpression.OperationOnIterator,
                    EvaluateSimpleOperation(i, IteratorExpression.OperationOnArgument, IteratorExpression.Argument)));
            }

            return result;
        }

        #region Overrides

        public override string ToString()
        {
            return string.Format("{0},{1}..{2}",
                IteratorExpression,
                IterateFrom,
                IterateTo);
        }

        public bool Equals(FullIteratorExpression other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.IterateFrom, IterateFrom) && Equals(other.IterateTo, IterateTo) && Equals(other.IteratorExpression, IteratorExpression);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (FullIteratorExpression)) return false;
            return Equals((FullIteratorExpression) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = IterateFrom.GetHashCode();
                result = (result*397) ^ IterateTo.GetHashCode();
                result = (result*397) ^ IteratorExpression.GetHashCode();
                return result;
            }
        }

        #endregion
    }
}