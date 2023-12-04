using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Year2021
{
    public class Day1
    {
        [Fact]
        public void Part1Test()
        {
            var report = new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            Assert.Equal(7, Day1.SolvePart1(report));
        }

        [Fact]
        public void Part2Test()
        {
            var report = new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            Assert.Equal(5, Day1.SolvePart2(report));
        }

        public static int SolvePart1(IEnumerable<int> report)
        {
            var increases = 0;
            var pre = 0;

            foreach (var value in report)
            {
                if (value > pre && pre > 0)
                    increases++;

                pre = value;
            }

            return increases;
        }

        public static int SolvePart2(IEnumerable<int> report)
        {
            var sums = new List<int>();

            for (var i = 0; i < report.Count(); i++)
            {
                var sum =
                    report.Skip(i).FirstOrDefault()
                    + report.Skip(i + 1).FirstOrDefault()
                    + report.Skip(i + 2).FirstOrDefault();
                sums.Add(sum);
            }

            return SolvePart1(sums);
        }
    }
}
