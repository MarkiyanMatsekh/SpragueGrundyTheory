using System;

namespace GameTheory.SpragueGrundy.Results
{
    public class Player
    {
        private readonly uint _playerNo;

        private Player(uint playerNo)
        {
            if (playerNo < 1 || playerNo > 2)
                throw new ArgumentException("Only 2 players are currently supported");
            _playerNo = playerNo;
        }

        private static readonly Player _first = new Player(1);
        private static readonly Player _second = new Player(2);

        public static Player First { get { return _first; } }
        public static Player Second { get { return _second; } }

        public Player Other
        {
            get { return GetPlayer((uint) (3 - _playerNo)); }
        }
        private static Player GetPlayer(uint no)
        {
            switch (no)
            {
                case 1:
                    return _first;
                    break;
                case 2:
                    return _second;
                    break;
                default:
                    throw new InvalidOperationException("Only 2 players are currently supported");
            }
        }

        public uint Number { get { return _playerNo; } }
        public override string ToString()
        {
            switch (_playerNo)
            {
                case 1:
                    return "First Player";
                    break;
                case 2:
                    return "Second Player";
                    break;
                default:
                    throw new InvalidOperationException("Only 2 players are currently supported");
            }
        }
    };
}