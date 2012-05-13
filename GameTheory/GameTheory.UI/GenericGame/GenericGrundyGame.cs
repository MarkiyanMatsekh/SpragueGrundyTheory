using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GameTheory.UI.GenericGame;
using GameTheory.UI.Parser;
using GameTheory.UI.Parser.Expressions;
using Microsoft.Glee.Drawing;

namespace GameTheory.SpragueGrundy.Games
{
    public class GenericGrundyGame : SpragueGrundyGameBase<int>
    {
        private readonly IEnumerable<EvaluatableExpression> _transitions;

        public GenericGrundyGame(IEnumerable<EvaluatableExpression> transitions)
        {
            _transitions = transitions;
        }

        protected override bool TryStopRecursion(int key, out uint value)
        {
            value = 0;
            return TryStopRecursion(key);
        }

        private static bool TryStopRecursion(int key)
        {
            return key < 0;
        }

        public override HashSet<int> GetStateTransitions(int key)
        {
            var res = new HashSet<int>();

            foreach (var transition in _transitions)
            {
                var states = transition.Evaluate(key);
                foreach (var state in states)
                    res.Add(state);
            }

            return res;
        }

        public Graph GetTransitionsGraph(int key)
        {
            var g = new Graph("g");
            GetTransitionsForKey(key, ref g);
            return g;
        }

        private readonly HashSet<int> _cache = new HashSet<int>();
        private readonly HashSet<AntiRepeaterItem> _antiRepeater = new HashSet<AntiRepeaterItem>();
        private void GetTransitionsForKey(int key, ref Graph g)
        {
            if (_cache.Contains(key))
                return;

            AddNode(key, g);
            _cache.Add(key);

            foreach (var transition in _transitions)
            {
                var gameSum = transition as GameSumExpression;
                if (gameSum != null)
                {
                    var gameSums = gameSum.EvaluateWithoutMerging(key);

                    foreach (var sum in gameSums)
                    {
                        var cache = new AntiRepeaterItem(key, new HashSet<int>(sum));
                        if (_antiRepeater.Contains(cache))
                            continue;

                        var sharedColor = GetRandomColor();
                        foreach (var game in sum)
                        {
                            
                            if (TryStopRecursion(game))
                                continue;
                            GetTransitionsForKey(game, ref g);
                            AddEdge(key, game, g, sharedColor);
                        }
                        _antiRepeater.Add(cache);
                    }
                }
                else
                {
                    var states = transition.Evaluate(key);
                    foreach (var state in states)
                    {
                        if (TryStopRecursion(state))
                            continue;
                        GetTransitionsForKey(state, ref g);
                        AddEdge(key, state, g);
                    }
                }

            }
        }

        private static void AddNode(int key, Graph g)
        {
            var n = g.AddNode(key.Str());
            n.Attr.LineWidth = 2;
            n.Attr.Fontsize = 15;
            n.Attr.Fillcolor = new Color(230, 230, 250);
        }

        private static Edge AddEdge(int from, int to, Graph g)
        {
            var edge = g.AddEdge(from.Str(), to.Str());
            return edge;
        }

        private static void AddEdge(int from, int to, Graph g, Color color)
        {
            var edge = AddEdge(from, to, g);
            edge.Attr.Color = color;
            edge.Attr.LineWidth = 2;
        }

        private static readonly Random rand = new Random();
        private Color GetRandomColor()
        {
            return new Color(RandomNumber(255), RandomNumber(255), RandomNumber(255));
        }

        private static byte RandomNumber(int upper)
        {
            return (byte)(rand.Next(upper));
        }

        protected override HashSet<uint> GetSGValuesForTransitions(int key)
        {
            var set = new HashSet<uint>();

            var transitions = GetStateTransitions(key);
            foreach (var transition in transitions)
            {
                set.Add(SGValue(transition));
            }

            return set;
        }
    }
}
