namespace BlazingPrimeGenerator.Services;

public class PrimeService
{
    private readonly ILogger<PrimeService> _logger;

    public PrimeService(ILogger<PrimeService>  logger)
    {
        _logger = logger;
    }
    
    public List<int> GeneratePrimeNumbers(int numbersToGenerate)
    {
        _logger.LogInformation($"Generating {numbersToGenerate} numbers");
        
        var primeNumbers = new List<int>();
        var number = 2;
        while (primeNumbers.Count < numbersToGenerate)
        {
            if (IsNumberPrime(number))
            {
                primeNumbers.Add(number);
            }

            number++;
        }

        return primeNumbers;
    }

    private bool IsNumberPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;
        
        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (var i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}