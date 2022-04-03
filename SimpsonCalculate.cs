using System;

public class SimpsonCalculate : ICalculator
{
    double ICalculator.Calculate(double splitCount, double upLim, double lowLim, Func<double, double> integral, out double time)
    {
        double h = (upLim - lowLim) / splitCount;
        time = 0;
        double sum1 = 0.0;
        double sum2 = 0.0;
        for (int i = 0; i < splitCount; i+=2)
        {
            sum1 += integral(lowLim + i * h);
            sum2 += integral(lowLim + i+1 * h);
        }
        return h / 3.0 * (integral(lowLim) + 4 * sum1 + 2 * sum2);
    }
}
