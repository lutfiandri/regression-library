using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regression
{
    interface ILineFunction
    {
        double f(double x);
        double[] F();
    }
}
