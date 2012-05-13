using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTheory.UI.Parser.Expressions;

namespace GameTheory.SpragueGrundy.Games
{
    public class GenericGrundyGame:SpragueGrundyGameBase<int>
    {
        private readonly IEnumerable<EvaluatableExpression> _transitions;

        public GenericGrundyGame(IEnumerable<EvaluatableExpression> transitions )
        {
            _transitions = transitions;
        }

        protected override bool TryStopRecursion(int key, out uint value)
        {
            value = 0;
            if (key < 0)
            {
                return true;
            }
            if( key == 1)
            {
                value = 1;
                return true;
            }
            return false;
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
