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
            var lasker = new WhiteKnightGame();
            var stopWatch = new Stopwatch();

            int n = 19;
            for (int i = 1; i < n; i++)
            {
                stopWatch.Reset();
                stopWatch.Start();
                //var value = dawson.SGValue(new PileList() { i });
                for (int j = 1; j < n; j++)
                {


                    var value = lasker.SGValue(new Coordinate(i, j));
                    var time = stopWatch.ElapsedMilliseconds;
                    stopWatch.Stop();
                    Console.Write("{0}",value > 0 ? 1 : 0);
                }
                Console.WriteLine();
            }


        }



    }
}
