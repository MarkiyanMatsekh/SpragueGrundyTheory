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
        struct S
        {
            private object o;
            private List<int> list;
            private int i;

            unsafe public void B()
            {
                
            }
        }

        static void Main(string[] args)
        {
            var a = new S();
            var c = sizeof (System.Int32)
            ;
            var contents = new List<Func<int>>();
            var s = new StringBuilder();
            for (var i = 0; i < 5; i++)
                contents.Add(() => i);
            foreach (var t in contents)
                s.Append(t());
            Console.WriteLine(s);


            var dawson2 = new DawsonsChessGame();
            var dawson = new DawsonsChessSlimGame();
            for (uint i = 0; i < 1000; i++)
            {
                dawson.RecursionCount = 0;
                dawson.CachedRecCount = 0;
                
                Console.WriteLine("{0}-{1}; rec - {2}, cached rec - {3}, cache count - {4}", i, dawson.SGValue(i),
                                  dawson.RecursionCount, dawson.CachedRecCount, dawson.CachedObjects);
            }

        }
    }
}
