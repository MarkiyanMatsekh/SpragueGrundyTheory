using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GameTheory.UI.Parser.Expressions
{
    public class GameSumExpression : EvaluatableExpression, IEquatable<GameSumExpression>
    {
        public ReadOnlyCollection<IteratorBodyExpression> BodyExpressions { get; private set; }
        public IteratorRangeExpression Range { get; private set; }
        public Func<int, int, int> MergeTool { get; private set; }

        private readonly int _mergeNeutralElement;

        public GameSumExpression(IEnumerable<IteratorBodyExpression> expressions, SimpleExpression iterateFrom, SimpleExpression iterateTo,
            Func<int, int, int> mergeTool, int mergeNeutralElement)
        {
            BodyExpressions = expressions.ToList().AsReadOnly();
            Range = new IteratorRangeExpression(iterateFrom, iterateTo);
            MergeTool = mergeTool;
            _mergeNeutralElement = mergeNeutralElement;
        }
        public GameSumExpression(IEnumerable<IteratorBodyExpression> expressions, SimpleExpression iterateFrom, SimpleExpression iterateTo)
            : this(expressions, iterateFrom, iterateTo, (a,b) => a ^ b, 0)
        {
        }

        public override List<int> Evaluate(int x)
        {
            var result = new List<int>();

            int from = Range.From.Evaluate(x)[0],
                to = Range.To.Evaluate(x)[0];

            for (int i = from; i <= to; i++)
            {
                int sum = (from exp in BodyExpressions
                           let arg1 = exp.HasVariable ? x : 0
                           select EvaluateSimpleOperation(arg1, exp.OperationOnIterator, 
                                    EvaluateSimpleOperation(i, exp.OperationOnArgument, exp.Argument)))
                                  .Aggregate(_mergeNeutralElement, (current, res) => MergeTool(current, res));
                
                result.Add(sum);
            }

            return result;
        }

        #region Overrides

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var expression in BodyExpressions)
                sb.Append(GameLogicParser.GameDelimiterSymbol).Append(expression.ToString());
            var expressions = sb.ToString().Substring(1);

            return string.Format("{0},{1}", expressions, Range);
        }

        public bool Equals(GameSumExpression other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return other.BodyExpressions.SequenceEqual(this.BodyExpressions) && Equals(other.Range, Range);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (GameSumExpression)) return false;
            return Equals((GameSumExpression) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (BodyExpressions.GetHashCode()*397) ^ Range.GetHashCode();
            }
        }

        #endregion

    }
}
