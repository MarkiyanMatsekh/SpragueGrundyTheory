using System;
using System.Collections.Generic;
using System.Linq;

namespace GameTheory.SpragueGrundy.Games
{
    public class WhiteKnightGame : GrundyGameBase<Coordinate>
    {
        protected override bool TryStopRecursion(Coordinate key, out uint value)
        {
            if (key.X >= 0 && key.X <= 2 && key.Y >= 0 && key.Y <= 2)
            {
                value = 0;
                return true;
            }

            value = 0;
            return false;
        }

        protected override HashSet<uint> GetStateTransitions(Coordinate key)
        {
            var set = new HashSet<uint>();
            var possibleMoves = new[]
                                    {
                                        new Coordinate(key.X - 1, key.Y - 2),
                                        new Coordinate(key.X - 2, key.Y - 1),
                                        new Coordinate(key.X - 2, key.Y + 1),
                                        new Coordinate(key.X + 1, key.Y - 2)
                                    };

            foreach (var move in possibleMoves.Where(move => move.X > 0 && move.Y > 0))
                set.Add(SGValue(move));

            return set;
        }
    }

    public class Coordinate : IEquatable<Coordinate>
    {
        public int X;
        public int Y;

        public bool Equals(Coordinate other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.X == X && other.Y == Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Coordinate)) return false;
            return Equals((Coordinate) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X*397) ^ Y;
            }
        }

        public static bool operator ==(Coordinate left, Coordinate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Coordinate left, Coordinate right)
        {
            return !Equals(left, right);
        }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("{0};{1}", X, Y);
        }
    }
}