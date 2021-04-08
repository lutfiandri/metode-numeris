using System;

namespace metode_numeris
{
  class Program
  {
    static void Main(string[] args)
    {
      double[] X = { 4, 6, 8, 10, 14, 16, 20, 22, 24, 28 };
      double[] Y = { 30, 18, 22, 28, 14, 22, 16, 8, 20, 8 };
      LinearRegression linearRegression = new LinearRegression(X, Y);
      Console.WriteLine(linearRegression.Solve());

      // NonLinearRegression nonLinearRegression = new NonLinearRegression(X, Y);
      // Console.WriteLine(nonLinearRegression.Solve());
    }
  }
}
