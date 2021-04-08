using System;

namespace regression_calculator
{
  class Program
  {
    static void Main(string[] args)
    {
      double[] X = { 4, 6, 8, 10, 14, 16, 20, 22, 24, 28 };
      double[] Y = { 30, 18, 22, 28, 14, 22, 16, 8, 20, 8 };

      LinearRegression linearRegression = new LinearRegression(X, Y);
      Console.WriteLine(linearRegression.equationString);
      Console.WriteLine();

      PowerRegression powerRegression = new PowerRegression(X, Y);
      Console.WriteLine(powerRegression.equationString);
      Console.WriteLine();

      ExponentialRegression exponentialRegression = new ExponentialRegression(X, Y);
      Console.WriteLine(exponentialRegression.equationString);
      Console.WriteLine();
    }
  }
}
