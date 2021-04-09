using System.Collections.Generic;

namespace regression_calculator
{
  public static class Data
  {
    public static double[] X;
    public static double[] Y;

    public static Dictionary<int, string> euqations = new Dictionary<int, string>();
    public static Dictionary<int, double> determinationCoefs = new Dictionary<int, double>();
  }
}