using System;

namespace regression_calculator
{
  public class PowerRegression : NonLinearRegression
  {
    public PowerRegression(double[] X, double[] Y) : base(X, Y)
    { }

    override
    protected void Solve()
    {
      // y = ax^b => log10(y) = b log10(x) + log10(a)
      // p = log10(x)
      // q = log10(y)
      // a' = log10(a)

      double[] P = Numeric.Log10(X);
      double[] Q = Numeric.Log10(Y);

      LinearRegression lr = new LinearRegression(P, Q);

      // a = 10^a'
      this.a = Math.Pow(10, lr.a);
      this.b = lr.b;

      string a_text = this.a > 0 ? $"{a:0.000}" : $"-{-a:0.000}";
      string b_text = this.b > 0 ? $"{b:0.000}" : $"(-{-b:0.000})";

      this.equationString = $"y = {a_text}x^{b_text}";
    }
  }
}