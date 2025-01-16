namespace Hypha.Functions.Interfaces;

public interface IFunction { }

//todo: temp solution
public record FunctionParameters(double? SingleInput = null, double[] ArrayInput = null, double[] Input3 = null, double[] ArrayWeight = null, double[] ArrayTarget = null);

//todo: temp solution
public record FunctionResult(double? SingleOutput = null, double[] ArrayOutput = null, double[][] Result3 = null);
