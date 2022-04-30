using System;
using System.Diagnostics;

public class RectangleCalculate : ICalculator
{
   double ICalculator.Calculate(double splitCount, double upLim, double lowLim, Func<double, double> integral, out double time)
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();
        double h = (upLim - lowLim) / splitCount;
        time = 0;
        double sum = 0.0;
        for (int i = 1; i <= splitCount; i++)
        {
            sum += integral(lowLim + h * i);
        }
        sum = sum * h;
        timer.Stop();
        TimeSpan t = timer.Elapsed;
        time = t.TotalMilliseconds;
        return sum;
    }

}
