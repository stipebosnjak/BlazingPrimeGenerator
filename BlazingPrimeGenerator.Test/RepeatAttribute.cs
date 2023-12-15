using System.Linq;

namespace BlazingPrimeGenerator.Test;

public class RepeatAttribute : Xunit.Sdk.DataAttribute
{
    private readonly int _count;

    public RepeatAttribute(int count)
    {
        if (count < 1)
        {
            throw new System.ArgumentOutOfRangeException(
                paramName: nameof(count),
                message: "Repeat count must be greater than 0."
            );
        }

        _count = count;
    }

    public override System.Collections.Generic.IEnumerable<object[]> GetData(System.Reflection.MethodInfo testMethod)
    {
        return Enumerable.Range(start: 1, count: _count)
            .Select(iterationNumber => new object[] { iterationNumber });
    }
}