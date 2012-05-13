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
            if (key <= 0)
            {
                value = 0;
                return true;
            }

            return false;
        }

        public HashSet<List<int>> GetStateTransitionExtended(int key)
        {
            var set = new HashSet<List<int>>();

            foreach (var transition in _transitions)
            {
                var gamesSum = transition as GameSumExpression;
                if (gamesSum == null)
                {
                    var states = transition.Evaluate(key);
                    foreach (var state in states)
                        set.Add(new List<int> { state });
                }
                else
                {
                    var states = gamesSum.EvaluateWithoutMerging(key);
                    foreach (var state in states)
                        set.Add(state);
                }
            }

            return set;
        }

        private readonly HashSet<AntiRepeaterItem> _antiRepeaterForCalc = new HashSet<AntiRepeaterItem>();
        protected override HashSet<uint> GetSGValuesForTransitions(int key)
        {
            var set = new HashSet<uint>();

            var transitions = GetStateTransitionExtended(key);
            foreach (var transition in transitions)
            {
               // if (_antiRepeaterForCalc.Contains(new AntiRepeaterItem(key, transition)))
               //     continue;

                uint nimsum = 0;
                foreach (var game in transition)
                {
                    uint value;
                    if (TryStopRecursion(game, out value))
                        nimsum ^= value;
                    else
                        nimsum ^= SGValue(game);
                }
                set.Add(nimsum);

             //   _antiRepeaterForCalc.Add(new AntiRepeaterItem(key, transition));
            }

            return set;
        }

        #region Graph

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

                            if (TryStopRecursionForGraph(game))
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
                        if (TryStopRecursionForGraph(state))
                            continue;
                        GetTransitionsForKey(state, ref g);
                        AddEdge(key, state, g);
                    }
                }

            }
        }

        private static bool TryStopRecursionForGraph(int key)
        {
            return key < 0;
        }

        private static void AddNode(int key, Graph g)
        {
            var n = g.AddNode(key.Str());
            n.Attr.LineWidth = 2;
            n.Attr.Fontsize = 15;
            n.Attr.Fillcolor = new Color(230, 230, 250);
            n.Attr.Color = new Color(150,150,250);
        }

        private static Edge AddEdge(int from, int to, Graph g)
        {
            var edge = g.AddEdge(from.Str(), to.Str());
            edge.Attr.LineWidth = 1;
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

        #endregion
    }
}
