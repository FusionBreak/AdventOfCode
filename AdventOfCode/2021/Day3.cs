using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021
{
    public class Day3
    {
        public static int SolvePart1(IEnumerable<string> inputs)
        {
            var gammaBits = string.Empty;
            var epsilonBits = string.Empty;
            var inputLenght = inputs.First().Length;

            var bits = Enumerable.Range(0, inputLenght)
                .Select(index => inputs.Select(report => report[index])
                    .GroupBy(bit => bit)
                    .Select(group => (group.Key, group.Count()))
                    .OrderByDescending(group => group.Item2))
                .ToList();

            foreach (var bit in bits)
            {
                gammaBits += bit.First().Key;
                epsilonBits += bit.Last().Key;
            }

            var gamma = Convert.ToInt32(gammaBits, 2);
            var epsilon = Convert.ToInt32(epsilonBits, 2);
            
            return gamma * epsilon;
        }

        public static int SolvePart2(IEnumerable<string> inputs)
        {
            return 0;
        }
    }
}