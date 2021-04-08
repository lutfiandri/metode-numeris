using System;

namespace regression_calculator
{
  class Program
  {
    static void Main(string[] args)
    {
      double[] X = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
      double[] Y = { 0.90, 1.42, 1.30, 1.55, 1.63, 1.32, 1.35, 1.47, 1.95, 1.66, 1.96, 1.47, 1.92, 1.35,
              1.05, 1.85, 1.74, 1.65, 1.78, 1.71, 2.29, 1.82, 2.06, 2.14, 1.27 };

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

      // Polymorphisme
      PolynomialRegression polynomialRegression2 = new PolynomialRegression2(X, Y);
      Console.WriteLine(polynomialRegression2.equationString);
      Console.WriteLine();

      // Polymorphisme
      PolynomialRegression polynomialRegression3 = new PolynomialRegression3(X, Y);
      Console.WriteLine(polynomialRegression3.equationString);
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
