using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return key <= 0;
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
        private void GetTransitionsForKey(int key, ref Graph g)
        {
            if (_cache.Contains(key))
                return;

            g.AddNode(key.Str());
            _cache.Add(key);

            foreach (var transition in _transitions)
            {
                var states = transition.Evaluate(key);
                foreach (var state in states)
                {
                    if (TryStopRecursion(state))
                        continue;
                    GetTransitionsForKey(state, ref g);
                    g.AddEdge(key.Str(), state.Str());
                }

            }
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
