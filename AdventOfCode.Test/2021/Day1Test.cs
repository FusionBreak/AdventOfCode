using AdventOfCode._2021;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Test._2021
{
    public class Day1Test
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
    }
}
