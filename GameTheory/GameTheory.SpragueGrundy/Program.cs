using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //var dawson2 = new DawsonsChessGame();
            //var dawson = new DawsonsChessSlimGame();
            //for (uint i = 0; i < 1000; i++)
            //{
            //    dawson.ResetCounters();


            //    Console.WriteLine("{0}-{1}; rec - {2}, cached rec - {3}, cache count - {4}", i, dawson.SGValue(i),
            //                      dawson.RecursionCount, dawson.CachedRecCount, dawson.CachedObjects);
            //}

            var queen = new QueenGame();
            var dawson = new DawsonsChessGame();
            var dawson2 = new DawsonsChessSlimGame();
            var stopWatch = new Stopwatch();
            for (int i = 1; i < 100; i++)
            {
                stopWatch.Reset();
                stopWatch.Start();
                var value = dawson.SGValue(new PileList() { i });
                var time = stopWatch.ElapsedMilliseconds;
                stopWatch.Stop();
                Console.WriteLine("{0}.\tSG={1},\trecursion={2},\tcached={3},\ttime={4}ms", 
                    i, value, dawson.RecursionCount, dawson.CachedRecCount,time);
            }


        }



    }
}
