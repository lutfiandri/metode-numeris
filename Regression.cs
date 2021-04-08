using System;

namespace metode_numeris
{
  public abstract class Regression
  {
    protected double[] X;
    protected double[] Y;
    protected double x_bar;
    protected double y_bar;
    protected int n;
    protected string solvedEquation;

    public Regression(double[] X, double[] Y)
    {
      this.X = X;
      this.Y = Y;
      this.x_bar = Numeric.Average(this.X);
      this.y_bar = Numeric.Average(this.Y);
      this.n = X.Length;
    }

    public abstract string Solve();

    public abstract double[] CorrelationCoef();
  }
}