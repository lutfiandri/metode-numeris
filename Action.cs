using System;

namespace regression_calculator
{
  public class Action : IIntro, IInputData, ISelectRegressionMethod, IRegressionAnalyze
  {
    private int selectedMethod { get; set; }

    public void Intro()
    {
      Console.WriteLine("Press Ctrl+C to exit\n");
      Console.WriteLine("========== KALKULATOR REGRESI ==========");
      Console.WriteLine();
    }

    public void InputN(ref int n)
    {
      try
      {
        Console.Write("Masukkan jumlah data: ");
        n = Convert.ToInt32(Console.ReadLine());
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine();
        this.InputN(ref n);
      }
      Console.WriteLine();
    }

    public void InputSingleX(ref double[] X, int i)
    {
      double temp;
      Console.Write($"x-{i + 1} : ");
      try
      {
        temp = Convert.ToDouble(Console.ReadLine());
        X[i] = temp;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine();
        this.InputSingleX(ref X, i);
      }
    }

    public void InputSingleY(ref double[] Y, int i)
    {
      double temp;
      Console.Write($"y-{i + 1} : ");
      try
      {
        temp = Convert.ToDouble(Console.ReadLine());
        Y[i] = temp;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine();
        InputSingleY(ref Y, i);
      }
    }

    public void InputXY()
    {
      int n = 0;
      this.InputN(ref n);

      double[] X = new double[n];
      double[] Y = new double[n];

      for (int i = 0; i < n; ++i)
      {
        this.InputSingleX(ref X, i);
        this.InputSingleY(ref Y, i);
        Console.WriteLine();
      }

      Data.X = X;
      Data.Y = Y;

      Console.WriteLine();
    }

    public void ShowRegressionMethods()
    {
      Console.WriteLine("Metode Regresi:");
      Console.WriteLine("  0. Semua Metode");
      Console.WriteLine("  1. Linear Regression               : y = bx + a");
      Console.WriteLine("  2. Power Regression                : y = ax^b");
      Console.WriteLine("  3. Exponential Regression          : y = ae^(bx)");
      Console.WriteLine("  4. Polynomial Regression (Ordo 1)  : y = a0 + a1x");
      Console.WriteLine("  5. Polynomial Regression (Ordo 2)  : y = a0 + a1x + a2x^2");
      Console.WriteLine("  6. Polynomial Regression (Ordo 3)  : y = a0 + a1x + a2x^2 + a3x^3");
      Console.WriteLine();
    }

    public void SelectARegressionMethod()
    {
      Console.Write("Pilih Metode Regresi (0-6) : ");
      try
      {
        this.selectedMethod = Convert.ToInt16(Console.ReadLine());
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine();
        this.SelectARegressionMethod();
      }
      Console.WriteLine();
    }

    public void RunSelectedMethod()
    {
      switch (this.selectedMethod)
      {
        case 0:
          this.selectedMethod = 1;
          this.RunSelectedMethod();

          this.selectedMethod = 2;
          this.RunSelectedMethod();

          this.selectedMethod = 3;
          this.RunSelectedMethod();

          this.selectedMethod = 4;
          this.RunSelectedMethod();

          this.selectedMethod = 5;
          this.RunSelectedMethod();

          this.selectedMethod = 6;
          this.RunSelectedMethod();

          this.selectedMethod = 0;

          break;
        case 1:
          if (!Data.euqations.ContainsKey(this.selectedMethod))
          {
            LinearRegression lin = new LinearRegression(Data.X, Data.Y);
            this.InsertRegressionResultToDB(this.selectedMethod, lin.equation, lin.determinationCoef);
          }
          this.PrintRegressionResult(this.selectedMethod, "==== Linear Regression");
          break;
        case 2:
          if (!Data.euqations.ContainsKey(this.selectedMethod))
          {
            PowerRegression pow = new PowerRegression(Data.X, Data.Y);
            this.InsertRegressionResultToDB(this.selectedMethod, pow.equation, pow.determinationCoef);
          }
          this.PrintRegressionResult(this.selectedMethod, "==== Power Regression");
          break;
        case 3:
          if (!Data.euqations.ContainsKey(this.selectedMethod))
          {
            ExponentialRegression exp = new ExponentialRegression(Data.X, Data.Y);
            this.InsertRegressionResultToDB(this.selectedMethod, exp.equation, exp.determinationCoef);
          }
          this.PrintRegressionResult(this.selectedMethod, "==== Exponential Regression");
          break;
        case 4:
          if (!Data.euqations.ContainsKey(this.selectedMethod))
          {
            PolynomialRegression poly1 = new PolynomialRegression(Data.X, Data.Y);
            this.InsertRegressionResultToDB(this.selectedMethod, poly1.equation, poly1.determinationCoef);
          }
          this.PrintRegressionResult(this.selectedMethod, "==== Polynomial Regression (Ordo 1)");
          break;
        case 5:
          if (!Data.euqations.ContainsKey(this.selectedMethod))
          {
            PolynomialRegression poly2 = new PolynomialRegression2(Data.X, Data.Y);
            this.InsertRegressionResultToDB(this.selectedMethod, poly2.equation, poly2.determinationCoef);
          }
          this.PrintRegressionResult(this.selectedMethod, "==== Polynomial Regression (Ordo 2)");
          break;
        case 6:
          if (!Data.euqations.ContainsKey(this.selectedMethod))
          {
            PolynomialRegression poly3 = new PolynomialRegression3(Data.X, Data.Y);
            this.InsertRegressionResultToDB(this.selectedMethod, poly3.equation, poly3.determinationCoef);
          }
          this.PrintRegressionResult(this.selectedMethod, "==== Polynomial Regression (Ordo 3)");
          break;
        default:
          Console.WriteLine();
          this.SelectARegressionMethod();
          this.RunSelectedMethod();
          break;
      }
      Console.WriteLine();
    }

    public void StartRegressionFullStep()
    {
      this.ShowRegressionMethods();
      Console.WriteLine();
      Console.WriteLine("---------------------------------------------------------");
      Console.WriteLine();
      while (true)
      {
        this.SelectARegressionMethod();
        this.RunSelectedMethod();
        Console.WriteLine();
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine();
      }
    }

    private void PrintRegressionResult(int index, string title)
    {
      Console.WriteLine(title);
      Console.WriteLine(Data.euqations[index]);
      Console.WriteLine($"Koefisien Determinasi = {Data.determinationCoefs[index]}");
    }

    private void InsertRegressionResultToDB(int index, string equation, double determinationCoef)
    {
      Data.euqations.Add(index, equation);
      Data.determinationCoefs.Add(index, determinationCoef);
    }

    public void AnalyzeBestMethod()
    {

    }
  }
}