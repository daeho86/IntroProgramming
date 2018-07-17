using System;
using System.Linq;

namespace UltimateBaseball
{
    class Program
    {
        public const int MaxDigit = 3;

        static void Main(string[] args)
        {
            PrintWelcomeMessage();

            Answer answer = new Answer();
            answer.Generate();
            answer.Print();

            Guess guess = new Guess();

            History history = new History();

            while (true)
            {
                guess.Generate();    
                guess.Print();

                if (guess.IsInvalid())
                {
                    Console.WriteLine("같은 숫자를 입력하면 안 됩니다.");
                    continue;
                }

                Result result = new Result();

                result.CalculateResult(answer, guess);

                string resultText = result.Format();
                Console.WriteLine(resultText);

                history.AddResult(result);

                if (result.IsAnswer())
                {
                    Console.WriteLine("정답입니다!");
                    break;
                }
            }

            history.Print();
        }

        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("+-----------------------------------------------------+");
            Console.WriteLine("|                궁극의 숫자 야구 게임                |");
            Console.WriteLine("+-----------------------------------------------------+");
            Console.WriteLine("| 컴퓨터가 수비수가 되어 세 자리 수를 하나 골랐습니다.|");
            Console.WriteLine("| 각 숫자는 0~9 중에 하나며 중복되는 숫자는 없습니다. |");
            Console.WriteLine("| 모든 숫자와 위치를 맞추면 승리합니다.               |");
            Console.WriteLine("| 숫자와 순서가 둘 다 맞으면 스트라이크입니다.        |");
            Console.WriteLine("| 숫자만 맞고 순서가 틀리면 볼입니다.                 |");
            Console.WriteLine("| 숫자가 틀리면 아웃입니다.                           |");
            Console.WriteLine("+-----------------------------------------------------+");
        }
    }
}