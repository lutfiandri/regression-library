using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regression
{
    class PolynomialRegression3 : PolynomialRegression
    {
        public PolynomialRegression3(double[] X, double[] Y) : base(X, Y)
        { }

        protected override void Solve()
        {
            this.setMatrix();

            this.gj = new GaussJordan(this.A, this.B);

            this.constant.Add("a0", this.gj.ans[0]);
            this.constant.Add("a1", this.gj.ans[1]);
            this.constant.Add("a2", this.gj.ans[2]);
            this.constant.Add("a3", this.gj.ans[3]);

            string a3_text = this.constant["a3"] >= 0 ? $"{this.constant["a3"]:0.000}" : $"- {-this.constant["a3"]:0.000}";
            string a2_text = this.constant["a2"] >= 0 ? $"+ {this.constant["a2"]:0.000}" : $"- {-this.constant["a2"]:0.000}";
            string a1_text = this.constant["a1"] >= 0 ? $"+ {this.constant["a1"]:0.000}" : $"- {-this.constant["a1"]:0.000}";
            string a0_text = this.constant["a0"] >= 0 ? $"+ {this.constant["a0"]:0.000}" : $"- {-this.constant["a0"]:0.000}";

            this.equation = $"y = {a3_text}x^3 {a2_text}x^2 {a1_text}x {a0_text}";

            this.YRegression = this.F();
            this.determinationCoef = this.DeterminationCoef();
        }


        protected override void setMatrix()
        {
            double sx = Numeric.Sum(X);
            double sx2 = Numeric.Sum(Numeric.Pow(X, 2));
            double sx3 = Numeric.Sum(Numeric.Pow(X, 3));
            double sx4 = Numeric.Sum(Numeric.Pow(X, 4));
            double sx5 = Numeric.Sum(Numeric.Pow(X, 5));
            double sx6 = Numeric.Sum(Numeric.Pow(X, 6));

            double sy = Numeric.Sum(Y);
            double sxy = Numeric.Sum(Numeric.Multiply(X, Y));
            double sx2y = Numeric.Sum(Numeric.Multiply(Numeric.Pow(X, 2), Y));
            double sx3y = Numeric.Sum(Numeric.Multiply(Numeric.Pow(X, 3), Y));

            double[][] A = {
                new double[] {n, sx, sx2, sx3},
                new double[] {sx, sx2, sx3, sx4},
                new double[] {sx2, sx3, sx4, sx5},
                new double[] {sx3, sx4, sx5, sx6},
             };

            double[] B = { sy, sxy, sx2y, sx3y };

            this.A = A;
            this.B = B;
        }

        public override double f(double x)
        {
            return this.constant["a3"] * Math.Pow(x, 3) + this.constant["a2"] * Math.Pow(x, 2) + this.constant["a1"] * x + this.constant["a0"];
        }
    }
}
