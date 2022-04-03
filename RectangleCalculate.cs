using System;

public class RectangleCalculate : ICalculator
{
   double ICalculator.Calculate(double splitCount, double upLim, double lowLim, Func<double, double> integral, out double time)
    {
        double h = (upLim - lowLim) / splitCount;
        time = 0;
        double sum = 0.0;
        for (int i = 0; i < splitCount; i++)
        {
            sum += integral(lowLim + h * i);
        }
        return sum;
    }

}
