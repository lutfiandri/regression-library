using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regression
{
    class LinearRegression : Regression
    {
        public double a { get; protected set; }
        public double b { get; protected set; }

        public LinearRegression(double[] X, double[] Y) : base(X, Y)
        {
            this.Solve();
        }

        protected override void Solve()
        {
            this.b = (this.n * Numeric.Sum(Numeric.Multiply(X, Y)) - Numeric.Sum(X) * Numeric.Sum(Y))
                   / (this.n * Numeric.Sum(Numeric.Multiply(X, X)) - Numeric.Sum(X) * Numeric.Sum(X));

            this.a = this.y_bar - this.b * this.x_bar;

            string a_text = this.a >= 0 ? $"+ {this.a:0.000}" : $"- {-this.a:0.000}";
            string b_text = this.b >= 0 ? $"{this.b:0.000}" : $"- {-this.b:0.000}";

            this.equation = $"y = {b_text}x {a_text}";

            this.YRegression = this.F();
            this.determinationCoef = this.DeterminationCoef();
        }

        public override double f(double x)
        {
            return this.a + this.b * x;
        }
    }
}
