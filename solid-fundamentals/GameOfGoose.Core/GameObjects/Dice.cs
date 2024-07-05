using GameOfGoose.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfGoose.GameObjects
{
    public class Dice : IDice
    {
        private Random _random;
        private int Roll1 { get; set; }
        private int Roll2 { get; set; }
        public int SmallerRoll { get; set; }
        public int LargerRoll { get; set; }
        public Dice()
        {
            _random = new Random();
            Roll1 = Roll();
            Roll2 = Roll();
        }

        public int Roll()
        {
            return _random.Next(1, 7);
        }
        public int DiceRoll()
        {
            return Roll1 + Roll2;
        }

    }
}
