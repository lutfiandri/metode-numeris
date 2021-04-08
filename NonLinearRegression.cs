using System;

namespace metode_numeris
{
  public abstract class NonLinearRegression : Regression
  {
    public double a { get; set; }
    public double b { get; set; }

    public NonLinearRegression(double[] X, double[] Y) : base(X, Y)
    { }

    override
    protected abstract void Solve();

    // override
    // public abstract double[] CorrelationCoef();
  }
}