using System;

namespace regression_calculator
{
    public class Action : IIntro, IInputData, ISelectRegressionMethod
    {
        private int selectedMethod { get; set; }

        public void Intro()
        {
            Console.WriteLine("Press Ctrl+C to exit\n");
            Console.WriteLine("========== KALKULATOR REGRESI ==========");
            Console.WriteLine();
        }

        public void SelectWhatNext()
        {
            Console.WriteLine("Press (1) for open calculator");
            Console.WriteLine("Press (2) for open history");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (num)
            {
                case 1:
                    InputXY();
                    StartRegressionFullStep();
                    break;
                case 2:
                    ShowHistory();
                    SelectWhatNext();
                    break;
                default:
                    SelectWhatNext();
                    break;
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine("History:");
            Console.WriteLine("-----------------------------");
            Data.SeeHistory();
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
             Console.WriteLine("  0. (See History)");
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
            Console.Write("Pilih Metode Regresi (1-6) : ");
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
                    ShowHistory();
                    SelectWhatNext();
                    break;
                case 1:
                    LinearRegression lin = new LinearRegression(Data.X, Data.Y);
                    this.InsertRegressionResultToDB(this.selectedMethod, lin.equation, lin.determinationCoef);
                    this.PrintRegressionResult("==== Linear Regression", lin.equation, lin.determinationCoef);
                    break;
                case 2:
                    PowerRegression pow = new PowerRegression(Data.X, Data.Y);
                    this.InsertRegressionResultToDB(this.selectedMethod, pow.equation, pow.determinationCoef);
                    this.PrintRegressionResult("==== Power Regression", pow.equation, pow.determinationCoef);
                    break;
                case 3:
                    ExponentialRegression exp = new ExponentialRegression(Data.X, Data.Y);
                    this.InsertRegressionResultToDB(this.selectedMethod, exp.equation, exp.determinationCoef);
                    this.PrintRegressionResult("==== Exponential Regression", exp.equation, exp.determinationCoef);
                    break;
                case 4:
                    PolynomialRegression poly1 = new PolynomialRegression(Data.X, Data.Y);
                    this.InsertRegressionResultToDB(this.selectedMethod, poly1.equation, poly1.determinationCoef);
                    this.PrintRegressionResult("==== Polynomial Regression (Ordo 1)", poly1.equation, poly1.determinationCoef);
                    break;
                case 5:
                    PolynomialRegression poly2 = new PolynomialRegression2(Data.X, Data.Y);
                    this.InsertRegressionResultToDB(this.selectedMethod, poly2.equation, poly2.determinationCoef);
                    this.PrintRegressionResult("==== Polynomial Regression (Ordo 2)", poly2.equation, poly2.determinationCoef);
                    break;
                case 6:
                    PolynomialRegression poly3 = new PolynomialRegression3(Data.X, Data.Y);
                    this.InsertRegressionResultToDB(this.selectedMethod, poly3.equation, poly3.determinationCoef);
                    this.PrintRegressionResult("==== Polynomial Regression (Ordo 3)", poly3.equation, poly3.determinationCoef);
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

        private void PrintRegressionResult(string title, string equation, double coef)
        {
            Console.WriteLine(title);
            Console.WriteLine(equation);
            Console.WriteLine($"Koefisien Determinasi = {coef}");
        }

        private void InsertRegressionResultToDB(int index, string equation, double determinationCoef)
        {
            Data.AddHistory(Data.X, Data.Y, equation, determinationCoef);
        }

  }
}