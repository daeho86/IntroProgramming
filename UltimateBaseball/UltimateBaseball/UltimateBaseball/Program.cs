using System;
using System.Linq;

namespace UltimateBaseball
{
    class Program
    {
        private static string GetInputMessage(int index)
        {
            string text;
            switch (index)
            {
                case 0:
                    text = "첫";
                    break;
                case 1:
                    text = "두";
                    break;
                case 2:
                    text = "세";
                    break;
                default:
                    throw new NotImplementedException("Program.GetInputMessage");
            }

            return $"> {text} 번째 숫자를 입력하세요.";
        }

        static void Main(string[] args)
        {
            PrintWelcomeMessage();

            var numbers = GenerateNumbers();

            while (true)
            {
                int[] guesses = InputGuesses();

                PrintGuesses(guesses);

                if (IsInValidGuesses(guesses))
                {
                    Console.WriteLine("같은 숫자를 입력하면 안 됩니다.");
                    continue;
                }

                Result result = CalculateResult(numbers, guesses);

                string resultText = FormatResult(result);
                Console.WriteLine(resultText);

                if (result.Strike == 3)
                {
                    Console.WriteLine("정답입니다!");
                    break;
                }
            }
        }

        private static string FormatResult(Result result)
        {
            return $"스트라이크 {result.Strike}\n볼 {result.Ball}\n아웃 {result.Out}";
        }

        private static Result CalculateResult(int[] numbers, int[] guesses)
        {
            Result result = new Result();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (guesses[i] == numbers[j])
                    {
                        if (i == j)
                        {
                            result.Strike++;
                        }
                        else
                        {
                            result.Ball++;
                        }
                    }
                }
            }

            result.Out = numbers.Length - result.Strike - result.Ball;

            return result;
        }

        private static bool IsInValidGuesses(int[] guesses)
        {
            //            int count = guesses.Length;
            //            return count != guesses.Distinct().Count();

            return guesses[0] == guesses[1] || guesses[0] == guesses[2] || guesses[1] == guesses[2];
        }

        private static void PrintGuesses(int[] guesses)
        {
            Console.WriteLine("> 공격수가 고른 숫자");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(guesses[i]);
            }
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

        private static int[] InputGuesses()
        {
            int[] guesses = new int[3];

            for (int i = 0; i < guesses.Length; i++)
            {
                Console.WriteLine(GetInputMessage(i));
                guesses[i] = int.Parse(Console.ReadLine());
            }

            return guesses;
        }

        private static int[] GenerateNumbers()
        {
            Random random = new Random();

            int[] numbers = new int[3];

            int index = 0;
            while (index < 3)
            {
                numbers[index] = random.Next(0, 10);

                if (IsInArray(numbers[index], numbers))
                    continue;

                index++;
            }

            return numbers;
        }

        private static bool IsInArray(int number, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == number)
                    return true;

            return false;
        }
    }
}