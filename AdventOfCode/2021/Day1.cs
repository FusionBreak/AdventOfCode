using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2021
{
    public class Day1
    {
        public static int SolvePart1(IEnumerable<int> report)
        {
            var increases = 0;
            var pre = 0;

            foreach (var value in report)
            {
                if(value > pre && pre > 0)
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
                var sum = report.Skip(i).FirstOrDefault() + report.Skip(i + 1).FirstOrDefault() + report.Skip(i + 2).FirstOrDefault();
                sums.Add(sum);
            }
            
            return SolvePart1(sums);
        }
    }
}
