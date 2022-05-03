using System;
using System.Diagnostics;
using static Tests;

public class RectangleCalculate : ICalculator
{
   double ICalculator.Calculate(double splitCount, double upLim, double lowLim, Func<double, double> integral, out double time)
    {    
        if(splitCountCheck(splitCount) && limitCheck(upLim, lowLim))
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            double h = (upLim - lowLim) / splitCount;
            time = 0;
            double sum = 0.0;
            for (int i = 0; i < splitCount; i++)
            {
                sum += integral(lowLim + h * i);
            }
            sum = sum * h;
            timer.Stop();
            TimeSpan t = timer.Elapsed;
            time = t.TotalMilliseconds;

            if(testResultRectangle(splitCount, upLim, lowLim, integral, sum))
            {
                return sum;
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
