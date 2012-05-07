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
        private static void ShowUsage()
        {
            string separator = Environment.NewLine;
            Console.WriteLine("Please choose the game to play(or type 'exit' ot quit:");
            Console.WriteLine("chomp{0}dawson-chess{0}dawson-chess-slim{0}" +
                "kayles{0}laskers-nim{0}corner-the-queen{0}substraction-game", separator);
        }

        private static void ReadSingleParam(out int n)
        {
            Console.WriteLine("Please input parameter for game");
            n = int.Parse(Console.ReadLine());
        }

        private static void ReadTwoParams(out int n, out int m)
        {
            Console.WriteLine("Please input 2 parameters for game (separated by comma)");
            var _params = Console.ReadLine().Split(',').Select(p => p.Trim()).ToArray();

            n = int.Parse(_params[0]);
            m = int.Parse(_params[1]);
        }

        private static void ShowAnswer(uint sgValue)
        {
            Console.WriteLine("Sprague-Grundy value of this position is {0}, so this is {1}-position", 
                sgValue,
                sgValue > 0 ? "N" : "P");
        }

        public static void Main()
        {
            ShowUsage();

            int p1, p2;
            bool repeat = true;

            while (repeat)
            {
                string gameStr = Console.ReadLine();
                if (string.IsNullOrEmpty(gameStr))
                    continue;
                switch (gameStr)
                {
                    case "chomp":
                        Console.WriteLine("This game cannot be solved with Sprague-Grundy Theory due to cycles in graph");
                        break;
                    case "dawson-chess":
                        var dawson = new DawsonsChessGame();
                        ReadSingleParam(out p1);
                        ShowAnswer(dawson.SGValue(new PileList() { p1 }));
                        break;
                    case "dawson-chess-slim":
                        var dawsonSlim = new DawsonsChessSlimGame();
                        ReadSingleParam(out p1);
                        ShowAnswer(dawsonSlim.SGValue((uint)p1));
                        break;
                    case "kayles":
                        var kayles = new KaylesGame();
                        ReadSingleParam(out p1);
                        ShowAnswer(kayles.SGValue((uint)p1));
                        break;
                    case "laskers-nim":
                        var lasker = new LaskersNimGame();
                        ReadSingleParam(out p1);
                        ShowAnswer(lasker.SGValue((uint)p1));
                        break;
                    case "corner-the-queen":
                        var queen = new QueenGame();
                        ReadTwoParams(out p1, out p2);
                        ShowAnswer(queen.SGValue(new Coordinate(p1, p2)));
                        break;
                    case "whight-knight":
                        var knight = new QueenGame();
                        ReadTwoParams(out p1, out p2);
                        ShowAnswer(knight.SGValue(new Coordinate(p1, p2)));
                        break;
                    case "exit":
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("invalid game...");
                        ShowUsage();
                        break;
                }
            }
        }
    }
}
