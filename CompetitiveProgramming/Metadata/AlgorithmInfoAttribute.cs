using System;

namespace CompetitiveProgramming.Metadata;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class AlgorithmInfoAttribute : Attribute
{
    public Uri ProblemUrl { get; private set; }

    public string TimeComplexity { get; private set; }

    public string MemoryComplexity { get; private set; }

    public AlgorithmTags[] Tags { get; private set; }

    public AlgorithmInfoAttribute(string url, string timeComplexity, string memoryComplexity, AlgorithmTags[] tags)
    {
        ProblemUrl = new Uri(url);
        TimeComplexity = timeComplexity;
        MemoryComplexity = memoryComplexity;
        Tags = tags;
    }
}
