using CompetitiveProgramming.Metadata;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CompetitiveProgramming;

class Program
{
    private static Action[] algorithms = new[]
    {
            new Action(Solution.Run)
    };

    static int Main(string[] args)
    {
        var app = new CommandApp();
        app.SetDefaultCommand<RunCommand>();
        app.Configure(config =>
        {
            config.AddCommand<RunCommand>("run")
            .WithExample(new[] { "run", "-c", "10" });
            config.AddCommand<SearchCommand>("search")
            .WithExample(new[] { "search", "-s", "stack" });
            config.AddDelegate("gen", GenerateInput)
                .WithDescription("Generates input.");
            config.AddDelegate("play", RunPlayground)
                .WithDescription("Runs the playground. Used for showing data or solution patterns.");
            config.PropagateExceptions();
        });

        try
        {
            return app.Run(args);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
            return -1;
        }

    }

    private static Stopwatch RunSolution(Action algorithm)
    {
        var sw = new Stopwatch();
        sw.Start();

        algorithm();

        sw.Stop();
        return sw;
    }

    private static int GenerateInput(CommandContext context)
    {

        TextWriter defaultOut = Console.Out;
        using (var writer = new StreamWriter("input.txt"))
        {
            Console.SetOut(writer);
            Solution.GenerateData();
        }
        Console.Out.Close();
        Console.SetOut(defaultOut);
        return 0;
    }

    private static int RunPlayground(CommandContext context)
    {
        Playground.Run();
        return 0;
    }

    // Commands

    [Description("Runs registered solutions.")]
    public sealed class RunCommand : Command<RunCommand.Settings>
    {
        public sealed class Settings : CommandSettings
        {
            [CommandOption("-c|--count <ITERATIONS>")]
            [Description("The number of iterations to run. The default is '[grey]1[/]'.")]
            [DefaultValue("1")]
            public uint Count { get; set; }
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            if (settings.Count == 1 && algorithms.Length == 1)
            {
                TextReader defaultIn = Console.In;
                Console.SetIn(new StreamReader("input.txt"));

                Stopwatch stopwatch = RunSolution(algorithms[0]);

                AnsiConsole.WriteLine();
                AnsiConsole.Write(new Panel($"Elapsed Time: [aqua]{stopwatch.Elapsed}[/]")
                    .Header("Running Time Statistics:"));

                Console.SetIn(defaultIn);
                return 0;
            }

            var stopwatches = new Stopwatch[algorithms.Length][];
            for (int i = 0; i < stopwatches.Length; i++)
            {
                stopwatches[i] = new Stopwatch[settings.Count];
            }
            for (int i = 0; i < settings.Count; i++)
            {
                GenerateInput(context);
                AnsiConsole.Write(new Rule($"[green]Iteration: {i + 1}[/]").RuleStyle(Style.Parse("green")));
                for (int j = 0; j < algorithms.Length; j++)
                {
                    TextReader defaultInLoop = Console.In;
                    Console.SetIn(new StreamReader("input.txt"));

                    AnsiConsole.Write(new Rule($"[yellow]Algorithm: {j + 1}[/]").RuleStyle(Style.Parse("yellow")).LeftAligned());

                    stopwatches[j][i] = RunSolution(algorithms[j]);

                    AnsiConsole.WriteLine();
                    Console.In.Close();
                    Console.SetIn(defaultInLoop);
                }
            }

            var table = new Table()
                .Title("[aqua]Running Time Statistics[/]")
                .AddColumns(new TableColumn("[bold]Algorithm[/]"), new TableColumn("[bold]Best Time[/]"), new TableColumn("[bold]Worst Time[/]"), new TableColumn("[bold]Avg Time[/]"));
            for (int i = 0; i < stopwatches.Length; i++)
            {
                table.AddRow($"{i + 1}", $"{stopwatches[i].Min(x => x.Elapsed)}", $"{stopwatches[i].Max(x => x.Elapsed)}", $"{new TimeSpan((long)stopwatches[i].Average(x => x.ElapsedTicks))}");
            }

            AnsiConsole.Write(table);
            return 0;
        }
    }

    [Description("Search solution classes containing particular algorithm tags.")]
    public sealed class SearchCommand : Command<SearchCommand.Settings>
    {
        public sealed class Settings : CommandSettings
        {
            [CommandOption("-t|--tag <Tag>")]
            [Description("List solutions tagged with particular tag name.")]
            public string Tag { get; set; }
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            var solutionsInfo = new List<(string ClassName, AlgorithmInfoAttribute AlgorithmInfo)>();
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                var algorithmInfoAttribute = type.GetCustomAttribute<AlgorithmInfoAttribute>(false);
                if (algorithmInfoAttribute != null && algorithmInfoAttribute.Tags.Any(x => x.ToString().ToLower().Contains(settings.Tag.ToLower())))
                {
                    solutionsInfo.Add((type.Name, algorithmInfoAttribute));
                }
            }

            var table = new Table()
                .Title("[aqua]Search Results[/]")
                .AddColumns(new TableColumn("[bold]Class Name[/]"), new TableColumn("[bold]Tags[/]"), new TableColumn("[bold]Time Complexity[/]"));
            foreach (var solutionInfo in solutionsInfo)
            {
                table.AddRow($"[link={solutionInfo.AlgorithmInfo.ProblemUrl}]{solutionInfo.ClassName}[/]", $"{string.Join(" | ", solutionInfo.AlgorithmInfo.Tags)}", $"{solutionInfo.AlgorithmInfo.TimeComplexity}");
            }

            AnsiConsole.Write(table);
            return 0;
        }
    }
}
