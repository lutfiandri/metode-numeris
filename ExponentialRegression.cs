using System;

namespace metode_numeris
{
  public class ExponentialRegression : NonLinearRegression
  {
    public ExponentialRegression(double[] X, double[] Y) : base(X, Y)
    { }

    override
    protected void Solve()
    {
      // y = ae^(bx) => log(y) = bx + log(a)
      // p = x
      // q = log(y)
      // a' = log(a)

      double[] P = X;
      double[] Q = Numeric.Log(Y);

      LinearRegression lr = new LinearRegression(P, Q);

      // a = e^a'
      this.a = Math.Exp(lr.a);
      this.b = lr.b;

      string a_text = this.a > 0 ? $"{a:0.000}" : $"-{-a:0.000}";
      string b_text = this.b > 0 ? $"{b:0.000}x" : $"(-{-b:0.000}x)";

      this.equationString = $"y = {a_text}e^{b_text}";
    }
  }
}