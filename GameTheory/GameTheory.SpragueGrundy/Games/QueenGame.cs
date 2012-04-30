using System;
using System.Collections.Generic;

namespace GameTheory.SpragueGrundy.Games
{
    public class QueenGame : SpragueGrundyGameBase<Coordinate>
    {
        protected override bool TryStopRecursion(Coordinate key, out uint value)
        {
            if (key.X <= 1 && key.Y <= 1)
            {
                value = 0;
                return true;
            }

            value = 0;
            return false;
        }

        protected override HashSet<uint> GetSGValuesForTransitions(Coordinate key)  
        {
            var set = new HashSet<uint>();

            int x = key.X, y = key.Y;

            for (int i = 1; i < x; i++)
                set.Add(SGValue(new Coordinate(x - i, y)));

            var northWestBound = Math.Min(x, y);
            for (int i = 1; i < northWestBound; i++)
                set.Add(SGValue(new Coordinate(x - i, y - i)));

            for (int i = 1; i < y; i++)
                set.Add(SGValue(new Coordinate(x, y - i)));

            return set;
        }
    }
}