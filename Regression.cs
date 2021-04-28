using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regression
{
    public abstract class Regression : ILineFunction, ILineAnalyze
    {
        public double[] X { get; protected set; }
        public double[] Y { get; protected set; }
        public double[] YRegression { get; protected set; }
        protected double x_bar { get; set; }
        protected double y_bar { get; set; }
        protected int n { get; set; }
        public double determinationCoef { get; protected set; }
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

        public double DeterminationCoef()
        {
            double Dt = this.Dt();
            double D = this.LeastSquareError();
            return Math.Sqrt((Dt - D) / Dt);
        }

        public void PeekArray(double[] Arr)
        {
            Console.WriteLine("Peek array");
            foreach (var x in Arr)
            {
                Console.WriteLine(x);
            }
        }
    }
}
