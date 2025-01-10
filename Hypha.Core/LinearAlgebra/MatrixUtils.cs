namespace Hypha.LinearAlgebra;

internal class MatrixUtils
{
    public static double Dot(double[] x, double[] y)
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

    public static double[,] Dot(double[,] x, double[,] y)
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
}
