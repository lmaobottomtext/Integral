using System;
using System.Diagnostics;
using static Tests;

public class SimpsonCalculate : ICalculator
{
    double ICalculator.Calculate(double splitCount, double upLim, double lowLim, Func<double, double> integral, out double time)
    {
        if(splitCountCheck(splitCount) && limitCheck(upLim, lowLim))
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            double h = (double)((upLim - lowLim) / splitCount);
            double sum1 = 0.0;
            double sum2 = 0.0;
            time = 0.0;

            for (int i = 2; i <= splitCount+1; i++)
            {
                double xi = lowLim + i * h;
                if (i <= splitCount - 1)
                {
                    sum1 += integral(xi);
                }

                double xi_1 = lowLim + (i - 1) * h;
                sum2 += integral((xi + xi_1) / 2);
            }

            double result = h / 3.0 * (0.5 * integral(lowLim) + sum1 + 2 * sum2 + 0.5 * integral(upLim));
            timer.Stop();
            TimeSpan t = timer.Elapsed;
            time = t.TotalMilliseconds;
            if(testResultSimpson(splitCount, upLim, lowLim, integral, result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }
        else
        {
            time = 0.0;
            return -1;
        }
        
    }
}
