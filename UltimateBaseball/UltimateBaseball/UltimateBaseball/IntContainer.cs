using System;

namespace UltimateBaseball
{
    public abstract class IntContainer
    {
        protected int[] _numbers = new int[Program.MaxDigit];
        
        public int Get(int index)
        {
            return _numbers[index];
        }

        protected abstract string PrintCore();

        public void Print()
        {
            Console.WriteLine(PrintCore());

            for (int i = 0; i < _numbers.Length; i++)
                Console.Write(_numbers[i] + " ");

            Console.WriteLine();
        }
    }
}