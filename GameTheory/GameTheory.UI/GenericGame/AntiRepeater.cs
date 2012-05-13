using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory.UI.GenericGame
{
    class AntiRepeaterItem: IEquatable<AntiRepeaterItem>
    {
        public int FromState { get; private set; }
        public HashSet<int> GamesSum { get; private set; }

        public AntiRepeaterItem(int fromState, HashSet<int> gamesSum)
        {
            FromState = fromState;
            GamesSum = gamesSum;
        }

        public bool Equals(AntiRepeaterItem other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.FromState == FromState && other.GamesSum.IsSubsetOf(GamesSum) && this.GamesSum.IsSubsetOf(other.GamesSum);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (AntiRepeaterItem)) return false;
            return Equals((AntiRepeaterItem) obj);
        }

        public override int GetHashCode()
        {
            int gameSumHash = GamesSum.Aggregate(0, (current, i) => current ^ i);
            unchecked
            {
                return (FromState * 397) ^ gameSumHash;
            }
        }
    }
}
