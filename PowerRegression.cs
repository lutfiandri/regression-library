using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regression
{
    class PowerRegression : Regression
    {
        public double a { get; protected set; }
        public double b { get; protected set; }
        public double[] P { get; protected set; }
        public double[] Q { get; protected set; }
        private LinearRegression lr { get; set; }

        public PowerRegression(double[] X, double[] Y) : base(X, Y)
        {
            // y = ax^b => log10(y) = b log10(x) + log10(a)
            // p = log10(x)
            // q = log10(y)
            // a' = log10(a)

            this.P = Numeric.Log10(X);
            this.Q = Numeric.Log10(Y);
            this.lr = new LinearRegression(this.P, this.Q);

            this.Solve();
        }

        protected override void Solve()
        {
            // a = 10^a'
            this.a = Math.Pow(10, this.lr.a);
            this.b = this.lr.b;

            string a_text = this.a > 0 ? $"{a:0.000}" : $"- {-a:0.000}";
            string b_text = this.b > 0 ? $"{b:0.000}" : $"(-{-b:0.000})";

            this.equation = $"y = {a_text}x^{b_text}";

            this.YRegression = this.F();
            this.determinationCoef = this.DeterminationCoef();
        }

        public override double f(double x)
        {
            return this.a * Math.Pow(x, this.b);
        }
    }
}
