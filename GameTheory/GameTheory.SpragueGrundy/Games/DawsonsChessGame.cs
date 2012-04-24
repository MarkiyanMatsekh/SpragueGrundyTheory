using System.Collections.Generic;
using GameTheory.SpragueGrundy.Helpers;

namespace GameTheory.SpragueGrundy.Games
{
    // winning strategy is to always try to make nim-sum of the rest of piles == 0 (that is - to make them equal, in case of 2 piles);
    public class DawsonsChessGame : GrundyGameBase<List<int>>
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