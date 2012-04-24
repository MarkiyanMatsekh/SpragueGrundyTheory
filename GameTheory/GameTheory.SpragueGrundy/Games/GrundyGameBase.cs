using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTheory.SpragueGrundy.Helpers;
using GameTheory.SpragueGrundy.Maths;

namespace GameTheory.SpragueGrundy.Games
{
    public abstract class GrundyGameBase<TKey>
    {
        private readonly Dictionary<TKey, uint> _cache = new Dictionary<TKey, uint>();

        public uint SGValue(TKey key)
        {
            uint grundyValue;

            if (TryStopRecursion(key, out grundyValue))
                return grundyValue;

            if (TryGetCachedValue(key, out grundyValue))
                return grundyValue;

            grundyValue = Algorythm.Mex(GetStateTransitions(key));

            CacheValue(key, grundyValue);

            return grundyValue;
        }

        protected abstract bool TryStopRecursion(TKey key, out uint value);

        protected abstract HashSet<uint> GetStateTransitions(TKey key);

        public virtual HashSet<TKey> GetStateTransitions2(TKey key)
        {
            //todo cleanup;
            return null;
        }

        private void CacheValue(TKey key, uint grundyValue)
        {
            _cache[key] = grundyValue;
        }

        private bool TryGetCachedValue(TKey key, out uint value)
        {
            return _cache.TryGetValue(key, out value);
        }
    }

    class DawsonsChessGame : GrundyGameBase<List<int>>
    {
        protected override bool TryStopRecursion(List<int> key, out uint value)
        {
            if (key.IsEmpty())
            {
                value = 0;
                return true;
            }

            value = 0;
            return false;
        }

        public override HashSet<List<int>> GetStateTransitions2(List<int> key)
        {
            var set = new HashSet<List<int>>();

            // remove 1 chip if it's a whole pile
            for (int i = 0; i < key.Count; i++)
            {
                if (key[i] == 1)
                {
                    var list = new List<int>(key);
                    list.RemoveAt(i);
                    if (!list.IsEmpty())
                        set.Add(list);
                }
            }

            // remove 2 chips from any pile
            for (int i = 0; i < key.Count; i++)
            {
                var list = new List<int>(key);
                list[i] -= 2;
                if (list[i] <= 0)
                    list.RemoveAt(i);
                if (!list.IsEmpty())
                    set.Add(list);
            }

            // remove 3 chips and split this pile on 2, 1 or 0 (depending on situation)
            for (int i = 0; i < key.Count; i++)
            {
                var list = new List<int>(key);
                list[i] -= 3;

                int leftChipsCount = list[i];
                list.RemoveAt(i);

                int middleOfChips = leftChipsCount / 2 + 1;

                // handle corner case
                if (leftChipsCount > 0)
                    set.Add(new List<int>(list) {leftChipsCount});

                for (int j = 1; j < middleOfChips; j++)
                    set.Add(new List<int>(list) {j, leftChipsCount - j});
            }

            return set;
        }

        protected override HashSet<uint> GetStateTransitions(List<int> key)
        {
            var spSet = new HashSet<uint>();
            foreach (var list in GetStateTransitions2(key))
            {
                spSet.Add(SGValue(list));
            }

            return spSet;
        }
    }
}
