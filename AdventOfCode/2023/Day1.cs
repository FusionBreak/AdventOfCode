﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode.Year2023
{
    public class Day1
    {
        [Fact]
        public void TestSolvePart1()
            => Assert.Equal(54304, SolvePart1(File.ReadLines("Inputs/2023/Day1.txt").ToArray()));

        [Fact]
        public void TestSolvePart2()
            => Assert.Equal(54418, SolvePart2(File.ReadLines("Inputs/2023/Day1.txt").ToArray()));

        [Fact]
        public void TestReplaceNumberNamesWithDigits()
        {
            var result = ReplaceNumberNamesWithDigits("oneighthree");

            Assert.Equal("o1e8t3e", result);
        }


        public static int SolvePart1(string[] reports) => reports.Select(GetCoordinateFromRow).Sum();

        public int SolvePart2(string[] reports)
            => reports
                .Select(ReplaceNumberNamesWithDigits)
                .Select(GetCoordinateFromRow)
                .Sum();

        private static readonly Dictionary<string, string> _numberNames = new()
        {
            {"one", "1"},
            {"two", "2"},
            {"three", "3"},
            {"four", "4"},
            {"five", "5"},
            {"six", "6"},
            {"seven", "7"},
            {"eight", "8"},
            {"nine", "9"},
        };

        private static string ReplaceNumberNamesWithDigits(string row)
            => _numberNames
                .Aggregate(
                    row, 
                    (current, pair) => current.Replace(pair.Key, $"{pair.Key[0]}{pair.Value}{pair.Key[^1]}")
                );

        private static int GetCoordinateFromRow(string row)
        {
            var digits = row.Where(char.IsDigit);
            return CombineFirstAndLastDigits(digits.First(), digits.Last());
        }

        private static int CombineFirstAndLastDigits(char first, char last) => (first - '0') * 10 + (last - '0');
    }
}
