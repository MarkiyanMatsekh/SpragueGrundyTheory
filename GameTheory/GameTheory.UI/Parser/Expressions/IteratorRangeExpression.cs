using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory.UI.Parser.Expressions
{
    public class IteratorRangeExpression : ExpressionsBase, IEquatable<IteratorRangeExpression>
    {
        public SimpleExpression From { get; private set; }
        public SimpleExpression To { get; private set; }

        public IteratorRangeExpression(SimpleExpression iterateFrom, SimpleExpression iterateTo)
        {
            From = iterateFrom;
            To = iterateTo;
        }

        #region Overrides

        public override string ToString()
        {
            return string.Format("{0}..{1}", From, To);
        }

        public bool Equals(IteratorRangeExpression other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.From, From) && Equals(other.To, To);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (IteratorRangeExpression)) return false;
            return Equals((IteratorRangeExpression) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (From.GetHashCode()*397) ^ To.GetHashCode();
            }
        }

        #endregion
    }
}
