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

      PolynomialRegression polynomialRegression = new PolynomialRegression(X, Y);
      Console.WriteLine(polynomialRegression.equationString);
      Console.WriteLine();

      // [8, -2, -1, 4],
      // [2, 8, 2, -1],
      // [-1, 2, 8, 2],
      // [4, -1, 2, 8]

      // double[][] A = {
      //   new double[] {8, -2, -1, 4},
      //   new double[] {2, 8, 2, -1},
      //   new double[] {-1, 2, 8, 2},
      //   new double[] {4, -1, 2, 8}
      // };

      // double[] B = { 17, 9, -10, 4 };

      // GaussJordan gaussJordan = new GaussJordan(A, B);
      // Console.WriteLine();
    }
  }
}
