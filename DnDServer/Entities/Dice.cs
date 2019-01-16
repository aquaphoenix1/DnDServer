using System;

namespace DnDServer.Controllers
{
    public class Dice
    {
        public enum AdvantageAndInterference
        {
            Normal = 0,
            Advantage = 1,
            Interference = -1
        }

        public class Result
        {
            public bool IsCritical { get; set; }
            public int Value { get; set; }
            public string Message { get; set; }

            public Result(bool isCritical, int value, string message)
            {
                IsCritical = isCritical;
                Value = value;
                Message = message;
            }
        }

        private static Random rand = new Random();

        public static int ThrowDice(int count, int edges, AdvantageAndInterference advantageAndInterference)
        {
            var result = 0;

            if (advantageAndInterference == AdvantageAndInterference.Advantage)
            {
                result = Math.Max(GetThrowValue(count, edges), GetThrowValue(count, edges));
            }
            else if (advantageAndInterference == AdvantageAndInterference.Interference)
            {
                result = Math.Min(GetThrowValue(count, edges), GetThrowValue(count, edges));
            }
            else
            {
                result = GetThrowValue(count, edges);
            }

            return result;
        }

        private static int GetThrowValue(int count, int edges)
        {
            var result = 0;

            for (int i = 0; i < count; i++)
            {
                result += rand.Next(1, edges + 1);
            }

            return result;
        }
    }
}