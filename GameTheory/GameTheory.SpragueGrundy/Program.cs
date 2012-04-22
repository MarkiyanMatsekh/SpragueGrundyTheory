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

            var sub2 = new SubstractionGame(new HashSet<uint> { 1, 2 });
            var sub3 = new SubstractionGame(new HashSet<uint> { 1, 2, 3 });
            var sub2N = new SubstractionGame(new HashSet<uint> { 1, 2, 4, 8, 16 });

            
            Console.WriteLine(ResultPredictor.FindPNPositions(sub2, 40).BinaryView);
            Console.WriteLine(ResultPredictor.FindPNPositions(sub3, 40).BinaryView);
            Console.WriteLine(ResultPredictor.FindPNPositions(sub2N, 40).BinaryView);
            Console.WriteLine(ResultPredictor.FindPNPositions(lasker, 40).BinaryView);

            Console.WriteLine(ResultPredictor.PredictWinner(sub2N,100));

        }
    }
}
