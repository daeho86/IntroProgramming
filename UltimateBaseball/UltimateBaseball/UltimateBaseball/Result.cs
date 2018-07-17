namespace UltimateBaseball
{
    public class Result
    {
        public int Strike;
        public int Ball;
        public int Out;

        public void CalculateResult(Answer answer, Guess guess)
        {
            for (var i = 0; i < Program.MaxDigit; i++)
            for (var j = 0; j < Program.MaxDigit; j++)
                if (answer.Get(i) == guess.Get(j))
                {
                    if (i == j)
                        Strike++;
                    else
                        Ball++;
                }

            Out = Program.MaxDigit - Strike - Ball;
        }

        public string Format()
        {
            return $"S{Strike} B{Ball} O{Out}";
        }

        public bool IsAnswer()
        {
            return Strike == Program.MaxDigit;
        }
    }
}