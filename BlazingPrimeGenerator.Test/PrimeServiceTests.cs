using System;
using System.Collections.Generic;
using BlazingPrimeGenerator.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace BlazingPrimeGenerator.Test;

public class PrimeServiceTests 
{
    private PrimeService _service;

    public PrimeServiceTests()
    {
        var mockLogger = new Mock<ILogger<PrimeService>>();
        _service = new PrimeService(mockLogger.Object);
    }
    
    [Theory]
    [Repeat(10)]
    public void GivenCountWhenGenerateNumberThenGenerateExactCount(int count)
    {
       var list =  _service.GeneratePrimeNumbers(count);
       Assert.Equal(list.Count, count);
    }

    [Theory]
    [InlineData(0,false)]
    [InlineData(1,false)]
    [InlineData(2,true)]
    [InlineData(3,true)]
    [InlineData(4,false)]
    [InlineData(5,true)]
    [InlineData(6,false)]
    [InlineData(7,true)]
    [InlineData(8,false)]
    [InlineData(97,true)]
    public void GivenNumberWhenPrimeNumberCheckThenReturnValidResult(int number, bool isNumberPrime)
    {
        var result = _service.IsNumberPrime(number);
        Assert.Equal(result,isNumberPrime);
    }

  

}

    
