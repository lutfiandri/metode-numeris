using System;

namespace metode_numeris
{
  public class LinearRegression : Regression
  {
    private double a;
    private double b;

    public LinearRegression(double[] X, double[] Y) : base(X, Y)
    { }

    override
    public string Solve()
    {
      Console.WriteLine("solve with linear regression");
      // b = (n * np.sum(data['xiyi']) - np.sum(data['xi']) *
      //      np.sum(data['yi']))/(n * np.sum(data['xi2']) - np.sum(data['xi'])**2)
      // a = y_bar - b * x_bar
      this.b = (base.n * Numeric.Sum(Numeric.Multiply(X, Y)) - Numeric.Sum(X) * Numeric.Sum(Y))
             / (base.n * Numeric.Sum(Numeric.Multiply(X, X)) - Numeric.Sum(X) * Numeric.Sum(X));

      this.a = base.y_bar - this.b * base.x_bar;

      string equationString = $"y = {this.a}x + {this.b}";
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