using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CompetitiveProgramming
{
    class Program
    {
        private static Action[] algorithms = new[]
        {
            new Action(Solution.Run)
        };

        static void Main(string[] args)
        {
            var separator = new string('-', 64);
            if (args.Length >= 1)
            {
                switch (args[0])
                {
                    case "-g":
                        GenerateInput();
                        break;
                    case "-h":
                        ShowUsage();
                        break;
                    case "-s":
                        Console.SetIn(new StreamReader("input.txt"));
                        algorithms[0]();
                        break;
                    case "-p":
                        Playground.Run();
                        break;
                    default:
                        int iterations = int.Parse(args[0]);
                        var stopwatches = new Stopwatch[algorithms.Length][];
                        for (int i = 0; i < stopwatches.Length; i++)
                        {
                            stopwatches[i] = new Stopwatch[iterations];
                        }
                        for (int i = 0; i < iterations; i++)
                        {
                            GenerateInput();
                            for (int j = 0; j < algorithms.Length; j++)
                            {
                                TextReader defaultInLoop = Console.In;
                                Console.SetIn(new StreamReader("input.txt"));

                                Console.WriteLine($"Running Algorithm: {j + 1} Iteration: {i + 1}");

                                stopwatches[j][i] = RunSolution(algorithms[j]);

                                Console.WriteLine(separator);
                                Console.WriteLine();
                                Console.In.Close();
                                Console.SetIn(defaultInLoop);
                            }
                        }

                        Console.WriteLine("Running Time Statistics:");
                        for (int i = 0; i < stopwatches.Length; i++)
                        {
                            Console.WriteLine($"Algorithm {i + 1}");
                            Console.WriteLine($"Best Time:\t{stopwatches[i].Min(x => x.Elapsed)}");
                            Console.WriteLine($"Worst Time:\t{stopwatches[i].Max(x => x.Elapsed)}");
                            Console.WriteLine($"Avg Time:\t{new TimeSpan((long)stopwatches[i].Average(x => x.ElapsedTicks)) }");
                            Console.WriteLine();
                        }
                        break;
                }
                return;
            }


            TextReader defaultIn = Console.In;
            Console.SetIn(new StreamReader("input.txt"));

            Stopwatch stopwatch = RunSolution(algorithms[0]);

            Console.WriteLine(separator);
            Console.WriteLine();
            Console.WriteLine("Running Time Statistics:");
            Console.WriteLine($"Elapsed Time:\t{stopwatch.Elapsed}");

            Console.SetIn(defaultIn);
#if DEBUG
            Console.ReadKey();
#endif
        }

        private static Stopwatch RunSolution(Action algorithm)
        {
            var sw = new Stopwatch();
            sw.Start();

            algorithm();

            sw.Stop();
            return sw;
        }

        private static void GenerateInput()
        {
            TextWriter defaultOut = Console.Out;
            using (var writer = new StreamWriter("input.txt"))
            {
                Console.SetOut(writer);
                Solution.GenerateData();
            }
            Console.Out.Close();
            Console.SetOut(defaultOut);
        }

        private static void ShowUsage()
        {
            Console.WriteLine("Usage: cp [options]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("\t-h\tDisplay help.");
            Console.WriteLine("\t-g\tGenerate input.");
            Console.WriteLine("\t(n)\tRun registered solutions n times, each time it generates input.");
            Console.WriteLine("\t-s\tSilent mode. Runs default solution without time info. Used for comparing outputs automatically with other solutions.");
            Console.WriteLine("\t-p\tRuns the playground. Used for showing data or solution patterns.");
        }
    }
}
