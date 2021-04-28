using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regression
{
    class GaussJordan
    {
        // ini gauss jordan
        private double[][] A { get; set; }
        private double[] B { get; set; }
        public double[] ans { get; set; }

        public GaussJordan(double[][] A, double[] B)
        {
            if (A.Length != B.Length)
            {
                throw new Exception("Pastikan matrix A dan B benar! A = array2D (n x n). B = array1D (n)");
            }

            this.A = A;
            this.B = B;
            this.Solve();
        }

        private void Solve()
        {
            int size = B.Length;
            for (int i = 0; i < size; ++i)
            {
                double[] row = this.A[i];
                if (this.B[i] != 0 && this.A[i][i] != 0)
                {
                    this.B[i] = this.B[i] / this.A[i][i];
                }
                this.A[i] = Numeric.Divide(this.A[i], this.A[i][i]);

                for (int j = 0; j < size; ++j)
                {
                    if (i == j) continue;
                    this.B[j] = B[j] - this.B[i] * this.A[j][i];
                    this.A[j] = Numeric.Subtract(this.A[j], Numeric.Multiply(this.A[i], this.A[j][i]));
                }
            }

            this.ans = this.B;
        }
    }
}
