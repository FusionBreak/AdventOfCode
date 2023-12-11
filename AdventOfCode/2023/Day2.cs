using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Year2023
{
    public class Day2
    {
        private const int MaxNumberOfRedCubes = 12;
        private const int MaxNumberOfGreenCubes = 13;
        private const int MaxNumberOfBlueCubes = 14;

        [Fact]
        public void TestSolvePart1()
            => Assert.Equal(2727, SolvePart1(File.ReadLines("Inputs/2023/Day2.txt").ToArray()));

        [Fact]
        public void TestSolvePart2()
            => Assert.Equal(56580, SolvePart2(File.ReadLines("Inputs/2023/Day2.txt").ToArray()));

        public static int SolvePart1(string[] reports) 
            => reports
                .Select(Game.Parse)
                .Where(IsValidGame)
                .Sum(g => g.Id);

        public int SolvePart2(string[] reports) 
            => reports
                .Select(Game.Parse)
                .Select(GetFewestNumberOfCubes)
                .Select(fewest => fewest.Red * fewest.Green * fewest.Blue)
                .Aggregate((a, b) => a + b);

        private static (int Red, int Green, int Blue) GetFewestNumberOfCubes(Game game)
        {
            var redCubes = GetFewestNumberOfCubesOfColor(game, Color.Red);
            var greenCubes = GetFewestNumberOfCubesOfColor(game, Color.Green);
            var blueCubes = GetFewestNumberOfCubesOfColor(game, Color.Blue);
            return (redCubes, greenCubes, blueCubes);
        }

        private static int GetFewestNumberOfCubesOfColor(Game game, Color color)
            => game.Hands
                .SelectMany(h => h.Sets.Where(s => s.Color == color))
                .OrderBy(s => s.Count)
                .Last()
                .Count;

        private static bool IsValidGame(Game game)
            => game.Hands.All(IsValidHand);

        private static bool IsValidHand(Hand hand)
        {
            var redCubes = GetCountOfColor(hand.Sets, Color.Red);
            var greenCubes = GetCountOfColor(hand.Sets, Color.Green);
            var blueCubes = GetCountOfColor(hand.Sets, Color.Blue);

            return redCubes <= MaxNumberOfRedCubes
                && greenCubes <= MaxNumberOfGreenCubes
                && blueCubes <= MaxNumberOfBlueCubes;
        }

        private static int GetCountOfColor(IEnumerable<Set> sets, Color color)
            => sets.Where(s => s.Color == color).Sum(s => s.Count);

        private record Game(int Id, IEnumerable<Hand> Hands)
        {
            public static Game Parse(string input)
            {
                var id = int.Parse(input.Split(':')[0].Split(' ')[1]);
                var hands = input.Split(':')[1].Split(';').Select(Hand.Parse);

                return new Game(id, hands);
            }
        };

        private record Hand(IEnumerable<Set> Sets)
        {
            public static Hand Parse(string input)
            {
                var sets = input.Split(',').Select(Set.Parse);

                return new Hand(sets);
            }
        }

        private record Set(Color Color, int Count)
        {
            public static Set Parse(string input)
            {
                var color = input.Split(' ')[2];
                var count = int.Parse(input.Split(' ')[1]);

                return new Set(ParseColor(color), count);
            }
        }

        private enum Color
        {
            Red,
            Green,
            Blue
        }

        private static Color ParseColor(string color) => color switch
        {
            "red" => Color.Red,
            "green" => Color.Green,
            "blue" => Color.Blue,
            _ => throw new ArgumentException($"Invalid color: {color}")
        };
    }
}
