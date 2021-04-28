using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regression
{
    public static class Numeric
    {
        // x + y
        public static double[] Add(double[] X, double y)
        {
            double[] Result = new double[X.Length];
            for (int i = 0; i < X.Length; ++i)
            {
                Result[i] = X[i] + y;
            }
            return Result;
        }

        public static double[] Add(double[] X, double[] Y)
        {
            double[] Result = new double[X.Length];
            for (int i = 0; i < X.Length; ++i)
            {
                Result[i] = X[i] + Y[i];
            }
            return Result;
        }

        // x - y
        public static double[] Subtract(double[] X, double y)
        {
            double[] Result = new double[X.Length];
            for (int i = 0; i < X.Length; ++i)
            {
                Result[i] = X[i] - y;
            }
            return Result;
        }

        public static double[] Subtract(double[] X, double[] Y)
        {
            double[] Result = new double[X.Length];
            for (int i = 0; i < X.Length; ++i)
            {
                Result[i] = X[i] - Y[i];
            }
            return Result;
        }

        // x * y
        public static double[] Multiply(double[] X, double y)
        {
            double[] Result = new double[X.Length];
            for (int i = 0; i < X.Length; ++i)
            {
                Result[i] = X[i] * y;
            }
            return Result;
        }

        public static double[] Multiply(double[] X, double[] Y)
        {
            double[] Result = new double[X.Length];
            for (int i = 0; i < X.Length; ++i)
            {
                Result[i] = X[i] * Y[i];
            }
            return Result;
        }

        // x / y
        public static double[] Divide(double[] X, double y)
        {
            double[] Result = new double[X.Length];
            for (int i = 0; i < X.Length; ++i)
            {
                if (X[i] == 0 && y == 0) continue;
                Result[i] = X[i] / y;
            }
            return Result;
        }

        public static double[] Divide(double[] X, double[] Y)
        {
            double[] Result = new double[X.Length];
            for (int i = 0; i < X.Length; ++i)
            {
                if (X[i] == 0 && Y[i] == 0) continue;
                Result[i] = X[i] / Y[i];
            }
            return Result;
        }

        public static double Sum(double[] nums)
        {
            double total = 0;
            foreach (var num in nums)
            {
                total += num;
            }
            return total;
        }

        public static double Average(double[] nums)
        {
            return (Sum(nums) / nums.Length);
        }

        public static double[] Pow(double[] X, double y)
        {
            double[] Result = new double[X.Length];
            for (int i = 0; i < X.Length; ++i)
            {
                Result[i] = Math.Pow(X[i], y);
            }
            return Result;
        }

        public static double[] Log(double[] X)
        {
            double[] Result = new double[X.Length];
            for (int i = 0; i < X.Length; ++i)
            {
                Result[i] = Math.Log(X[i]);
            }
            return Result;
        }

        public static double[] Log10(double[] X)
        {
            double[] Result = new double[X.Length];
            for (int i = 0; i < X.Length; ++i)
            {
                Result[i] = Math.Log10(X[i]);
            }
            return Result;
        }
    }
}
