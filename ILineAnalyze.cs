using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regression
{
    interface ILineAnalyze
    {
        double Dt();
        double LeastSquareError();
        double DeterminationCoef();
    }
}
