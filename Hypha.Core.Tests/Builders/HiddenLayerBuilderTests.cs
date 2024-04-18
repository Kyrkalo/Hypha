﻿using Hypha.Builders;
using Hypha.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypha.Core.Tests.Builders;

public class HiddenLayerBuilderTests
{
    [Theory]
    [InlineData(10, 11)]
    [InlineData(7, 1)]
    [InlineData(6, 5)]
    [InlineData(1, 5)]
    public void Build_Test(int height, int connections)
    {
        HiddenLayerBuilder inputLayerBuilder = new();
        var inputLayer = inputLayerBuilder.Setup(new Setup(height, connections)).Build();

        Assert.NotNull(inputLayer);
        Assert.True(inputLayer.Neurons.Length == height);
    }
}
