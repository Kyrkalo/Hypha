using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypha.Core.Tests.Builders;

public class BuilderTests
{
    [Fact]
    public void Build_Model_Test()
    {
        var builder = new Builder();
        var hypha = builder.Create()
            .AppendLayer(10)
            .AppendLayer(20)
            .AppendLayer(20)
            .AppendOutputLayer(5)
            .Build();
        Assert.NotNull(hypha);
    }
}
