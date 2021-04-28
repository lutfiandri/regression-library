using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regression
{
    class ExponentialRegression : Regression
    {
        public double a { get; protected set; }
        public double b { get; protected set; }
        public double[] Q { get; protected set; }
        private LinearRegression lr { get; set; }

        public ExponentialRegression(double[] X, double[] Y) : base(X, Y)
        {
            // y = ae^(bx) => log(y) = bx + log(a)
            // p = x
            // q = log(y)
            // a' = log(a)

            this.Q = Numeric.Log(Y);
            this.lr = new LinearRegression(this.X, this.Q);

            this.Solve();
        }

        protected override void Solve()
        {
            // a = e^a'
            this.a = Math.Exp(this.lr.a);
            this.b = this.lr.b;

            string a_text = this.a > 0 ? $"{a:0.000}" : $"- {-a:0.000}";
            string b_text = this.b > 0 ? $"{b:0.000}x" : $"(-{-b:0.000}x)";

            this.equation = $"y = {a_text}e^{b_text}";

            this.YRegression = this.F();
            this.determinationCoef = this.DeterminationCoef();
        }

        public override double f(double x)
        {
            return this.a * Math.Exp(this.b * x);
        }
    }
}
