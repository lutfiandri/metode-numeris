using System;

namespace regression_calculator
{
  public abstract class Regression : ILineFunction, ILineAnalyze
  {
    public double[] X { get; protected set; }
    public double[] Y { get; protected set; }
    public double[] YRegression { get; protected set; }
    protected double x_bar { get; set; }
    protected double y_bar { get; set; }
    protected int n { get; set; }
    public double correlationCoef { get; protected set; }
    public string equation { get; protected set; }

    public Regression(double[] X, double[] Y)
    {
      this.X = X;
      this.Y = Y;
      this.x_bar = Numeric.Average(this.X);
      this.y_bar = Numeric.Average(this.Y);
      this.n = X.Length;
    }

    protected abstract void Solve();

    public abstract double f(double x);

    public double[] F()
    {
      double[] YRegression = new double[X.Length];
      for (int i = 0; i < this.X.Length; ++i)
      {
        YRegression[i] = f(this.X[i]);
      }
      return YRegression;
    }

    public double Dt()
    {
      return Numeric.Sum(Numeric.Pow(Numeric.Subtract(this.Y, Numeric.Average(this.Y)), 2));
    }

    public double LeastSquareError()
    {
      return Numeric.Sum(Numeric.Pow(Numeric.Subtract(this.Y, this.YRegression), 2));
    }

    public double CorrelationCoef()
    {
      return Math.Sqrt((this.Dt() * this.LeastSquareError()) / this.Dt());
    }
  }
}