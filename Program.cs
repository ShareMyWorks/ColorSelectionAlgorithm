using System;
using System.Collections.Generic;

namespace ColorSelectionAlgorithm
{
    internal class Program
    {
        public static List<int[]> result;

        static void Main(string[] args)
        {
            Console.WriteLine("How many kinds of colors ?");
            int colorCount=int.Parse(Console.ReadLine());

            Console.WriteLine("How many balls do you want to take ?");
            int ballCount=int.Parse(Console.ReadLine());

            ListAllCombination(ballCount, colorCount);

            Console.ReadLine();
        }

        private static void ListAllCombination(int ballCount, int colorCount)
        {
            Console.WriteLine("Combination details :");
            result = new List<int[]>();
            int[] separatorPositions = new int[colorCount - 1];
            for (int i = 0; i < colorCount - 1; i++)
            {
                separatorPositions[i] = i;
            }
            int[] colors = new int[colorCount];
            int count = 0;
            do
            {
                int start = -1;
                for (int i = 0; i < colorCount - 1; i++)
                {
                    int end = separatorPositions[i];
                    colors[i] = end - start - 1;
                    start = end;
                }
                colors[colorCount - 1] = ballCount + colorCount - 2 - start;

                result.Add(colors);

                foreach(int i in colors)
                {
                    Console.Write(i.ToString() + " | ");
                }
                Console.WriteLine();

                count++;
            } while (NextCombination(separatorPositions, ballCount + colorCount - 2));

            Console.WriteLine("Find " + count.ToString() + " combination(s) .");
        }
        private static bool NextCombination(int[] separatorPositions, int count)
        {
            int separatorCount = separatorPositions.Length;
            for (int i = separatorCount - 1; i >= 0; i--)
            {
                if (separatorPositions[i] < count - separatorCount + i + 1)
                {
                    separatorPositions[i]++;
                    for (int j = i + 1; j < separatorCount; j++)
                    {
                        separatorPositions[j] = separatorPositions[j - 1] + 1;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
