using System;
using System.Collections.Generic;

namespace UltimateBaseball
{
    public class History
    {
        private List<Result> _results = new List<Result>();

        public void AddResult(Result result)
        {
            _results.Add(result);
        }

        public void Print()
        {
            Console.WriteLine("*************************");
            for (int i = 0; i < _results.Count; i++)
                Console.WriteLine($"{i + 1} : {_results[i].Format()}");
            Console.WriteLine("*************************");
        }
    }
}