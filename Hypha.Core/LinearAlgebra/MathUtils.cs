namespace Hypha.LinearAlgebra;

internal static class MathUtils
{
    public static double Dot(this double[] x, double[] y)
    {
        if (x.Length != y.Length)
            throw new ArgumentException("Vectors must have the same length.");

        double result = 0.0;

        for (int i = 0; i < x.Length; i++)
        {
            result += x[i] * y[i];
        }
        return result;
    }

    public static double[,] Dot(this double[,] x, double[,] y)
    {
        int rows_x = x.GetLength(0);
        int cols_x = x.GetLength(1);
        int cols_y = y.GetLength(1);

        if (cols_x != y.GetLength(0))
            throw new ArgumentException("Number of columns in x must equal number of rows in y.");

        double[,] result = new double[rows_x, cols_y];

        for (int i = 0; i < rows_x; i++)
            for (int j = 0; j < cols_y; j++)
                for (int k = 0; k < cols_x; k++)
                {
                    result[i, j] += x[i, k] * y[k, j];
                }
        return result;
    }

    public static double[][] Sum(double[][] inputs, byte axis = 0, bool keepdims = false)
    {
        int numRows = inputs.Length;
        int numCols = inputs[0].Length;
        double[][] result;

        if (axis == 0)
        {
            double[] sums = new double[numCols];
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    sums[col] += inputs[row][col];
                }
            }
            result = keepdims ? new[] { sums } : sums.Select(x => new[] { x }).ToArray();
        }
        else if (axis == 1)
        {
            double[] sums = new double[numRows];
            for (int row = 0; row < numRows; row++)
            {
                sums[row] = inputs[row].Sum();
            }
            result = keepdims ? sums.Select(x => new[] { x }).ToArray() : new[] { sums };
        }
        else if (axis == 2)
        {
            double totalSum = 0;
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    totalSum += inputs[row][col];
                }
            }
            result = keepdims ? new[] { new[] { totalSum } } : new[] { new[] { totalSum } };
        }
        else
        {
            throw new ArgumentException("Axis must be 0, 1, or 2.");
        }

        return result;
    }

    public static double CrossEntropy()
    {
        return 0.0;
    }

    public static double Loss(double[] output, double[] target)
    {
        return -(output.Zip(target, (o, t) => Math.Log(o) * t).Sum());
    }
}
