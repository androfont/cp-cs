using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CompetitiveProgramming
{
    /// <summary>
    /// https://app.codesignal.com/interview-practice/task/aRwxhGcmvhf6vKPCp/description
    /// Time Complexity: O(n)
    /// Memory Complexity: O(n)
    /// Tags: stack
    /// </summary>
    class SimplifyPath
    {
        static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

        internal static void Run()
        {
            int testCount = int.Parse(Console.ReadLine());
            for (int t = 0; t < testCount; t++)
            {
                output.WriteLine(Solve(Console.ReadLine()));
            }
            output.Flush();
        }

        public static string Solve(string path)
        {
            var tokens = path.Split('/');
            var pathStack = new Stack<string>();
            foreach (var token in tokens)
            {
                if (token == string.Empty || token == ".")
                {
                    continue;
                }
                if (token == "..")
                {
                    if (pathStack.Any())
                    {
                        pathStack.Pop();
                    }
                }
                else
                {
                    pathStack.Push(token);
                }
            }

            return "/" + string.Join('/', pathStack.Reverse());
        }

        internal static void GenerateData()
        {
            var rd = new Random();
            int testCount = 1;
            Console.WriteLine(testCount);

            var values = new[] { "/", ".", "..", "a", "b", "c", "d", "e", "f" };

            for (int t = 0; t < testCount; t++)
            {
                Console.WriteLine("/" + string.Join('/', (new int[32]).Select((_, _) => values[rd.Next(values.Length)])));
            }
        }
    }
}
