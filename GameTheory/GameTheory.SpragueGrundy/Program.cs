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
        static void Main(string[] args)
        {

            var dawson = new DawsonsChessGame();
            for (int i = 0; i < 19; i++)
            {
                Console.WriteLine("{0}-{1}",i,dawson.SGValue(new PileList() {i}));
            }

        }
    }
}
