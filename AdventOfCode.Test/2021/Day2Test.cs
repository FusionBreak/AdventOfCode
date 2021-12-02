using AdventOfCode._2021;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Test._2021
{
    public class Day2Test
    {
        [Fact]
        public void Part1Test()
        {
            var commands = new string[] { "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2" };
            
            Assert.Equal(150, Day2.SolvePart1(commands));
        }
        
        [Fact]
        public void Part2Test()
        {
            var commands = new string[] { "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2" };
            
            Assert.Equal(900, Day2.SolvePart2(commands));
        }
    }
}