using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory.SpragueGrundy.Games
{
    public class LaskersNim : GrundyGameBase
    {
        protected override bool StopCriteria(uint n, out uint stop)
        {
            stop = 0;
            if (n ==0)
            {
                stop = 0;
                return true;
            }
            if (n == 1)
            {
                stop = 1;
                return true;
            }
            return false;
        }

        protected override HashSet<uint> GetGameTransitions(uint n)
        {
            var set = new HashSet<uint>();

            for (uint i = 0; i <= n - 1; i++)
                set.Add(Grundy(i));

            for (uint i = 1; i <= n - 1; i++)
                set.Add(Grundy(i) ^ Grundy(n - i));

            return set;
        }
    }

    public abstract class GrundyGameBase
    {
        protected uint Mex(HashSet<uint> set  )
        {
            //creepy implementation
            uint max = set.Max(), i = 0;
            for (; i <= max; i++)
            {
                if (!set.Contains(i))
                    break;
            }
            return i;
        }

        public uint Grundy(uint n)
        {
            uint stop;
            if (StopCriteria(n, out stop))
                return stop;

            return Mex(GetGameTransitions(n));
        }

        protected abstract bool StopCriteria(uint n,out uint stop);

        protected abstract HashSet<uint> GetGameTransitions(uint n);

    }
}
