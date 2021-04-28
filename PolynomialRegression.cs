using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regression
{
    class PolynomialRegression : Regression
    {
        public Dictionary<string, double> constant = new Dictionary<string, double>();
        protected GaussJordan gj { get; set; }
        protected double[][] A { get; set; }
        protected double[] B { get; set; }

        public PolynomialRegression(double[] X, double[] Y) : base(X, Y)
        {
            this.Solve();
        }

        protected override void Solve()
        {
            this.setMatrix();

            this.gj = new GaussJordan(this.A, this.B);

            this.constant.Add("a0", this.gj.ans[0]);
            this.constant.Add("a1", this.gj.ans[1]);

            string a1_text = this.constant["a1"] >= 0 ? $"{this.constant["a1"]:0.000}" : $"- {-this.constant["a1"]:0.000}";
            string a0_text = this.constant["a0"] >= 0 ? $"+ {this.constant["a0"]:0.000}" : $"- {-this.constant["a0"]:0.000}";

            this.equation = $"y = {a1_text}x {a0_text}";

            this.YRegression = this.F();
            this.determinationCoef = this.DeterminationCoef();
        }

        protected virtual void setMatrix()
        {
            double sx = Numeric.Sum(X);
            double sx2 = Numeric.Sum(Numeric.Pow(X, 2));
            double sx3 = Numeric.Sum(Numeric.Pow(X, 3));
            double sx4 = Numeric.Sum(Numeric.Pow(X, 4));

            double sy = Numeric.Sum(Y);
            double sxy = Numeric.Sum(Numeric.Multiply(X, Y));

            double[][] A = {
                new double[] {n, sx},
                new double[] {sx, sx2},
            };
            
            double[] B = { sy, sxy };

            this.A = A;
            this.B = B;
        }

        public override double f(double x)
        {
            return this.constant["a1"] * x + this.constant["a0"];
        }
    }
}
