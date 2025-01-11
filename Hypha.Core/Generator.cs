namespace Hypha;

public static class Generator
{
    /// <summary>
    /// Generates random data for testing math logic
    /// </summary>
    /// <param name="points"></param>
    /// <param name="classes"></param>
    /// <returns></returns>
    public static (double[,], int[]) SpiralData(int points, int classes)
    {
        int totalPoints = points * classes;
        double[,] X = new double[totalPoints, 2]; 
        int[] y = new int[totalPoints];

        Random random = new Random();

        for (int classNumber = 0; classNumber < classes; classNumber++)
        {
            int start = points * classNumber;
            int end = points * (classNumber + 1);

            for (int i = start; i < end; i++)
            {
                int ix = i - start;
                double r = (double)ix / points;
                double t = classNumber * 4 + ix * 4.0 / points + (random.NextDouble() - 0.5) * 0.2; // Theta

                X[i, 0] = r * Math.Sin(t);
                X[i, 1] = r * Math.Cos(t);
                y[i] = classNumber;       
            }
        }

        return (X, y);
    }
}
