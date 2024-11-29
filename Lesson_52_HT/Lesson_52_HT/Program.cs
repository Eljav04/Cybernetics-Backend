using MyCustomCalculator;

Calculator c = new();

decimal x = 45.34m;
decimal y = 10.23m;

Console.WriteLine($"Sum: {c.Sum(x,y)}\n" +
    $"Difference: {c.Difference(x,y)}\n" +
    $"Divide: {c.Divide(x,y)}\n" +
    $"Multiply {c.Multuiply(x,y)}");

Console.ReadLine();