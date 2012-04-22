using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTheory.SpragueGrundy.Games;

namespace GameTheory.SpragueGrundy
{
    class Program
    {
        static void Main(string[] args)
        {
            var lasker = new LaskersNim();
            var kayles = new KaylesGame();
            for (uint i = 0; i < 100; i++)
            {
                var l = lasker.Grundy(i);
                var k = kayles.Grundy(i);

                Console.WriteLine("n: {0}; \tlasker: {1}; \tkayles: {2}", i, l, k);
            }

        }
    }
}
