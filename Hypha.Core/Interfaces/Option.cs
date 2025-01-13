namespace Hypha.Interfaces;

public record Option(IFunction ErrorFunction, double LearningRate = 0.01);
