using AdventOfCode._2021;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Test._2021
{
    public class Day3Test
    {
        [Fact]
        public void Part1Test()
        {
            var reports = new string[] {
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
                "01010" };
            
            Assert.Equal(198, Day3.SolvePart1(reports));
        }
        
        [Fact]
        public void Part2Test()
        {
            var reports = new string[] { };
            
            Assert.Equal(230, Day3.SolvePart2(reports));
        }
    }
}