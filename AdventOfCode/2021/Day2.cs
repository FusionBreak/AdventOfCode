using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Year2021
{
    public class Day2
    {
        [Fact]
        public void Part1Test()
        {
            var commands = new string[]
            {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2"
            };

            Assert.Equal(150, Day2.SolvePart1(commands));
        }

        [Fact]
        public void Part2Test()
        {
            var commands = new string[]
            {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2"
            };

            Assert.Equal(900, Day2.SolvePart2(commands));
        }

        public static int SolvePart1(IEnumerable<string> commands)
        {
            var horizontal = 0;
            var depth = 0;

            foreach (var command in commands.Select(ParseCommand))
            {
                switch (command.command)
                {
                    case "forward":
                        horizontal += command.parameter;
                        break;
                    case "down":
                        depth += command.parameter;
                        break;
                    case "up":
                        depth -= command.parameter;
                        break;
                }
            }

            return horizontal * depth;
        }

        public static int SolvePart2(IEnumerable<string> commands)
        {
            var horizontal = 0;
            var depth = 0;
            var aim = 0;

            foreach (var command in commands.Select(ParseCommand))
            {
                switch (command.command)
                {
                    case "forward":
                        horizontal += command.parameter;
                        depth += aim * command.parameter;
                        break;
                    case "down":
                        aim += command.parameter;
                        break;
                    case "up":
                        aim -= command.parameter;
                        break;
                }
            }

            return horizontal * depth;
        }

        private static (string command, int parameter) ParseCommand(string command)
        {
            var commandParts = command.Split(" ");
            return (commandParts[0], int.Parse(commandParts[1]));
        }
    }
}
