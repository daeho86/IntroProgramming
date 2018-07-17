using System;

namespace UltimateBaseball
{
    public class Answer : IntContainer
    {
        public void Generate()
        {
            Random random = new Random();

            for (int i = 0; i < _numbers.Length; i++)
                _numbers[i] = -1;

            int index = 0;
            while (index < Program.MaxDigit)
            {
                int number = random.Next(0, 10);

                if (IsInArray(number))
                    continue;

                _numbers[index++] = number;
            }
        }

        private bool IsInArray(int number)
        {
            for (int i = 0; i < _numbers.Length; i++)
                if (_numbers[i] == number)
                    return true;

            return false;
        }

        protected override string PrintCore()
        {
            return "> 정답";
        }
    }
}