using System;

namespace metode_numeris
{
  public class NonLinearRegression : Regression
  {
    public NonLinearRegression(double[] X, double[] Y) : base(X, Y)
    {
      Console.WriteLine(X[0]);
      Console.WriteLine(Y[0]);
      Console.WriteLine(base.X);
      Console.WriteLine(base.Y);
    }

    override
    public string Solve()
    {
      Console.WriteLine("solve with non linear regression");
      string equationString = "y = ax^b";
      return (equationString);
    }

    override
    public double[] CorrelationCoef()
    {
      Console.WriteLine("solve");
      double[] x = { 1, 2, 3 };
      return (x);
    }
  }
}