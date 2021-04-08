namespace regression_calculator
{
  public class PolynomialRegression2 : PolynomialRegression
  {
    public PolynomialRegression2(double[] X, double[] Y) : base(X, Y)
    { }

    override
    protected void Solve()
    {
      double n = X.Length;

      double sx = Numeric.Sum(X);
      double sx2 = Numeric.Sum(Numeric.Pow(X, 2));
      double sx3 = Numeric.Sum(Numeric.Pow(X, 3));
      double sx4 = Numeric.Sum(Numeric.Pow(X, 4));

      double sy = Numeric.Sum(Y);
      double sxy = Numeric.Sum(Numeric.Multiply(X, Y));
      double sx2y = Numeric.Sum(Numeric.Multiply(Numeric.Pow(X, 2), Y));


      double[][] A = {
        new double[] {n, sx, sx2},
        new double[] {sx, sx2, sx3},
        new double[] {sx2, sx3, sx4}
      };

      double[] B = { sy, sxy, sx2y };

      GaussJordan gj = new GaussJordan(A, B);

      this.constant.Add("a0", gj.ans[0]);
      this.constant.Add("a1", gj.ans[1]);
      this.constant.Add("a2", gj.ans[2]);

      string a2_text = this.constant["a2"] >= 0 ? $"{this.constant["a2"]:0.000}" : $"- {-this.constant["a2"]:0.000}";
      string a1_text = this.constant["a1"] >= 0 ? $"+ {this.constant["a1"]:0.000}" : $"- {-this.constant["a1"]:0.000}";
      string a0_text = this.constant["a0"] >= 0 ? $"+ {this.constant["a0"]:0.000}" : $"- {-this.constant["a0"]:0.000}";

      this.equationString = $"y = {a2_text}x^2 {a1_text}x {a0_text}";

    }
  }
}