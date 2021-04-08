using System.Collections.Generic;

namespace regression_calculator
{
  public class PolynomialRegression : Regression
  {
    protected Dictionary<string, double> constant = new Dictionary<string, double>();

    public PolynomialRegression(double[] X, double[] Y) : base(X, Y)
    { }

    override
    protected void Solve()
    {
      // orde 1 = linear
      LinearRegression lr = new LinearRegression(this.X, this.Y);

      this.constant.Add("a0", lr.b);
      this.constant.Add("a1", lr.a);

      string a1_text = this.constant["a1"] >= 0 ? $"{this.constant["a1"]:0.000}" : $"- {-this.constant["a1"]:0.000}";
      string a0_text = this.constant["a0"] >= 0 ? $"+ {this.constant["a0"]:0.000}" : $"- {-this.constant["a0"]:0.000}";

      this.equationString = $"y = {a1_text}x {a0_text}";
    }
  }
}