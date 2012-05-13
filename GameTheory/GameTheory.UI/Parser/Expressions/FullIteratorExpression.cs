using System;
using System.Collections.Generic;

namespace GameTheory.UI.Parser.Expressions
{
    public class FullIteratorExpression : EvaluatableExpression, IEquatable<FullIteratorExpression>
    {
        public IteratorRangeExpression Range { get; private set; }
        public IteratorBodyExpression Body { get; private set; }

        public FullIteratorExpression(IteratorBodyExpression body, IteratorRangeExpression range)
        {
            Body = body;
            Range = range;
        }

        public FullIteratorExpression(IteratorBodyExpression body, SimpleExpression from, SimpleExpression to)
        {
            Body = body;
            Range = new IteratorRangeExpression(from, to);
        }

        public override List<int> Evaluate(int n)
        {
            var result = new List<int>();

            int from = Range.From.Evaluate(n)[0],
                to = Range.To.Evaluate(n)[0];

            for (int i = from; i <= to; i++)
            {
                var value = EvaluateInteratorBodyExpression(Body, n, i);
                result.Add(value);
            }

            return result;
        }

        public static int EvaluateInteratorBodyExpression(IteratorBodyExpression body, int n, int i)
        {
            var firstPart =
                    body.HasVariable
                        ? EvaluateSimpleOperation(n, body.OperationOnIterator, i)
                        : EvaluateNoOperation(i);

            var secondPart =
                body.HasArgument
                    ? EvaluateSimpleOperation(firstPart, body.OperationOnArgument, body.Argument)
                    : EvaluateNoOperation(firstPart);

            return secondPart;
        }

        #region Overrides

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", Body, GameLogicParser.PartsSeparator, Range);
        }

        public bool Equals(FullIteratorExpression other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Range, Range) && Equals(other.Body, Body);
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
                return (Range.GetHashCode()*397) ^ Body.GetHashCode();
            }
        }

        #endregion
    }
}