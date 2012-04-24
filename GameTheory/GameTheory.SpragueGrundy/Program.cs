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
            var lasker = new LaskersNimGame();
            var kayles = new KaylesGame();

            var sub2 = new SubstractionGame(new HashSet<uint> { 1, 2 });
            var sub3 = new SubstractionGame(new HashSet<uint> { 1, 2, 3 });
            var sub2N = new SubstractionGame(new HashSet<uint> { 1, 2, 4, 8, 16 });

            //Console.WriteLine(ResultPredictor.FindPNPositions(sub2, 40).BinaryView);
            //Console.WriteLine(ResultPredictor.FindPNPositions(sub3, 40).BinaryView);
            //Console.WriteLine(ResultPredictor.FindPNPositions(sub2N, 40).BinaryView);
            //Console.WriteLine(ResultPredictor.FindPNPositions(lasker, 40).BinaryView);

            //Console.WriteLine(ResultPredictor.PredictWinner<uint>(sub2N, 100, Player.First));


            var knight = new WhiteKnightGame();
            var queen = new QueenGame();
            var chomp = new ChompGame(10,10);

            //int n = 10;
            //for (int i = 1; i <= n; i++)
            //{
            //    for (int j = 1; j <= n; j++)
            //    {
            //        var sg = chomp.SGValue(new Coordinate(i, j));
            //        var binary = sg == 0 ? 0 : 1;
            //        Console.Write("{0}", sg);
            //    }
            //    Console.WriteLine();
            //}

            //var a = new XorEquation(4, 7, 9);
            //var b = a.Sum();
            //var zeros = a.FindZeroResults();
            //foreach (var zero in zeros)
            //{
            //    var d = a.DoReplacement(zero);
            //    var e = d.Sum();
            //}

            var dawson = new DawsonsChessGame();
            var a = dawson.GetStateTransitions2(new List<int>() {1});




        }
    }
}
