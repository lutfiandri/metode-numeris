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

      Console.WriteLine("\n\n Linear Regression");
      LinearRegression linearRegression = new LinearRegression(X, Y);
      Console.WriteLine(linearRegression.equation);

      Console.WriteLine(linearRegression.determinationCoef);
      Console.WriteLine();

      Console.WriteLine("\n\n Power Regression");
      PowerRegression powerRegression = new PowerRegression(X, Y);
      Console.WriteLine(powerRegression.equation);
      Console.WriteLine(powerRegression.determinationCoef);
      Console.WriteLine();

      Console.WriteLine("\n\n Exponen Regression");
      ExponentialRegression exponentialRegression = new ExponentialRegression(X, Y);
      Console.WriteLine(exponentialRegression.equation);
      Console.WriteLine(exponentialRegression.determinationCoef);
      Console.WriteLine();

      Console.WriteLine("\n\n Poli Regression");
      PolynomialRegression polynomialRegression = new PolynomialRegression(X, Y);
      Console.WriteLine(polynomialRegression.equation);
      Console.WriteLine(polynomialRegression.determinationCoef);
      Console.WriteLine();

      // Polymorphisme
      Console.WriteLine("\n\n Poli2 Regression");
      PolynomialRegression polynomialRegression2 = new PolynomialRegression2(X, Y);
      Console.WriteLine(polynomialRegression2.equation);
      Console.WriteLine(polynomialRegression2.determinationCoef);
      Console.WriteLine();

      // Polymorphisme
      Console.WriteLine("\n\n Poli3 Regression");
      PolynomialRegression polynomialRegression3 = new PolynomialRegression3(X, Y);
      Console.WriteLine(polynomialRegression3.equation);
      Console.WriteLine(polynomialRegression3.determinationCoef);
      Console.WriteLine();
    }
  }
}
