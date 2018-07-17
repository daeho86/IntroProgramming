using System;
using System.Linq;

namespace UltimateBaseball
{
    public class Guess : IntContainer
    {
        public void Generate()
        {
            for (int i = 0; i < _numbers.Length; i++)
            {
                Console.WriteLine($"> {i + 1} 번째 숫자를 입력하세요.");
                _numbers[i] = int.Parse(Console.ReadLine());
            }
        }

        public bool IsInvalid()
        {
            int count = _numbers.Length;
            return count != _numbers.Distinct().Count();
//            return _numbers[0] == _numbers[1] || _numbers[0] == _numbers[2] || _numbers[1] == _numbers[2];
        }

        protected override string PrintCore()
        {
            return "> 공격수가 고른 숫자";
        }
    }
}