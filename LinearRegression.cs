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
      this.b = (this.n * Numeric.Sum(Numeric.Multiply(X, Y)) - Numeric.Sum(X) * Numeric.Sum(Y))
             / (this.n * Numeric.Sum(Numeric.Multiply(X, X)) - Numeric.Sum(X) * Numeric.Sum(X));

      this.a = this.y_bar - this.b * this.x_bar;

      string a_text = this.a > 0 ? $"{this.a:0.000}" : $"- {-this.a:0.000}";
      string b_text = this.b > 0 ? $"+ {this.b:0.000}" : $"- {-this.b:0.000}";

      this.solvedEquation = $"y = {a_text}x {b_text}";
      return (this.solvedEquation);
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