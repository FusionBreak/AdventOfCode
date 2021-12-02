using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021
{
    public class Day2
    {
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