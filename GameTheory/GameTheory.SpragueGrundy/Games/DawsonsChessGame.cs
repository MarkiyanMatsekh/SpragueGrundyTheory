using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameTheory.SpragueGrundy.Helpers;

namespace GameTheory.SpragueGrundy.Games
{
    public class PileList : List<int>, IEquatable<PileList>
    {
        public PileList(IEnumerable<int> collection)
            : base(collection)
        {
        }

        public PileList()
        {
        }

        public bool Equals(PileList other)
        {
            if (this.Count != other.Count)
                return false;

            var thisCopy = new PileList(this);
            var otherCopy = new PileList(other);

            thisCopy.Sort(); // very rude, redo this
            otherCopy.Sort();

            for (int i = 0; i < Count; i++)
                if (thisCopy[i] != otherCopy[i])
                    return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(PileList)) return false;
            return Equals((PileList)obj);
        }

        public override int GetHashCode()
        {
            var res = 0;
            foreach (int i in this)
                res += i * (int)Math.Pow(7, Math.Abs(this.Count - i) % 7);
            return res;
        }

        public static bool operator ==(PileList left, PileList right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PileList left, PileList right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Count = ").Append(Count).Append(";Piles sizes: ");
            foreach (var chip in this)
                sb.Append(chip).Append(";");
            return sb.ToString();
        }
    }

    // winning strategy is to always try to make nim-sum of the rest of piles == 0 (that is - to make them equal, in case of 2 piles);
    public class DawsonsChessGame : SpragueGrundyGameBase<PileList>
    {
        protected override bool TryStopRecursion(PileList key, out uint value)
        {
            if (key.IsEmpty() || key.All(chip => chip == 0))
            {
                value = 0;
                return true;
            }

            value = 0;
            return false;
        }

        public override HashSet<PileList> GetStateTransitions(PileList key)
        {
            var set = new HashSet<PileList>();

            // remove 1 chip if it's a whole pile
            for (int i = 0; i < key.Count; i++)
            {
                if (key[i] == 1)
                {
                    var list = new PileList(key);
                    list.RemoveAt(i);
                    set.Add(list);
                }
            }

            // remove 2 chips from any pile
            for (int i = 0; i < key.Count; i++)
            {
                var list = new PileList(key);
                list[i] -= 2;
                if (list[i] <= 0)
                    list.RemoveAt(i);
                set.Add(list);

            }

            // remove 3 chips and split this pile on 2, 1 or 0 (depending on situation)
            for (int i = 0; i < key.Count; i++)
            {
                var list = new PileList(key);
                list[i] -= 3;

                int leftChipsCount = list[i];
                int middleOfChips = leftChipsCount / 2 + 1;

                list.RemoveAt(i);

                if (leftChipsCount == 0)
                {
                    if (!list.IsEmpty())
                        set.Add(new PileList(list));
                    else
                        set.Add(new PileList(list) { leftChipsCount });
                }
                else if (leftChipsCount > 0)
                    set.Add(new PileList(list) { leftChipsCount });

                for (int j = 1; j < middleOfChips; j++)
                    set.Add(new PileList(list) { j, leftChipsCount - j });
            }

            return set;
        }

        protected override HashSet<uint> GetSGValuesForTransitions(PileList key)
        {
            var spSet = new HashSet<uint>();

            //Parallel.ForEach(GetStateTransitions(key), list => spSet.Add(SGValue(list)));

            foreach (var list in GetStateTransitions(key))
            {
                spSet.Add(SGValue(list));
            }
            return spSet;
        }
    }
}