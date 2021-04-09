namespace regression_calculator
{
  public interface ILineAnalyze
  {
    double Dt();
    double LeastSquareError();
    double CorrelationCoef();
  }
}