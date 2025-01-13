using Hypha.Functions.Loss;

namespace Hypha.Core.Tests.Functions;

public class LossTests
{
    [Fact]
    public void Check_Softmax_Values_Matrix_Equals_VectorSuccess()
    {
        CrossEntropy crossEntropy = new CrossEntropy();

        var row1 = new double[] { 0.7, 0.1, 0.2 };
        var row2 = new double[] { 0.1, 0.5, 0.4 };
        var row3 = new double[] { 0.02, 0.9, 0.08 };

        var t1 = new int[] { 1, 0, 0 };
        var t2 = new int[] { 0, 1, 0 };
        var t3 = new int[] { 0, 1, 0 };

        //var result1 = crossEntropy.Execute(new double[] { row1, row2, row3 }, new int[] { 0, 1, 1 });
        //var result2 = crossEntropy.Execute(new double[] { row1, row2, row3 }, new int[][] { t1, t2, t3 });
        
        //Assert.Equal(result1, result2);
    }
}
