using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTheory.SpragueGrundy.Games;
using GameTheory.SpragueGrundy.Results;

namespace GameTheory.SpragueGrundy
{
    class Program
    {
        static void Main(string[] args)
        {
            var lasker = new LaskersNimGame();
            var kayles = new KaylesGame();

            var sticks2 = new SticksGame(2);
            var sticks3 = new SticksGame(3);
            var sticks4 = new SticksGame(4);

            //for (uint i = 0; i < 20; i++)
            //{
            //    var l = lasker.Grundy(i);
            //    var k = kayles.Grundy(i);

            //    var s2 = sticks2.Grundy(i);
            //    var s3 = sticks3.Grundy(i);
            //    var s4 = sticks4.Grundy(i);

            //    Console.WriteLine("n: {0}; \tlasker: {1}; \tkayles: {2}; \tsticks(2,3,4): {3},{4},{5}", i, l, k, s2, s3, s4);
            //}

            for (uint i = 0; i < 100; i++)
            {
                Console.WriteLine(ResultPredictor.GetShortPredictionResult(kayles,i,Player.First));
            }


        }
    }
}
