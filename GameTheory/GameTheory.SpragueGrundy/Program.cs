using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTheory.SpragueGrundy.Games;
using GameTheory.SpragueGrundy.Maths;
using GameTheory.SpragueGrundy.Results;

namespace GameTheory.SpragueGrundy
{
    class Program
    {
        public static void Main()
        {
            var dawson2 = new DawsonsChessGame();
            var dawson = new DawsonsChessSlimGame();
            for (uint i = 0; i < 1000; i++)
            {
                dawson.ResetCounters();
                

                Console.WriteLine("{0}-{1}; rec - {2}, cached rec - {3}, cache count - {4}", i, dawson.SGValue(i),
                                  dawson.RecursionCount, dawson.CachedRecCount, dawson.CachedObjects);
            }

        }
    }
}
