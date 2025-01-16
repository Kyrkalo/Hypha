using Hypha.Functions.Interfaces;

namespace Hypha.Interfaces;

public record Option(ILossFunction ErrorFunction, double LearningRate = 0.01);
