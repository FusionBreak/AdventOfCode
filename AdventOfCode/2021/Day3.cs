using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Year2021
{
    public class Day3
    {
        [Fact]
        public void Part1Test()
        {
            var reports = new string[]
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };

            Assert.Equal(198, Day3.SolvePart1(reports));
        }

        [Fact]
        public void Part2Test()
        {
            var reports = new string[] { };

            Assert.Equal(230, Day3.SolvePart2(reports));
        }

        public static int SolvePart1(IEnumerable<string> inputs)
        {
            var gammaBits = string.Empty;
            var epsilonBits = string.Empty;
            var inputLenght = inputs.First().Length;

            var bits = Enumerable
                .Range(0, inputLenght)
                .Select(
                    index =>
                        inputs
                            .Select(report => report[index])
                            .GroupBy(bit => bit)
                            .Select(group => (group.Key, group.Count()))
                            .OrderByDescending(group => group.Item2)
                )
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
