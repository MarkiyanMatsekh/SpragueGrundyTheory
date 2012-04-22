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
            for (uint i = 0; i < 20; i++)
            {
                var a = lasker.Grundy(i);
                Console.WriteLine("{0} - {1}",i, a);
            }

        }
    }
}
