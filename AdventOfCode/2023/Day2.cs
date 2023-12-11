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
            => Assert.Equal(-1, SolvePart2(File.ReadLines("Inputs/2023/Day2.txt").ToArray()));


        public static int SolvePart1(string[] reports) 
            => reports
                .Select(Game.Parse)
                .Where(IsValidGame)
                .Sum(g => g.Id);

        public int SolvePart2(string[] reports) => throw new NotImplementedException();

        private static bool IsValidGame(Game game)
            => game.Hands.All(IsValidHand);

        private static bool IsValidHand(Hand hand)
        {
            var redCubes = hand.Sets.Where(s => s.Color == Color.Red).Sum(s => s.Count);
            var greenCubes = hand.Sets.Where(s => s.Color == Color.Green).Sum(s => s.Count);
            var blueCubes = hand.Sets.Where(s => s.Color == Color.Blue).Sum(s => s.Count);

            return redCubes <= MaxNumberOfRedCubes
                && greenCubes <= MaxNumberOfGreenCubes
                && blueCubes <= MaxNumberOfBlueCubes;
        }   

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
